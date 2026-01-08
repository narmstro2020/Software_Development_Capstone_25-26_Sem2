/*
Unit 01 - Setup & First Console App - Block 01 - U1B1
Pair Programming Lab: Build a Student Class (C# OOP Intro)

Names: ______________________  ______________________  (______________________)

Instructions:
- Complete each TODO.
- Run after each change to test.
- Follow the method/field requirements exactly.
- DO NOT delete or rename the Test Zone calls.

Roles (switch halfway)
Driver: types, runs the code, shares screen/keyboard
Navigator: reads instructions, watches for mistakes, explains “why”
(Optional 3rd) Coach: checks requirements, tests edge cases, keeps time

0–3 min: Assign roles, open Program.cs, run once (expect failures).
3–15 min: Complete Parts A–C + run tests after each TODO.
15 min: Switch Driver/Navigator.
15–25 min: Complete Parts D–E.
25–30 min: Clean up: confirm all tests run, add names, push to GitHub.

Each person will turn in a complete copy. So make sure all work is present for both students.
When finished, turn this in on GitHub and Canvas.

This portion is worth 15 points.
*/

namespace _02_Simple_C_Sharp_Class
{
    public class Program
    {
        // =========================================================
        // PART A: Create the Student class (Fields + Constructors)
        // =========================================================
        //
        // Requirements for class Student:
        //
        // Fields (PRIVATE):
        // - string firstName
        // - string lastName
        // - int gradeLevel          (9–12 only)
        // - double gpa              (0.0–4.0)
        // - int creditsEarned       (0+)
        //
        // Constructors:
        // 1) Student(string firstName, string lastName, int gradeLevel)
        //    - sets gpa = 0.0 and creditsEarned = 0
        //    - must validate gradeLevel (9–12); if invalid, set to 9
        //
        // 2) Student(string firstName, string lastName, int gradeLevel, double gpa, int creditsEarned)
        //    - must validate gradeLevel, gpa, creditsEarned
        //    - if invalid:
        //        gradeLevel -> set to 9
        //        gpa -> clamp to range 0.0–4.0
        //        creditsEarned -> set to 0 if negative
        //
        // NOTE: Use "this." to set fields.
        //

        // TODO: Create the Student class BELOW Program (at the bottom of this file).


        // =========================================================
        // PART B: Add Methods (Getters/Setters + Useful Behaviors)
        // =========================================================
        //
        // Methods required in Student:
        //
        // - string GetFullName()
        //      returns "First Last"
        //
        // - string GetEmail(string domain)
        //      returns: first initial + last name + gradeLevel + "@" + domain
        //      all lowercase, no spaces
        //      Example: Ada Lovelace, grade 11, domain "school.org" -> "alovelace11@school.org"
        //
        // - bool IsOnHonorRoll()
        //      returns true if gpa >= 3.5
        //
        // - void AddCredits(int amount)
        //      adds credits if amount > 0
        //
        // - void UpdateGpa(double newGpa)
        //      sets gpa to newGpa but clamped 0.0–4.0
        //
        // - void Promote()
        //      increases gradeLevel by 1 (max 12)
        //
        // - string GetSummary()
        //      returns a single-line summary like:
        //      "Ada Lovelace | Grade: 11 | GPA: 3.90 | Credits: 18"
        //      GPA should show 2 decimal places.
        //

        // =========================================================
        // PART C: Console Output Practice (Use the class)
        // =========================================================
        //
        // In Main, you will:
        // - Create at least 2 Student objects using different constructors
        // - Call methods and print results
        // - Demonstrate that validation/clamping works
        //

        // ============================
        // TEST ZONE (Do not delete)
        // ============================
        public static void Main(string[] args)
        {
            Console.WriteLine("\n=== U1B1 Student Class Lab ===\n");

            // ------------------------------------------------------------
            // Create students (these lines should work when you're done)
            // ------------------------------------------------------------
            Student s1 = new Student("Ada", "Lovelace", 11);
            Student s2 = new Student("Grace", "Hopper", 13, 4.7, -5); // intentionally invalid values

            // ------------------------------------------------------------
            // Basic info
            // ------------------------------------------------------------
            Console.WriteLine("s1 full name: " + s1.GetFullName());
            Console.WriteLine("s2 full name: " + s2.GetFullName());

            // ------------------------------------------------------------
            // Email creation
            // ------------------------------------------------------------
            Console.WriteLine("s1 email: " + s1.GetEmail("school.org"));
            Console.WriteLine("s2 email: " + s2.GetEmail("school.org"));

            // ------------------------------------------------------------
            // GPA / Honor Roll
            // ------------------------------------------------------------
            s1.UpdateGpa(3.9);
            s2.UpdateGpa(2.4);

            Console.WriteLine("s1 honor roll? " + s1.IsOnHonorRoll()); // expected: True
            Console.WriteLine("s2 honor roll? " + s2.IsOnHonorRoll()); // expected: False

            // ------------------------------------------------------------
            // Credits
            // ------------------------------------------------------------
            s1.AddCredits(6);
            s1.AddCredits(-3); // should be ignored
            s2.AddCredits(18);

            // ------------------------------------------------------------
            // Promote grade
            // ------------------------------------------------------------
            s1.Promote(); // 11 -> 12
            s1.Promote(); // stays 12
            s2.Promote(); // if s2 got clamped to 9, becomes 10

            // ------------------------------------------------------------
            // Summaries
            // ------------------------------------------------------------
            Console.WriteLine("\n--- Summaries ---");
            Console.WriteLine(s1.GetSummary());
            Console.WriteLine(s2.GetSummary());

            // ------------------------------------------------------------
            // Extra validation demo
            // ------------------------------------------------------------
            Console.WriteLine("\n--- Validation Checks ---");
            Student s3 = new Student("Alan", "Turing", 8); // invalid grade -> becomes 9
            Student s4 = new Student("Katherine", "Johnson", 12, -1.2, 12); // gpa -> clamps to 0.0
            Student s5 = new Student("Tim", "Berners-Lee", 10, 3.3333, 0);

            Console.WriteLine(s3.GetSummary());
            Console.WriteLine(s4.GetSummary());
            Console.WriteLine(s5.GetSummary());

            Console.WriteLine("\n=== DONE (If everything printed nicely, you win) ===\n");
        }
    }

// =========================================================
// TODO: Implement Student class here
// =========================================================
    public class Student
    {
        // -------------------------
        // Fields (PRIVATE)
        // -------------------------
        // TODO: add private fields listed in Part A

        // -------------------------
        // Constructors
        // -------------------------
        // TODO: implement both constructors with validation

        // -------------------------
        // Methods
        // -------------------------
        // TODO: implement methods listed in Part B
    }
}