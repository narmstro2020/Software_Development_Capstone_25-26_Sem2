/**
 * ============================================
 * Task Manager App - Student Activity
 * ============================================
 * 
 * Your Task: Complete this console application!
 * You'll build a task manager using:
 *   - List<T> to store tasks dynamically
 *   - Dictionary<K,V> for priority mapping
 *   - try-catch for error handling
 * 
 * Look for TODO comments to find where you need to write code.
 * Run with Ctrl+F5 in Visual Studio, or 'dotnet run' in terminal.
 */

using System;
using System.Collections.Generic;
using System.Linq; // For LINQ methods like FirstOrDefault (optional)

class TaskManager
{
    // ============================================
    // Task class - represents a single task
    // This is already complete - don't modify!
    // ============================================
    class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        
        // Auto-increment ID
        private static int nextId = 1;
        
        public Task(string description, int priority)
        {
            Id = nextId++;
            Description = description;
            Priority = priority;
            IsComplete = false;
        }
    }
    
    
    // ============================================
    // TODO #1: Initialize your collections here
    // ============================================
    // Create these two class-level variables:
    //   1. A List<Task> to store all tasks
    //   2. A Dictionary<int, string> to map priority numbers (1,2,3) to names ("Low","Medium","High")
    //
    // EXAMPLE from notes:
    //   List<string> items = new List<string>();
    //   Dictionary<int, string> mapping = new Dictionary<int, string>
    //   {
    //       { 1, "Value1" }, { 2, "Value2" }
    //   };
    
    // YOUR CODE HERE:
    
    

    // ============================================
    // Main Program - Menu loop (partially complete)
    // ============================================
    static void Main(string[] args)
    {
        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            
            // ============================================
            // TODO #6: Add try-catch for menu input
            // ============================================
            // Wrap the parsing and switch in try-catch
            // to handle non-numeric input gracefully.
            // 
            // HINT: catch (FormatException) { ... }
            
            Console.Write("Enter choice (1-6): ");
            string input = Console.ReadLine();
            
            // YOUR CODE HERE - wrap in try-catch:
            int choice = int.Parse(input);
            
            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    ViewAllTasks();
                    break;
                case 3:
                    MarkTaskComplete();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    ViewByPriority();
                    break;
                case 6:
                    running = false;
                    Console.WriteLine("\n👋 Goodbye! Stay organized!");
                    break;
                default:
                    Console.WriteLine("\n❌ Invalid choice. Please enter 1-6.");
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
        Console.WriteLine("          📋 TASK MANAGER");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("  1. Add a new task");
        Console.WriteLine("  2. View all tasks");
        Console.WriteLine("  3. Mark task as complete");
        Console.WriteLine("  4. Delete a task");
        Console.WriteLine("  5. View tasks by priority");
        Console.WriteLine("  6. Exit");
        Console.WriteLine();
    }
    
    
    // ============================================
    // TODO #2: Add Task Method
    // ============================================
    static void AddTask()
    {
        Console.WriteLine("\n--- Add New Task ---");
        
        // Step 1: Get the task description
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        
        // Check for empty description
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("❌ Description cannot be empty!");
            return;
        }
        
        // Step 2: Get and validate the priority
        Console.Write("Enter priority (1=Low, 2=Medium, 3=High): ");
        string priorityInput = Console.ReadLine();
        
        // TODO: Parse the priority input safely
        // Use int.TryParse() to convert the string to an int
        // If parsing fails OR the priority is not 1, 2, or 3, show an error and return
        //
        // HINT from notes:
        //   if (int.TryParse(input, out int result))
        //   {
        //       // Parsing succeeded, use 'result'
        //   }
        //   else
        //   {
        //       // Parsing failed
        //   }
        
        // YOUR CODE HERE:
        
        
        // TODO: Create a new Task and add it to the list
        // HINT: Task newTask = new Task(description, priority);
        //       tasks.Add(newTask);
        
        // YOUR CODE HERE:
        
        
        // TODO: Print success message
        // Show: ✅ Task added: "description" (Priority: priorityName)
        // HINT: Use the priorities dictionary to get the priority name
        //       priorities[priority] gives you "Low", "Medium", or "High"
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // TODO #3: View All Tasks
    // ============================================
    static void ViewAllTasks()
    {
        Console.WriteLine("\n--- All Tasks ---");
        
        // TODO: Check if the list is empty
        // If empty, print "No tasks yet! Add some tasks to get started."
        // and return early
        //
        // HINT: if (tasks.Count == 0) { ... }
        
        // YOUR CODE HERE:
        
        
        // TODO: Loop through all tasks and display them
        // For each task, display:
        //   - ID
        //   - Description  
        //   - Priority (use the dictionary to get the name)
        //   - Status (show ✅ if complete, ⬜ if not)
        //
        // Example output:
        //   [1] ⬜ Finish homework (High)
        //   [2] ✅ Buy groceries (Low)
        //
        // HINT from notes:
        //   foreach (var task in tasks)
        //   {
        //       string status = task.IsComplete ? "✅" : "⬜";
        //       string priorityName = priorities[task.Priority];
        //       Console.WriteLine($"[{task.Id}] {status} {task.Description} ({priorityName})");
        //   }
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // TODO #4: Mark Task Complete
    // ============================================
    static void MarkTaskComplete()
    {
        Console.WriteLine("\n--- Mark Task Complete ---");
        
        // First, show all tasks so user can see IDs
        ViewAllTasks();
        
        // TODO: If there are no tasks, return early (ViewAllTasks already handles display)
        // HINT: if (tasks.Count == 0) return;
        
        // YOUR CODE HERE:
        
        
        Console.Write("\nEnter task ID to mark complete: ");
        string input = Console.ReadLine();
        
        // TODO: Parse the ID and find the task
        // Use try-catch to handle invalid input
        // 
        // Option A (using loop):
        //   Task found = null;
        //   foreach (var task in tasks)
        //   {
        //       if (task.Id == id)
        //       {
        //           found = task;
        //           break;
        //       }
        //   }
        //
        // Option B (using LINQ - requires 'using System.Linq;'):
        //   Task found = tasks.FirstOrDefault(t => t.Id == id);
        //
        // Then check if found is null (task doesn't exist) or mark it complete
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // TODO #5: Delete Task
    // ============================================
    static void DeleteTask()
    {
        Console.WriteLine("\n--- Delete Task ---");
        
        // Show all tasks first
        ViewAllTasks();
        
        // TODO: If there are no tasks, return early
        
        // YOUR CODE HERE:
        
        
        Console.Write("\nEnter task ID to delete: ");
        string input = Console.ReadLine();
        
        // TODO: Parse the ID and remove the task
        // Use try-catch to handle invalid input
        //
        // HINT: list.RemoveAll(t => t.Id == id) returns the number of items removed
        //       If 0 items were removed, the task wasn't found
        //
        // Alternative using loop:
        //   Task toRemove = null;
        //   foreach (var task in tasks)
        //   {
        //       if (task.Id == id)
        //       {
        //           toRemove = task;
        //           break;
        //       }
        //   }
        //   if (toRemove != null)
        //   {
        //       tasks.Remove(toRemove);
        //       Console.WriteLine("✅ Task deleted!");
        //   }
        
        // YOUR CODE HERE:
        
    }
    
    
    // ============================================
    // BONUS: View Tasks by Priority
    // ============================================
    static void ViewByPriority()
    {
        Console.WriteLine("\n--- View by Priority ---");
        Console.Write("Enter priority to filter (1=Low, 2=Medium, 3=High): ");
        string input = Console.ReadLine();
        
        // BONUS TODO: Parse the priority and show only matching tasks
        // 
        // HINT using loop:
        //   foreach (var task in tasks)
        //   {
        //       if (task.Priority == priority)
        //       {
        //           // display task
        //       }
        //   }
        //
        // HINT using LINQ:
        //   var filtered = tasks.Where(t => t.Priority == priority);
        //   foreach (var task in filtered) { ... }
        
        // YOUR CODE HERE:
        Console.WriteLine("🚧 Bonus feature - implement if you have time!");
    }
}


/*
 * ============================================
 * QUICK REFERENCE - Copy from here!
 * ============================================
 * 
 * LIST OPERATIONS:
 *   List<Task> tasks = new List<Task>();
 *   tasks.Add(newTask);           // Add item
 *   tasks.Remove(task);           // Remove specific item
 *   tasks.RemoveAll(t => t.Id == 5);  // Remove by condition
 *   tasks.Count                   // Number of items
 *   tasks.Clear();                // Remove all
 * 
 * DICTIONARY OPERATIONS:
 *   Dictionary<int, string> priorities = new Dictionary<int, string>
 *   {
 *       { 1, "Low" }, { 2, "Medium" }, { 3, "High" }
 *   };
 *   priorities[1]                 // Returns "Low"
 *   priorities.ContainsKey(5)     // Returns false
 * 
 * SAFE PARSING:
 *   if (int.TryParse(input, out int result))
 *   {
 *       // Success - use 'result'
 *   }
 *   else
 *   {
 *       // Failed - show error
 *   }
 * 
 * TRY-CATCH:
 *   try
 *   {
 *       int num = int.Parse(input);  // Might throw
 *   }
 *   catch (FormatException)
 *   {
 *       Console.WriteLine("Invalid number!");
 *   }
 * 
 * FINDING ITEMS:
 *   // Using loop:
 *   Task found = null;
 *   foreach (var t in tasks)
 *   {
 *       if (t.Id == id) { found = t; break; }
 *   }
 *   
 *   // Using LINQ (add 'using System.Linq;'):
 *   Task found = tasks.FirstOrDefault(t => t.Id == id);
 */
