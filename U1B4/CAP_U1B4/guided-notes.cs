/**
 * ============================================
 * C# Arrays, Collections & Exception Handling
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

class GuidedNotes
{
    static void Main(string[] args)
    {
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.WriteLine("  C# Arrays, Collections & Exception Handling");
        Console.WriteLine("═══════════════════════════════════════════════\n");

        // Uncomment each demo to run it:
        Demo1_CreatingArrays();
        // Demo2_WorkingWithArrays();
        // Demo3_Lists();
        // Demo4_Dictionaries();
        // Demo5_BasicTryCatch();
        // Demo6_ExceptionObject();
        // Demo7_FinallyBlock();

        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("  End of Demo - Press any key to exit");
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.ReadKey();
    }


    // ============================================
    // DEMO 1: Creating Arrays
    // ============================================
    static void Demo1_CreatingArrays()
    {
        Console.WriteLine("▶ DEMO 1: Creating Arrays");
        Console.WriteLine("─────────────────────────────────────\n");

        // Method 1: Declare and initialize with values (most common)
        int[] scores = { 95, 87, 92, 78, 88 };

        // Method 2: Using 'new' with a specific size (values default to 0)
        int[] temperatures = new int[7];  // Array of 7 zeros

        // Method 3: Using 'new' with initializer list
        string[] weekdays = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri" };

        // Print array info
        Console.WriteLine($"Scores array length: {scores.Length}");
        Console.WriteLine($"First score: {scores[0]}");
        Console.WriteLine($"Last score: {scores[scores.Length - 1]}");

        Console.WriteLine("\nTemperatures array (all zeros):");
        foreach (int temp in temperatures)
        {
            Console.Write($"{temp} ");
        }
        Console.WriteLine();

        Console.WriteLine("\nWeekdays:");
        foreach (string day in weekdays)
        {
            Console.Write($"{day} ");
        }
        Console.WriteLine("\n");
    }


    // ============================================
    // DEMO 2: Working with Arrays
    // ============================================
    static void Demo2_WorkingWithArrays()
    {
        Console.WriteLine("▶ DEMO 2: Working with Arrays");
        Console.WriteLine("─────────────────────────────────────\n");

        string[] students = { "Alice", "Bob", "Charlie", "Diana" };

        // Reading elements by index
        Console.WriteLine($"First student: {students[0]}");
        Console.WriteLine($"Third student: {students[2]}");

        // Modifying an element
        students[1] = "Bobby";  // Change "Bob" to "Bobby"
        Console.WriteLine($"Updated second student: {students[1]}");

        // Looping through all elements with foreach
        Console.WriteLine("\nAll students (foreach):");
        foreach (string student in students)
        {
            Console.WriteLine($"  - {student}");
        }

        // Looping with for loop (when you need the index)
        Console.WriteLine("\nWith index numbers (for loop):");
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"  [{i}] {students[i]}");
        }

        // Useful array methods
        Console.WriteLine("\nArray utility methods:");
        int[] numbers = { 42, 17, 89, 5, 63 };
        
        Console.WriteLine($"  Original: {string.Join(", ", numbers)}");
        
        Array.Sort(numbers);
        Console.WriteLine($"  After Sort: {string.Join(", ", numbers)}");
        
        Array.Reverse(numbers);
        Console.WriteLine($"  After Reverse: {string.Join(", ", numbers)}");
        
        int index = Array.IndexOf(numbers, 42);
        Console.WriteLine($"  Index of 42: {index}");
        Console.WriteLine();
    }


    // ============================================
    // DEMO 3: Lists - Dynamic Arrays
    // ============================================
    static void Demo3_Lists()
    {
        Console.WriteLine("▶ DEMO 3: List<T> - Dynamic Arrays");
        Console.WriteLine("─────────────────────────────────────\n");

        // Create an empty list
        List<string> shoppingList = new List<string>();

        // Add items
        shoppingList.Add("Milk");
        shoppingList.Add("Bread");
        shoppingList.Add("Eggs");
        shoppingList.Add("Butter");

        Console.WriteLine($"Items in list: {shoppingList.Count}");

        // Remove an item
        shoppingList.Remove("Bread");
        Console.WriteLine($"After removing Bread: {shoppingList.Count}");

        // Check if item exists
        if (shoppingList.Contains("Milk"))
        {
            Console.WriteLine("Don't forget the milk!");
        }

        // Insert at specific position
        shoppingList.Insert(0, "Coffee");  // Insert at beginning

        // Print all items
        Console.WriteLine("\nShopping List:");
        foreach (string item in shoppingList)
        {
            Console.WriteLine($"  □ {item}");
        }

        // Access by index (like array)
        Console.WriteLine($"\nFirst item: {shoppingList[0]}");
        Console.WriteLine($"Last item: {shoppingList[shoppingList.Count - 1]}");

        // Clear all items
        // shoppingList.Clear();

        // Create list with initial values
        List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13 };
        Console.WriteLine($"\nPrime numbers: {string.Join(", ", primes)}");
        Console.WriteLine();
    }


    // ============================================
    // DEMO 4: Dictionaries - Key/Value Storage
    // ============================================
    static void Demo4_Dictionaries()
    {
        Console.WriteLine("▶ DEMO 4: Dictionary<TKey, TValue>");
        Console.WriteLine("─────────────────────────────────────\n");

        // Store student grades: Name -> Grade
        Dictionary<string, int> grades = new Dictionary<string, int>();

        // Add entries using indexer syntax
        grades["Alice"] = 95;
        grades["Bob"] = 87;
        grades["Charlie"] = 92;

        // Or use Add method
        grades.Add("Diana", 88);

        // Look up a value by key
        Console.WriteLine($"Alice's grade: {grades["Alice"]}");

        // Update a value
        grades["Bob"] = 90;  // Bob studied more!
        Console.WriteLine($"Bob's updated grade: {grades["Bob"]}");

        // Check if key exists
        if (grades.ContainsKey("Eve"))
        {
            Console.WriteLine($"Eve's grade: {grades["Eve"]}");
        }
        else
        {
            Console.WriteLine("Eve not found in gradebook.");
        }

        // Safe lookup with TryGetValue (preferred method)
        if (grades.TryGetValue("Charlie", out int charlieGrade))
        {
            Console.WriteLine($"Charlie's grade (using TryGetValue): {charlieGrade}");
        }

        // Loop through all entries
        Console.WriteLine("\nAll Grades:");
        foreach (var entry in grades)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value}");
        }

        // Just keys or just values
        Console.WriteLine("\nJust the names:");
        foreach (string name in grades.Keys)
        {
            Console.Write($"{name} ");
        }
        Console.WriteLine("\n");

        // Dictionary with different types
        Dictionary<int, string> errorCodes = new Dictionary<int, string>
        {
            { 404, "Not Found" },
            { 500, "Server Error" },
            { 200, "OK" }
        };

        Console.WriteLine($"Error 404 means: {errorCodes[404]}");
        Console.WriteLine();
    }


    // ============================================
    // DEMO 5: Basic try-catch
    // ============================================
    static void Demo5_BasicTryCatch()
    {
        Console.WriteLine("▶ DEMO 5: Basic try-catch");
        Console.WriteLine("─────────────────────────────────────\n");

        Console.Write("Enter a number to divide 100 by: ");
        string input = Console.ReadLine();

        try
        {
            // This code might throw an exception
            int number = int.Parse(input);
            int result = 100 / number;
            Console.WriteLine($"100 divided by {number} = {result}");
        }
        catch (FormatException)
        {
            // Runs if input wasn't a valid number
            Console.WriteLine("❌ That's not a valid number!");
        }
        catch (DivideByZeroException)
        {
            // Runs if user entered 0
            Console.WriteLine("❌ Cannot divide by zero!");
        }

        Console.WriteLine("✓ Program continues running...\n");
    }


    // ============================================
    // DEMO 6: Using the Exception Object
    // ============================================
    static void Demo6_ExceptionObject()
    {
        Console.WriteLine("▶ DEMO 6: The Exception Object");
        Console.WriteLine("─────────────────────────────────────\n");

        int[] numbers = { 10, 20, 30 };

        Console.WriteLine("Attempting to access numbers[10]...");
        try
        {
            Console.WriteLine(numbers[10]);  // Invalid index!
        }
        catch (IndexOutOfRangeException ex)
        {
            // 'ex' is the exception object - it has useful information!
            Console.WriteLine($"❌ Error Type: {ex.GetType().Name}");
            Console.WriteLine($"   Message: {ex.Message}");
        }

        Console.WriteLine("\nAttempting to use a null string...");
        try
        {
            string text = null;
            Console.WriteLine(text.Length);  // null reference!
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"❌ Error Type: {ex.GetType().Name}");
            Console.WriteLine($"   Message: {ex.Message}");
        }

        Console.WriteLine("\n--- Catch-All Pattern ---");
        try
        {
            // Simulating unknown error
            throw new InvalidOperationException("Something unexpected!");
        }
        catch (Exception ex)  // 'Exception' catches EVERYTHING
        {
            Console.WriteLine($"Caught: {ex.GetType().Name}");
            Console.WriteLine($"Message: {ex.Message}");
        }

        Console.WriteLine();
    }


    // ============================================
    // DEMO 7: The finally Block
    // ============================================
    static void Demo7_FinallyBlock()
    {
        Console.WriteLine("▶ DEMO 7: try-catch-finally");
        Console.WriteLine("─────────────────────────────────────\n");

        Console.WriteLine("=== Test 1: Exception occurs ===");
        try
        {
            Console.WriteLine("  Attempting risky operation...");
            int result = 10 / 0;  // This will throw!
            Console.WriteLine("  Operation completed.");  // Won't run
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("  ❌ Error caught: Cannot divide by zero");
        }
        finally
        {
            // This ALWAYS runs - even if there was an exception
            Console.WriteLine("  🧹 Cleanup: finally block executed");
        }

        Console.WriteLine("\n=== Test 2: No exception ===");
        try
        {
            Console.WriteLine("  Attempting safe operation...");
            int result = 10 / 2;
            Console.WriteLine($"  Operation completed. Result = {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("  ❌ Error caught: Cannot divide by zero");
        }
        finally
        {
            // Still runs even when there's no exception!
            Console.WriteLine("  🧹 Cleanup: finally block executed");
        }

        Console.WriteLine("\n✓ Program continues...\n");
    }
}


/*
 * ============================================
 * SUMMARY - Key Concepts to Remember:
 * ============================================
 * 
 * ARRAYS:
 *   int[] arr = { 1, 2, 3 };        // Initialize with values
 *   int[] arr = new int[5];         // Fixed size, default values
 *   arr.Length                       // Number of elements
 *   arr[0]                           // First element (zero-indexed!)
 * 
 * LISTS (using System.Collections.Generic):
 *   List<string> list = new List<string>();
 *   list.Add("item");               // Add to end
 *   list.Remove("item");            // Remove first match
 *   list.Insert(0, "item");         // Insert at position
 *   list.Contains("item")           // Check if exists
 *   list.Count                      // Number of elements
 * 
 * DICTIONARIES:
 *   Dictionary<string, int> dict = new Dictionary<string, int>();
 *   dict["key"] = 42;               // Add or update
 *   dict.ContainsKey("key")         // Check if key exists
 *   dict.TryGetValue("key", out val) // Safe lookup
 *   foreach (var kvp in dict)       // Loop through pairs
 * 
 * EXCEPTION HANDLING:
 *   try {
 *       // Code that might fail
 *   }
 *   catch (SpecificException ex) {
 *       // Handle specific error
 *       Console.WriteLine(ex.Message);
 *   }
 *   catch (Exception ex) {
 *       // Catch-all (use last)
 *   }
 *   finally {
 *       // Always runs (cleanup)
 *   }
 * 
 * COMMON EXCEPTIONS:
 *   - FormatException: Can't parse string to number
 *   - IndexOutOfRangeException: Array index doesn't exist
 *   - NullReferenceException: Using null object
 *   - DivideByZeroException: Dividing int by zero
 *   - KeyNotFoundException: Dictionary key doesn't exist
 */
