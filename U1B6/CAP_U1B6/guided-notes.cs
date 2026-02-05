/**
 * ============================================
 * C# Streams & File Handling
 * Guided Notes - Follow Along!
 * ============================================
 * 
 * Run this file in Visual Studio or VS Code
 * Press Ctrl+F5 to run without debugging
 * 
 * Each demo is in a separate method. Uncomment
 * the method calls in Main() to run each demo.
 */

using System;
using System.Collections.Generic;
using System.IO;

class GuidedNotes
{
    static void Main(string[] args)
    {
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.WriteLine("  C# Streams & File Handling");
        Console.WriteLine("═══════════════════════════════════════════════\n");

        // Uncomment each demo to run it:
        Demo1_WritingFiles();
        // Demo2_ReadingFiles();
        // Demo3_AppendingFiles();
        // Demo4_StreamReaderWriter();
        // Demo5_FileOperations();
        // Demo6_ExceptionHandling();
        // Demo7_SaveAndLoadList();

        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("  End of Demo - Press any key to exit");
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.ReadKey();
    }


    // ============================================
    // DEMO 1: Writing Text to a File
    // ============================================
    static void Demo1_WritingFiles()
    {
        Console.WriteLine("▶ DEMO 1: Writing to Files");
        Console.WriteLine("─────────────────────────────────────\n");

        // Write a single string to a file (creates or overwrites)
        File.WriteAllText("hello.txt", "Hello, World!\nWelcome to file handling!");
        Console.WriteLine("✅ hello.txt written with WriteAllText.");

        // Write an array of strings (one per line)
        string[] lines = { "Line 1: First entry", "Line 2: Second entry", "Line 3: Third entry" };
        File.WriteAllLines("lines.txt", lines);
        Console.WriteLine("✅ lines.txt written with WriteAllLines.");

        // Verify the files exist
        Console.WriteLine($"\nhello.txt exists? {File.Exists("hello.txt")}");
        Console.WriteLine($"lines.txt exists? {File.Exists("lines.txt")}");
        Console.WriteLine();
    }


