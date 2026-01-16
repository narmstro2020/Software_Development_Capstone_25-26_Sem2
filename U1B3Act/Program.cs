using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== StringsIO Micro Adventure ===\n");

        // ------------------------------------------------------------
        // PART A: Output Basics (Write vs WriteLine)
        // Goal: Show the difference between Console.Write and Console.WriteLine
        // ------------------------------------------------------------

        // TODO A1: Print "Loading" WITHOUT a newline (use Console.Write)
        // TODO A2: Then print "..." WITH a newline (use Console.WriteLine)
        // TODO A3: Print a blank line

        // Quick check (expected style):
        // Loading...
        // (blank line)


        // ------------------------------------------------------------
        // PART B: ReadLine + Cleaning Input (Trim + ToLower/ToUpper)
        // Goal: Read a name, clean it, and display it nicely
        // ------------------------------------------------------------

        Console.Write("Enter your hero name: ");
        string rawName = Console.ReadLine();

        // TODO B1: Create a cleanedName that trims whitespace
        // HINT: rawName.Trim()

        // TODO B2: Create a shoutName that is cleanedName in ALL CAPS
        // HINT: cleanedName.ToUpper()

        // TODO B3: Use string interpolation to print:
        // "Welcome, <cleanedName>!"
        // and then:
        // "BATTLE CRY: <shoutName>!"
        //
        // HINT: $"Welcome, {cleanedName}!"

        // Mini edge case (don’t overthink): if rawName is null, treat as "Player"
        // TODO B4 (optional): If rawName is null, set cleanedName to "Player"


        // ------------------------------------------------------------
        // PART C: Concatenation vs Interpolation
        // Goal: Convert concatenation into interpolation
        // ------------------------------------------------------------

        int score = 7;

        // This line works, but uses concatenation:
        string msgConcat = "Robo score: " + score;

        // TODO C1: Create msgInterp that produces the SAME output using interpolation.
        // Example result: "Robo score: 7"

        // TODO C2: Print BOTH messages on separate lines so you can compare them.

        // Quick check: both lines should look identical.


        // ------------------------------------------------------------
        // PART D: Escape Sequences + Verbatim Strings
        // Goal: Make a “sign” that uses quotes, tabs, and newlines
        // ------------------------------------------------------------

        // TODO D1: Print this EXACT text using escape sequences:
        //
        // The tavern sign reads:
        //     "NO BUGS ALLOWED"
        //
        // Requirements:
        // - Use \n for newline
        // - Use \t for the indent
        // - Use \" for the quotes

        // TODO D2: Now print a Windows-style path using a VERBATIM string:
        // C:\Games\Unity\Projects\CAP
        //
        // HINT: @"C:\Games\Unity\Projects\CAP"


        // ------------------------------------------------------------
        // PART E: Numbers From Text (int.TryParse) + Light Branching
        // Goal: Ask for an age (or level), safely convert it, and respond.
        // ------------------------------------------------------------

        Console.Write("\nEnter your level (whole number): ");
        string levelText = Console.ReadLine();

        // TODO E1: Use int.TryParse to attempt converting levelText into an int named level.
        // Also store the bool result in a variable named ok.
        //
        // Pattern:
        // bool ok = int.TryParse(levelText, out int level);

        // TODO E2: If ok is true, print:
        // $"Level accepted: {level}"
        //
        // TODO E3: If ok is false, print:
        // "Invalid number. Try again."
        //
        // NOTE: We’re using if/else just a tiny bit here; we’ll go deeper next block.

        // TODO E4 (challenge): If ok is true, also print a “status line” like:
        // $"STATUS\tName: {cleanedName}\tLevel: {level}\tScore: {score}"
        // (Use \t tabs between the labels)

        Console.WriteLine("\n=== End ===");
    }
}
