/**
 * ============================================
 * Student Journal App - SOLUTION
 * ============================================
 * 
 * This is the complete solution for the Student Journal activity.
 * Students should only look at this if they get stuck!
 */

using System;
using System.Collections.Generic;
using System.IO;

class StudentJournal
{
    // ============================================
    // Constants - file paths
    // ============================================
    const string JournalFile = "journal.txt";
    const string BackupFile = "journal-backup.txt";

    
    // ============================================
    // TODO #1: SOLUTION - List initialized
    // ============================================
    static List<string> entries = new List<string>();


    // ============================================
    // Main Program with try-catch
    // ============================================
    static void Main(string[] args)
    {
        // TODO #2: SOLUTION - Load entries from file at startup
        if (File.Exists(JournalFile))
        {
            try
            {
                string[] loaded = File.ReadAllLines(JournalFile);
                entries.AddRange(loaded);
                Console.WriteLine($"📂 Loaded {entries.Count} entries from {JournalFile}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"⚠️ Could not load journal: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("📖 Starting a fresh journal!");
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            
            Console.Write("Enter choice (1-7): ");
            string input = Console.ReadLine();
            
            // TODO #7: SOLUTION - try-catch for menu input
            try
            {
                int choice = int.Parse(input);
                
                switch (choice)
                {
                    case 1:
                        AddEntry();
                        break;
                    case 2:
                        ViewAllEntries();
                        break;
                    case 3:
                        SearchEntries();
                        break;
                    case 4:
                        SaveToFile();
                        break;
                    case 5:
                        ExportEntries();
                        break;
                    case 6:
                        CreateBackup();
                        break;
                    case 7:
                        running = false;
                        Console.WriteLine("\n📖 Goodbye! Keep journaling!");
                        break;
                    default:
                        Console.WriteLine("\n❌ Invalid choice. Please enter 1-7.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n❌ Please enter a valid number (1-7).");
            }
            
            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    
    
    // ============================================
    // Display Menu
    // ============================================
    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine("          📖 STUDENT JOURNAL");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("  1. Write a new entry");
        Console.WriteLine("  2. View all entries");
        Console.WriteLine("  3. Search entries");
        Console.WriteLine("  4. Save entries to file");
        Console.WriteLine("  5. Export entries to new file");
        Console.WriteLine("  6. Create backup");
        Console.WriteLine("  7. Exit");
        Console.WriteLine();
    }
    
    
    // ============================================
    // TODO #3: SOLUTION - Add Entry
    // ============================================
    static void AddEntry()
    {
        Console.WriteLine("\n--- Write New Entry ---");
        
        Console.Write("What's on your mind? ");
        string text = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("❌ Entry cannot be empty!");
            return;
        }
        
        // Create formatted entry with timestamp
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string entry = $"[{timestamp}] {text}";
        
        // Add to list
        entries.Add(entry);
        
        // Append to file immediately
        try
        {
            File.AppendAllText(JournalFile, entry + "\n");
            Console.WriteLine($"\n✅ Entry saved: \"{text}\"");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\n⚠️ Entry added to memory but couldn't save to file: {ex.Message}");
        }
    }
    
    
    // ============================================
    // TODO #4: SOLUTION - View All Entries
    // ============================================
    static void ViewAllEntries()
    {
        Console.WriteLine("\n--- All Journal Entries ---");
        
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries yet! Start writing to build your journal.");
            return;
        }
        
        Console.WriteLine();
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {entries[i]}");
        }
        Console.WriteLine($"\n  Total: {entries.Count} entries");
    }
    
    
    // ============================================
    // TODO #5: SOLUTION - Search Entries
    // ============================================
    static void SearchEntries()
    {
        Console.WriteLine("\n--- Search Entries ---");
        
        Console.Write("Enter search term: ");
        string searchTerm = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            Console.WriteLine("❌ Search term cannot be empty!");
            return;
        }
        
        int found = 0;
        Console.WriteLine();
        
        foreach (string entry in entries)
        {
            if (entry.ToLower().Contains(searchTerm.ToLower()))
            {
                Console.WriteLine($"  ✓ {entry}");
                found++;
            }
        }
        
        if (found == 0)
        {
            Console.WriteLine("No entries match your search.");
        }
        else
        {
            Console.WriteLine($"\nFound {found} matching entries.");
        }
    }
    
    
    // ============================================
    // TODO #6: SOLUTION - Save to File
    // ============================================
    static void SaveToFile()
    {
        Console.WriteLine("\n--- Save to File ---");
        
        try
        {
            File.WriteAllLines(JournalFile, entries);
            Console.WriteLine($"✅ Saved {entries.Count} entries to {JournalFile}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"❌ Error saving: {ex.Message}");
        }
    }
    
    
    // ============================================
    // BONUS: SOLUTION - Export Entries
    // ============================================
    static void ExportEntries()
    {
        Console.WriteLine("\n--- Export Entries ---");
        Console.Write("Enter export filename (e.g., my-journal.txt): ");
        string exportPath = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(exportPath))
        {
            Console.WriteLine("❌ Filename cannot be empty!");
            return;
        }
        
        try
        {
            using (StreamWriter writer = new StreamWriter(exportPath))
            {
                writer.WriteLine("═══════════════════════════════════════════");
                writer.WriteLine("          📖 MY JOURNAL EXPORT");
                writer.WriteLine("═══════════════════════════════════════════");
                writer.WriteLine($"Exported on: {DateTime.Now}");
                writer.WriteLine($"Total entries: {entries.Count}");
                writer.WriteLine("───────────────────────────────────────────");
                writer.WriteLine();
                
                for (int i = 0; i < entries.Count; i++)
                {
                    writer.WriteLine($"{i + 1}. {entries[i]}");
                }
                
                writer.WriteLine();
                writer.WriteLine("───────────────────────────────────────────");
                writer.WriteLine("End of journal export.");
            }
            
            Console.WriteLine($"✅ Exported {entries.Count} entries to {exportPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Export failed: {ex.Message}");
        }
    }
    
    
    // ============================================
    // BONUS: SOLUTION - Create Backup
    // ============================================
    static void CreateBackup()
    {
        Console.WriteLine("\n--- Create Backup ---");
        
        if (File.Exists(JournalFile))
        {
            try
            {
                File.Copy(JournalFile, BackupFile, true);  // true = overwrite existing backup
                Console.WriteLine($"✅ Backup created: {BackupFile}");
                
                // Show file info
                string[] backupLines = File.ReadAllLines(BackupFile);
                Console.WriteLine($"   Backed up {backupLines.Length} entries.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"❌ Backup failed: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("❌ No journal file to back up! Save your entries first.");
        }
    }
}


/*
 * ============================================
 * BONUS EXTENSION IDEAS:
 * ============================================
 * 
 * 1. Delete Entry:
 *    - Let user delete an entry by number
 *    - Re-save the file after deletion
 * 
 * 2. Word Count:
 *    - Count total words across all entries
 *    - Show average words per entry
 * 
 * 3. Date Filter:
 *    - View entries from a specific date
 *    - View entries from today only
 * 
 * 4. Mood Tracker:
 *    - Let user tag entries with mood (😊 😐 😢)
 *    - Show mood statistics
 * 
 * 5. Restore Backup:
 *    - Load entries from the backup file
 *    - Replace current entries with backup
 */
