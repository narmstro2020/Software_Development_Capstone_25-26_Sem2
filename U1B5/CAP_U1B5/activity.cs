/**
 * ============================================
 * Task Manager App - SOLUTION
 * ============================================
 * 
 * This is the complete solution for the Task Manager activity.
 * Students should only look at this if they get stuck!
 */

using System;
using System.Collections.Generic;
using System.Linq;

class TaskManager
{
    // ============================================
    // Task class - represents a single task
    // ============================================
    class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        
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
    // TODO #1: SOLUTION - Collections initialized
    // ============================================
    static List<Task> tasks = new List<Task>();
    
    static Dictionary<int, string> priorities = new Dictionary<int, string>
    {
        { 1, "Low" },
        { 2, "Medium" },
        { 3, "High" }
    };
    

    // ============================================
    // Main Program with try-catch
    // ============================================
    static void Main(string[] args)
    {
        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            
            Console.Write("Enter choice (1-6): ");
            string input = Console.ReadLine();
            
            // TODO #6: SOLUTION - try-catch for menu input
            try
            {
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
            }
            catch (FormatException)
            {
                Console.WriteLine("\n❌ Please enter a valid number (1-6).");
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
    // TODO #2: SOLUTION - Add Task
    // ============================================
    static void AddTask()
    {
        Console.WriteLine("\n--- Add New Task ---");
        
        // Get description
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("❌ Description cannot be empty!");
            return;
        }
        
        // Get and validate priority
        Console.Write("Enter priority (1=Low, 2=Medium, 3=High): ");
        string priorityInput = Console.ReadLine();
        
        // Safe parsing with TryParse
        if (int.TryParse(priorityInput, out int priority))
        {
            // Check if priority is valid (1, 2, or 3)
            if (priority < 1 || priority > 3)
            {
                Console.WriteLine("❌ Priority must be 1, 2, or 3!");
                return;
            }
            
            // Create and add the task
            Task newTask = new Task(description, priority);
            tasks.Add(newTask);
            
            // Show success message
            string priorityName = priorities[priority];
            Console.WriteLine($"\n✅ Task added: \"{description}\" (Priority: {priorityName})");
        }
        else
        {
            Console.WriteLine("❌ Invalid priority! Please enter 1, 2, or 3.");
        }
    }
    
    
    // ============================================
    // TODO #3: SOLUTION - View All Tasks
    // ============================================
    static void ViewAllTasks()
    {
        Console.WriteLine("\n--- All Tasks ---");
        
        // Check if empty
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet! Add some tasks to get started.");
            return;
        }
        
        // Display all tasks
        Console.WriteLine();
        foreach (var task in tasks)
        {
            string status = task.IsComplete ? "✅" : "⬜";
            string priorityName = priorities[task.Priority];
            Console.WriteLine($"  [{task.Id}] {status} {task.Description} ({priorityName})");
        }
        Console.WriteLine();
    }
    
    
    // ============================================
    // TODO #4: SOLUTION - Mark Task Complete
    // ============================================
    static void MarkTaskComplete()
    {
        Console.WriteLine("\n--- Mark Task Complete ---");
        
        ViewAllTasks();
        
        if (tasks.Count == 0) return;
        
        Console.Write("Enter task ID to mark complete: ");
        string input = Console.ReadLine();
        
        try
        {
            int id = int.Parse(input);
            
            // Find the task (using LINQ)
            Task found = tasks.FirstOrDefault(t => t.Id == id);
            
            // Alternative using loop:
            // Task found = null;
            // foreach (var task in tasks)
            // {
            //     if (task.Id == id)
            //     {
            //         found = task;
            //         break;
            //     }
            // }
            
            if (found != null)
            {
                if (found.IsComplete)
                {
                    Console.WriteLine("ℹ️ Task is already complete!");
                }
                else
                {
                    found.IsComplete = true;
                    Console.WriteLine($"✅ Task \"{found.Description}\" marked as complete!");
                }
            }
            else
            {
                Console.WriteLine($"❌ Task with ID {id} not found.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Please enter a valid task ID (number).");
        }
    }
    
    
    // ============================================
    // TODO #5: SOLUTION - Delete Task
    // ============================================
    static void DeleteTask()
    {
        Console.WriteLine("\n--- Delete Task ---");
        
        ViewAllTasks();
        
        if (tasks.Count == 0) return;
        
        Console.Write("Enter task ID to delete: ");
        string input = Console.ReadLine();
        
        try
        {
            int id = int.Parse(input);
            
            // Option 1: Using RemoveAll (returns count of removed items)
            int removed = tasks.RemoveAll(t => t.Id == id);
            
            if (removed > 0)
            {
                Console.WriteLine("✅ Task deleted successfully!");
            }
            else
            {
                Console.WriteLine($"❌ Task with ID {id} not found.");
            }
            
            // Alternative using loop:
            // Task toRemove = null;
            // foreach (var task in tasks)
            // {
            //     if (task.Id == id)
            //     {
            //         toRemove = task;
            //         break;
            //     }
            // }
            // if (toRemove != null)
            // {
            //     tasks.Remove(toRemove);
            //     Console.WriteLine("✅ Task deleted!");
            // }
            // else
            // {
            //     Console.WriteLine("❌ Task not found.");
            // }
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Please enter a valid task ID (number).");
        }
    }
    
    
    // ============================================
    // BONUS: SOLUTION - View Tasks by Priority
    // ============================================
    static void ViewByPriority()
    {
        Console.WriteLine("\n--- View by Priority ---");
        Console.Write("Enter priority to filter (1=Low, 2=Medium, 3=High): ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int priority))
        {
            if (priority < 1 || priority > 3)
            {
                Console.WriteLine("❌ Priority must be 1, 2, or 3!");
                return;
            }
            
            string priorityName = priorities[priority];
            Console.WriteLine($"\n--- {priorityName} Priority Tasks ---\n");
            
            // Using LINQ
            var filtered = tasks.Where(t => t.Priority == priority);
            
            // Alternative using loop:
            // List<Task> filtered = new List<Task>();
            // foreach (var task in tasks)
            // {
            //     if (task.Priority == priority)
            //     {
            //         filtered.Add(task);
            //     }
            // }
            
            if (!filtered.Any())
            {
                Console.WriteLine($"No {priorityName.ToLower()} priority tasks.");
                return;
            }
            
            foreach (var task in filtered)
            {
                string status = task.IsComplete ? "✅" : "⬜";
                Console.WriteLine($"  [{task.Id}] {status} {task.Description}");
            }
        }
        else
        {
            Console.WriteLine("❌ Please enter a valid priority (1, 2, or 3).");
        }
    }
}


/*
 * ============================================
 * BONUS EXTENSION IDEAS:
 * ============================================
 * 
 * 1. Task Statistics:
 *    - Total tasks
 *    - Completed vs incomplete count
 *    - Tasks per priority level
 * 
 * 2. Due Dates:
 *    - Add a DueDate property to Task
 *    - Show overdue tasks
 * 
 * 3. Search:
 *    - Search tasks by keyword in description
 * 
 * 4. Save/Load:
 *    - Save tasks to a file
 *    - Load tasks when program starts
 * 
 * 5. Edit Task:
 *    - Change description
 *    - Change priority
 */