    // ============================================
    // DEMO 2: Reading Text from a File
    // ============================================
    static void Demo2_ReadingFiles()
    {
        Console.WriteLine("▶ DEMO 2: Reading from Files");
        Console.WriteLine("─────────────────────────────────────\n");

        // First, make sure demo files exist
        File.WriteAllText("hello.txt", "Hello, World!\nWelcome to file handling!");
        File.WriteAllLines("lines.txt", new[] { "Line 1: First entry", "Line 2: Second entry", "Line 3: Third entry" });

        // Read entire file as one string
        if (File.Exists("hello.txt"))
        {
            string content = File.ReadAllText("hello.txt");
            Console.WriteLine("--- ReadAllText ---");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("❌ hello.txt not found!");
        }

        Console.WriteLine();

        // Read file as an array of lines
        if (File.Exists("lines.txt"))
        {
            string[] lines = File.ReadAllLines("lines.txt");
            Console.WriteLine($"--- ReadAllLines ({lines.Length} lines) ---");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"  [{i}] {lines[i]}");
            }
        }

        Console.WriteLine();
    }


    // ============================================
    // DEMO 3: Appending to Files
    // ============================================
    static void Demo3_AppendingFiles()
    {
        Console.WriteLine("▶ DEMO 3: Appending vs Overwriting");
        Console.WriteLine("─────────────────────────────────────\n");

        // Start with a fresh file
        File.WriteAllText("log.txt", "=== Application Log ===\n");
        Console.WriteLine("Log file created with WriteAllText.");

        // Append entries (keeps existing content!)
        File.AppendAllText("log.txt", "Entry 1: Application started\n");
        File.AppendAllText("log.txt", "Entry 2: User logged in\n");
        File.AppendAllText("log.txt", "Entry 3: Data saved\n");
        Console.WriteLine("Three entries appended with AppendAllText.");

        // Read and display the full file
        string logContent = File.ReadAllText("log.txt");
        Console.WriteLine("\n--- Full Log ---");
        Console.WriteLine(logContent);

        // Demonstrate the difference: overwrite vs append
        Console.WriteLine("--- Now Overwriting with WriteAllText ---");
        File.WriteAllText("log.txt", "FRESH START - old entries are gone!\n");
        Console.WriteLine(File.ReadAllText("log.txt"));
    }


    // ============================================
    // DEMO 4: StreamReader & StreamWriter
    // ============================================
    static void Demo4_StreamReaderWriter()
    {
        Console.WriteLine("▶ DEMO 4: StreamWriter & StreamReader");
        Console.WriteLine("─────────────────────────────────────\n");

        // Writing with StreamWriter
        using (StreamWriter writer = new StreamWriter("students.txt"))
        {
            writer.WriteLine("Name,Grade,GPA");
            writer.WriteLine("Alice,12,3.8");
            writer.WriteLine("Bob,11,3.5");
            writer.WriteLine("Charlie,12,3.9");
        }
        // File is automatically closed here!

        Console.WriteLine("✅ students.txt written with StreamWriter.");

        // Reading with StreamReader
        Console.WriteLine("\n--- Reading with StreamReader ---");
        using (StreamReader reader = new StreamReader("students.txt"))
        {
            string line;
            int lineNumber = 1;

            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine($"  Line {lineNumber}: {line}");
                lineNumber++;
            }
        }

        // StreamWriter in append mode
        Console.WriteLine("\n--- Appending with StreamWriter ---");
        using (StreamWriter writer = new StreamWriter("students.txt", true))  // true = append
        {
            writer.WriteLine("Diana,10,3.7");
        }
        Console.WriteLine("Diana appended to file.");

        // Verify
        Console.WriteLine("\n--- Full File ---");
        Console.WriteLine(File.ReadAllText("students.txt"));
    }


    // ============================================
    // DEMO 5: File and Path Operations
    // ============================================
    static void Demo5_FileOperations()
    {
        Console.WriteLine("▶ DEMO 5: File & Path Operations");
        Console.WriteLine("─────────────────────────────────────\n");

        string fileName = "demo-file.txt";

        // Create a file
        File.WriteAllText(fileName, "This is a test file.");
        Console.WriteLine($"Created: {fileName}");
        Console.WriteLine($"File exists? {File.Exists(fileName)}");

        // Get info using Path class
        Console.WriteLine($"\nPath Info:");
        Console.WriteLine($"  File name: {Path.GetFileName(fileName)}");
        Console.WriteLine($"  Extension: {Path.GetExtension(fileName)}");
        Console.WriteLine($"  Without ext: {Path.GetFileNameWithoutExtension(fileName)}");

        // Build paths safely with Path.Combine
        string folder = "MyData";
        string fullPath = Path.Combine(folder, "saved.txt");
        Console.WriteLine($"\nCombined path: {fullPath}");

        // Current directory
        Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}");

        // Copy a file
        File.Copy(fileName, "demo-copy.txt", true);  // true = overwrite if exists
        Console.WriteLine($"\nCopied to: demo-copy.txt");
        Console.WriteLine($"Copy exists? {File.Exists("demo-copy.txt")}");

        // Delete a file
        if (File.Exists("demo-copy.txt"))
        {
            File.Delete("demo-copy.txt");
            Console.WriteLine("Copy deleted.");
            Console.WriteLine($"Copy exists? {File.Exists("demo-copy.txt")}");
        }

        Console.WriteLine();
    }


    // ============================================
    // DEMO 6: Exception Handling with Files
    // ============================================
    static void Demo6_ExceptionHandling()
    {
        Console.WriteLine("▶ DEMO 6: Exception Handling with Files");
        Console.WriteLine("─────────────────────────────────────\n");

        // Scenario 1: File doesn't exist
        Console.WriteLine("--- Scenario 1: Missing File ---");
        try
        {
            string content = File.ReadAllText("nonexistent-file.txt");
            Console.WriteLine(content);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("❌ File was not found!");
        }

        // Scenario 2: Safe pattern - check then read/create
        Console.WriteLine("\n--- Scenario 2: Safe Read/Create ---");
        string path = "safe-read.txt";
        try
        {
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                Console.WriteLine($"File content: {text}");
            }
            else
            {
                Console.WriteLine("File doesn't exist. Creating it...");
                File.WriteAllText(path, "Created by the demo program!");
                Console.WriteLine("✅ File created successfully.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"❌ IO Error: {ex.Message}");
        }

        // Scenario 3: Catch-all for file operations
        Console.WriteLine("\n--- Scenario 3: Catch-All ---");
        try
        {
            // Directory that probably doesn't exist
            string badPath = Path.Combine("NonExistentFolder", "SubFolder", "data.txt");
            File.WriteAllText(badPath, "This will fail!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("❌ Directory not found!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error: {ex.GetType().Name} - {ex.Message}");
        }

        Console.WriteLine("\n✓ Program continues running...\n");
    }


    // ============================================
    // DEMO 7: Practical Example - Save/Load List
    // ============================================
    static void Demo7_SaveAndLoadList()
    {
        Console.WriteLine("▶ DEMO 7: Save & Load a List");
        Console.WriteLine("─────────────────────────────────────\n");

        // Create a list of names
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
        Console.WriteLine("Original list:");
        foreach (string name in names)
        {
            Console.WriteLine($"  - {name}");
        }

        // Save list to file
        string savePath = "names.txt";
        File.WriteAllLines(savePath, names);
        Console.WriteLine($"\n✅ Saved {names.Count} names to {savePath}");

        // Clear the list (simulating program restart)
        names.Clear();
        Console.WriteLine($"List cleared. Count: {names.Count}");

        // Load from file
        Console.WriteLine("\nLoading from file...");
        if (File.Exists(savePath))
        {
            string[] loaded = File.ReadAllLines(savePath);
            names.AddRange(loaded);
            Console.WriteLine($"✅ Loaded {names.Count} names from file:");

            foreach (string name in names)
            {
                Console.WriteLine($"  - {name}");
            }
        }
        else
        {
            Console.WriteLine("❌ Save file not found.");
        }

        Console.WriteLine();
    }
}


/*
 * ============================================
 * SUMMARY - Key Concepts to Remember:
 * ============================================
 * 
 * WRITING FILES (using System.IO):
 *   File.WriteAllText(path, text);     // Write string (overwrites!)
 *   File.WriteAllLines(path, lines);   // Write string[] (overwrites!)
 *   File.AppendAllText(path, text);    // Add to end (keeps existing)
 *   File.AppendAllLines(path, lines);  // Add lines to end
 * 
 * READING FILES:
 *   string text = File.ReadAllText(path);    // Whole file as one string
 *   string[] lines = File.ReadAllLines(path); // Each line as array element
 *   bool exists = File.Exists(path);          // Check before reading!
 * 
 * STREAMWRITER (more control):
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
 * FILE OPERATIONS:
 *   File.Exists(path)                // Check if file exists
 *   File.Delete(path)                // Delete a file
 *   File.Copy(src, dest, overwrite)  // Copy a file
 *   File.Move(src, dest)             // Move/rename a file
 * 
 * PATH CLASS:
 *   Path.Combine("folder", "file.txt") // Build paths safely
 *   Path.GetFileName(path)              // Just the filename
 *   Path.GetExtension(path)             // Just the extension
 * 
 * COMMON EXCEPTIONS:
 *   - FileNotFoundException: File doesn't exist
 *   - DirectoryNotFoundException: Folder doesn't exist
 *   - UnauthorizedAccessException: No permission
 *   - IOException: General I/O error (file in use, etc.)
 */
