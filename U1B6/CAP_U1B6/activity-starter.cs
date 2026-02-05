/**
 * ============================================
 * Student Journal App - Student Activity
 * ============================================
 * 
 * Your Task: Complete this console application!
 * You'll build a journal app that saves entries to a file using:
 *   - File.WriteAllLines / File.ReadAllLines
 *   - File.AppendAllText
 *   - StreamWriter / StreamReader
 *   - File.Exists for safety checks
 *   - try-catch for error handling
 * 
 * Look for TODO comments to find where you need to write code.
 * Run with Ctrl+F5 in Visual Studio, or 'dotnet run' in terminal.
 */

using System;
using System.Collections.Generic;
using System.IO;

class StudentJournal
{
    // ============================================
    // Constants - file paths (don't modify)
    // ============================================
    const string JournalFile = "journal.txt";
    const string BackupFile = "journal-backup.txt";

    
    // ============================================
    // TODO #1: Initialize your collections here
    // ============================================
    // Create a List<string> to hold journal entries in memory.
    // Entries will be loaded from file when the program starts
    // and saved back when changes are made.
    //
    // EXAMPLE from notes:
    //   List<string> items = new List<string>();
    
    // YOUR CODE HERE:
    


    // ============================================
    // Main Program - Menu loop (partially complete)
    // ============================================
    static void Main(string[] args)
    {
        // TODO #2: Load existing entries from file at startup
        // ============================================
        // When the program starts, check if the journal file exists.
        // If it does, read all lines and add them to the entries list.
        //
        // HINT:
        //   if (File.Exists(JournalFile))
        //   {
        //       string[] loaded = File.ReadAllLines(JournalFile);
        //       entries.AddRange(loaded);
        //   }
        
        // YOUR CODE HERE:
        

        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            
            Console.Write("Enter choice (1-7): ");
            string input = Console.ReadLine();
            
            // ============================================
            // TODO #7: Add try-catch for menu input
            // ============================================
            // Wrap the parsing and switch in try-catch
            // to handle non-numeric input gracefully.
            
            // YOUR CODE HERE - wrap in try-catch:
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
            
            // End of try-catch should go here
            
            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    
    
    // ============================================
    // Display Menu (complete - don't modify)
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
    // TODO #3: Add Entry Method
    // ============================================
    static void AddEntry()
    {
        Console.WriteLine("\n--- Write New Entry ---");
        
        // Step 1: Get the entry text from the user
        Console.Write("What's on your mind? ");
        string text = Console.ReadLine();
        
        // Check for empty input
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("❌ Entry cannot be empty!");
            return;
        }
        
        // TODO: Create a formatted entry string with date and text
        // Use DateTime.Now.ToString("yyyy-MM-dd HH:mm") to get the current date/time
        // Format it like: "[2025-01-15 14:30] Your text here"
        //
        // HINT:
        //   string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        //   string entry = $"[{timestamp}] {text}";
        
        // YOUR CODE HERE:
        
        
        // TODO: Add the entry to the list
        // HINT: entries.Add(entry);
        
        // YOUR CODE HERE:
        
        
        // TODO: Also append to the file immediately so it's saved
        // Use File.AppendAllText to add the entry + a newline to JournalFile
        //
        // HINT: File.AppendAllText(JournalFile, entry + "\n");
        
        // YOUR CODE HERE:
        
        
        // TODO: Print a success message showing the entry was saved
        // HINT: Console.WriteLine($"✅ Entry saved: \"{text}\"");
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // TODO #4: View All Entries
    // ============================================
    static void ViewAllEntries()
    {
        Console.WriteLine("\n--- All Journal Entries ---");
        
        // TODO: Check if the list is empty
        // If empty, print "No entries yet! Start writing to build your journal."
        // and return early.
        //
        // HINT: if (entries.Count == 0) { ... }
        
        // YOUR CODE HERE:
        
        
        // TODO: Loop through all entries and display them with numbers
        // Display format:
        //   1. [2025-01-15 14:30] My first journal entry
        //   2. [2025-01-15 15:00] Another thought
        //
        // HINT:
        //   for (int i = 0; i < entries.Count; i++)
        //   {
        //       Console.WriteLine($"  {i + 1}. {entries[i]}");
        //   }
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // TODO #5: Search Entries
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
        
        // TODO: Search through entries and display matches
        // Loop through entries and check if each one contains the search term
        // Use .ToLower() on both strings for case-insensitive search
        //
        // HINT:
        //   int found = 0;
        //   foreach (string entry in entries)
        //   {
        //       if (entry.ToLower().Contains(searchTerm.ToLower()))
        //       {
        //           Console.WriteLine($"  ✓ {entry}");
        //           found++;
        //       }
        //   }
        //
        //   if (found == 0)
        //   {
        //       Console.WriteLine("No entries match your search.");
        //   }
        //   else
        //   {
        //       Console.WriteLine($"\nFound {found} matching entries.");
        //   }
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // TODO #6: Save Entries to File
    // ============================================
    static void SaveToFile()
    {
        Console.WriteLine("\n--- Save to File ---");
        
        // TODO: Save all entries to the journal file using try-catch
        // Use File.WriteAllLines() to save the entire list at once
        // Wrap in try-catch to handle any IOException
        //
        // HINT:
        //   try
        //   {
        //       File.WriteAllLines(JournalFile, entries);
        //       Console.WriteLine($"✅ Saved {entries.Count} entries to {JournalFile}");
        //   }
        //   catch (IOException ex)
        //   {
        //       Console.WriteLine($"❌ Error saving: {ex.Message}");
        //   }
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // BONUS: Export Entries to a New File
    // ============================================
    static void ExportEntries()
    {
        Console.WriteLine("\n--- Export Entries ---");
        Console.Write("Enter export filename (e.g., my-journal.txt): ");
        string exportPath = Console.ReadLine();
        
        // BONUS TODO: Validate the filename and write entries to the new file
        // Use StreamWriter to write a header line, then all entries
        //
        // HINT:
        //   try
        //   {
        //       using (StreamWriter writer = new StreamWriter(exportPath))
        //       {
        //           writer.WriteLine("=== My Journal Export ===");
        //           writer.WriteLine($"Exported on: {DateTime.Now}");
        //           writer.WriteLine($"Total entries: {entries.Count}");
        //           writer.WriteLine("─────────────────────────────");
        //           foreach (string entry in entries)
        //           {
        //               writer.WriteLine(entry);
        //           }
        //       }
        //       Console.WriteLine($"✅ Exported to {exportPath}");
        //   }
        //   catch (Exception ex)
        //   {
        //       Console.WriteLine($"❌ Export failed: {ex.Message}");
        //   }
        
        // YOUR CODE HERE:
        Console.WriteLine("🚧 Bonus feature - implement if you have time!");
    }
    
    
    // ============================================
    // BONUS: Create Backup
    // ============================================
    static void CreateBackup()
    {
        Console.WriteLine("\n--- Create Backup ---");
        
        // BONUS TODO: Copy the journal file to the backup file
        // Check if the journal file exists first, then use File.Copy()
        //
        // HINT:
        //   if (File.Exists(JournalFile))
        //   {
        //       File.Copy(JournalFile, BackupFile, true);
        //       Console.WriteLine($"✅ Backup created: {BackupFile}");
        //   }
        //   else
        //   {
        //       Console.WriteLine("❌ No journal file to back up!");
        //   }
        
        // YOUR CODE HERE:
        Console.WriteLine("🚧 Bonus feature - implement if you have time!");
    }
}


/*
 * ============================================
 * QUICK REFERENCE - Copy from here!
 * ============================================
 * 
 * FILE WRITING:
 *   File.WriteAllText("file.txt", "content");      // Overwrite
 *   File.WriteAllLines("file.txt", stringArray);    // Overwrite
 *   File.AppendAllText("file.txt", "new content");  // Append
 * 
 * FILE READING:
 *   string text = File.ReadAllText("file.txt");
 *   string[] lines = File.ReadAllLines("file.txt");
 *   bool exists = File.Exists("file.txt");
 * 
 * FILE OPERATIONS:
 *   File.Copy("source.txt", "dest.txt", true);  // true = overwrite
 *   File.Delete("file.txt");
 *   File.Move("old.txt", "new.txt");
 * 
 * STREAMWRITER:
 *   using (StreamWriter writer = new StreamWriter("file.txt"))
 *   {
 *       writer.WriteLine("text");
 *   }
 *   // To append: new StreamWriter("file.txt", true)
 * 
 * STREAMREADER:
 *   using (StreamReader reader = new StreamReader("file.txt"))
 *   {
 *       string line;
 *       while ((line = reader.ReadLine()) != null)
 *       {
 *           Console.WriteLine(line);
 *       }
 *   }
 * 
 * TRY-CATCH:
 *   try
 *   {
 *       // File operation
 *   }
 *   catch (IOException ex)
 *   {
 *       Console.WriteLine($"Error: {ex.Message}");
 *   }
 * 
 * DATE/TIME:
 *   DateTime.Now.ToString("yyyy-MM-dd HH:mm")
 *   // Result: "2025-01-15 14:30"
 */
