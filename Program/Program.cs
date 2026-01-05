/*
Unit 01 - Setup & First Console App - Block 01 - U1B1
Pair Programming Lab: Hello, Console! (Methods + Console Output)

Names: ______________________  ______________________  (______________________)

Instructions:
- Complete each TODO.
- Run after each method to test.
- Use parameters + return whenever possible.
- DO NOT delete the Test Zone.

Roles (switch halfway)
Driver: types, runs the code, shares screen/keyboard
Navigator: reads instructions, watches for mistakes, explains “why”
(Optional 3rd) Coach: checks requirements, tests edge cases, keeps time

0–3 min: Assign roles, open Program.cs, run once (expect failures).
3–15 min: Complete Parts A–C + run tests after each method.
15 min: Switch Driver/Navigator.
15–25 min: Complete Parts D–E.
25–30 min: Clean up: confirm all tests run, add names, push to GitHub.

Each person will turn in a complete copy. So make sure all work is present for both students.
When finished, turn this in on GitHub and Canvas.

This portion is worth 15 points.
*/

using System;

public class Program
{
    // =========================================================
    // PART A: Warm-up Methods (Console Output + Returns)
    // =========================================================

    // ---------------------------------------------------------
    // 1) PrintBanner()
    // Prints a simple 3-line banner to the console.
    // Example:
    // =========================
    //       U1B1 READY
    // =========================
    // ---------------------------------------------------------
    public static void PrintBanner()
    {
        // TODO: Print the banner exactly like the example above.
    }

    // ---------------------------------------------------------
    // 2) SayHello(name)
    // Prints: Hello, <name>!
    // Example: SayHello("Nick") prints "Hello, Nick!"
    // ---------------------------------------------------------
    public static void SayHello(string name)
    {
        // TODO: Print greeting exactly like: Hello, Nick!
    }

    // ---------------------------------------------------------
    // 3) AddNumbers(a, b)
    // Returns the sum of a and b
    // ---------------------------------------------------------
    public static int AddNumbers(int a, int b)
    {
        // TODO: return the sum
        return 0;
    }

    // ---------------------------------------------------------
    // 4) Multiply(a, b)
    // Returns the product of a and b
    // ---------------------------------------------------------
    public static int Multiply(int a, int b)
    {
        // TODO: return the product
        return 0;
    }


    // =========================================================
    // PART B: Return vs Print
    // =========================================================

    // ---------------------------------------------------------
    // 5) DoubleValue(x)
    // Returns x * 2 (DO NOT print inside this method)
    // ---------------------------------------------------------
    public static int DoubleValue(int x)
    {
        // TODO: return x * 2
        return 0;
    }

    // ---------------------------------------------------------
    // 6) ReportDouble(x)
    // Prints: Double of 7 is 14
    // Must use DoubleValue(x) inside it
    // ---------------------------------------------------------
    public static void ReportDouble(int x)
    {
        // TODO: call DoubleValue(x) and print the message
    }


    // =========================================================
    // PART C: Mini Challenge (Make it Useful)
    // =========================================================

    // ---------------------------------------------------------
    // 7) FahrenheitToCelsius(f)
    // Returns Celsius using: (f - 32) * 5/9
    // ---------------------------------------------------------
    public static double FahrenheitToCelsius(double f)
    {
        // TODO: return the Celsius conversion
        return 0.0;
    }

    // ---------------------------------------------------------
    // 8) IsEven(n)
    // Returns true if n is even, otherwise false
    // ---------------------------------------------------------
    public static bool IsEven(int n)
    {
        // TODO: return true/false using modulo (%)
        return false;
    }


    // =========================================================
    // PART D: Scope Puzzle (No try/catch)
    // =========================================================

    // ---------------------------------------------------------
    // 9) MakeUsername(first, last)
    // Returns: first initial + last name, all lowercase
    // Example: MakeUsername("Ada", "Lovelace") -> "alovelace"
    //
    // NOTE: Do NOT use global variables.
    // ---------------------------------------------------------
    public static string MakeUsername(string first, string last)
    {
        // TODO: return the username
        return "";
    }

    // ---------------------------------------------------------
    // 10) AddTax(price, taxRate)
    // Returns total price after tax.
    // Example: AddTax(10.00m, 0.07m) -> 10.70m
    //
    // NOTE: taxRate must be a parameter (not global).
    // Use decimal for money.
    // ---------------------------------------------------------
    public static decimal AddTax(decimal price, decimal taxRate)
    {
        // TODO: return total
        return 0m;
    }


    // =========================================================
    // PART E: Final Team Challenge (1 method, 3 tests)
    // =========================================================

    // ---------------------------------------------------------
    // 11) DescribeNumber(n)
    // Returns a STRING description:
    // - "even" or "odd"
    // - and "positive", "negative", or "zero"
    //
    // Examples:
    // DescribeNumber(6)   -> "even positive"
    // DescribeNumber(-3)  -> "odd negative"
    // DescribeNumber(0)   -> "even zero"   (0 is even)
    //
    // Requirements:
    // - Must use IsEven(n) inside this method
    // - Must return a string (do not print inside)
    // ---------------------------------------------------------
    public static string DescribeNumber(int n)
    {
        // TODO: build and return the description string
        return "";
    }


    // ============================
    // TEST ZONE (Do not delete)
    // ============================
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=== PART A: Warm-up Methods ===\n");

        PrintBanner();

        SayHello("Nick");
        SayHello("Ada");

        Console.WriteLine("AddNumbers(3, 4) = " + AddNumbers(3, 4));
        Console.WriteLine("AddNumbers(-2, 10) = " + AddNumbers(-2, 10));

        Console.WriteLine("Multiply(3, 5) = " + Multiply(3, 5));
        Console.WriteLine("Multiply(-2, 8) = " + Multiply(-2, 8));


        Console.WriteLine("\n=== PART B: Return vs Print ===\n");

        Console.WriteLine("DoubleValue(7) = " + DoubleValue(7));
        Console.WriteLine("DoubleValue(0) = " + DoubleValue(0));
        ReportDouble(7);
        ReportDouble(12);


        Console.WriteLine("\n=== PART C: Mini Challenge ===\n");

        Console.WriteLine("FahrenheitToCelsius(68) = " + FahrenheitToCelsius(68));
        Console.WriteLine("FahrenheitToCelsius(32) = " + FahrenheitToCelsius(32));

        Console.WriteLine("IsEven(10) = " + IsEven(10));
        Console.WriteLine("IsEven(7) = " + IsEven(7));


        Console.WriteLine("\n=== PART D: Scope Puzzle ===\n");

        Console.WriteLine("MakeUsername(\"Ada\", \"Lovelace\") = " + MakeUsername("Ada", "Lovelace"));
        Console.WriteLine("MakeUsername(\"Grace\", \"Hopper\") = " + MakeUsername("Grace", "Hopper"));

        Console.WriteLine("AddTax(10.00m, 0.07m) = " + AddTax(10.00m, 0.07m));
        Console.WriteLine("AddTax(50.00m, 0.05m) = " + AddTax(50.00m, 0.05m));


        Console.WriteLine("\n=== PART E: Final Team Challenge ===\n");

        // Part E tests (3 required)
        Console.WriteLine("DescribeNumber(6) = " + DescribeNumber(6));
        Console.WriteLine("DescribeNumber(-3) = " + DescribeNumber(-3));
        Console.WriteLine("DescribeNumber(0) = " + DescribeNumber(0));
    }
}
