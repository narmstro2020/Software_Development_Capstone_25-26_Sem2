namespace U1B4Activity;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== CAP_U1B4: Decision Dungeon ===");

        // ============================================================
        // PART A (Warm-up): Bool + if/else basics (3–8 min)
        // ============================================================
        Console.WriteLine("\n--- PART A: Number Classifier ---");

        // TODO A1: Ask the user for an integer (as a string).
        //          Use TryParse. If invalid, print "Invalid integer." and STOP the program (return).
        Console.Write("Enter an integer: ");
        string aText = Console.ReadLine();

        // TODO A1 (code here)
        // Hint: if (!int.TryParse(aText, out int aNum)) { ... return; }

        // TODO A2: Using if/else if/else, print ONE of:
        // "Positive", "Negative", or "Zero" based on aNum.
        // TODO A2 (code here)

        // TODO A3: Print "Even" or "Odd" based on aNum.
        // Hint: remainder operator %
        // TODO A3 (code here)


        // ============================================================
        // PART B: Input validation loop (8–14 min)
        // ============================================================
        Console.WriteLine("\n--- PART B: Safe Age Input ---");

        // Goal: Keep asking until the user enters a valid age between 0 and 120 inclusive.

        int age = -1;

        // TODO B1: Write a loop that:
        // - Prompts: "Enter age (0-120): "
        // - Uses TryParse
        // - If invalid: "Not a whole number."
        // - If valid but out of range: "Out of range."
        // - If valid and in range: store into age and exit loop
        //
        // Allowed loops: while or do/while
        // TODO B1 (code here)

        // TODO B2: After loop, print: "Age accepted: <age>"
        // TODO B2 (code here)


        // ============================================================
        // PART C: `if` uniqueness — no “truthy” values + string checks (14–20 min)
        // ============================================================
        Console.WriteLine("\n--- PART C: Secret Phrase ---");

        // TODO C1: Ask for a secret phrase (string).
        // TODO C2: If the input is null/empty/whitespace:
        //          print "You entered nothing." (and skip the rest of Part C).
        // TODO C3: Otherwise, compare (case-insensitive) to "unicorn".
        //          If it matches: print "Access granted."
        //          Else: print "Access denied."
        //
        // Hint for C2: string.IsNullOrWhiteSpace(...)
        // Hint for C3: Equals(..., StringComparison.???)
        // TODO C1–C3 (code here)


        // ============================================================
        // SWITCH ZONE (20–30 min): `switch` statement + multiple labels
        // ============================================================
        Console.WriteLine("\n--- PART D: Menu Switch ---");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1) Potion  2) Shield  3) Map  4) Quit");
        Console.Write("Enter choice (1-4): ");

        string choiceText = Console.ReadLine();

        // TODO D1: Use TryParse to convert to int choice. If invalid, print "Invalid choice." and set choice = 0.
        int choice = 0;
        // TODO D1 (code here)

        // TODO D2: Use a switch statement on choice.
        // Required outputs:
        // 1 -> "You drink a potion."
        // 2 -> "You raise a shield."
        // 3 -> "You study the map."
        // 4 -> "You quit the dungeon."
        // default -> "That option does nothing."
        //
        // Note: Include break statements.
        // TODO D2 (code here)

        // TODO D3: Add a “multi-label” case:
        // If choice is 1 OR 2, also print: "Combat item selected."
        //
        // Hint: You can do:
        // case 1:
        // case 2:
        //    ...
        //
        // TODO D3 (code here)


        // ============================================================
        // PART E (30–38 min): C#-unique-ish switch expression + pattern matching (stretchy)
        // ============================================================
        Console.WriteLine("\n--- PART E: Rank Evaluator ---");
        Console.Write("Enter a score (0-100): ");
        string scoreText = Console.ReadLine();

        // TODO E1: Parse score safely with TryParse; if invalid print "Invalid score." and return.
        int score = 0;
        // TODO E1 (code here)

        // TODO E2: Create a string rank using a SWITCH EXPRESSION with RELATIONAL PATTERNS:
        // score switch
        // {
        //   >= 90 => "A",
        //   >= 80 => "B",
        //   >= 70 => "C",
        //   >= 60 => "D",
        //   _     => "F"
        // };
        //
        // Store it in: string rank = ...
        // TODO E2 (code here)

        // TODO E3: Print: "Rank: <rank>"
        // TODO E3 (code here)

        // TODO E4: Use another switch expression (or switch statement) to convert rank into a short message:
        // A -> "Excellent"
        // B -> "Good"
        // C -> "Okay"
        // D -> "Risky"
        // F -> "Danger"
        //
        // Print: "Message: <message>"
        // TODO E4 (code here)

        // ------------------------------------------------------------
        // OPTIONAL CHALLENGE (if time remains)
        // ------------------------------------------------------------
        // CH1: Add input checking so score outside 0–100 prints "Out of range." and returns.
        // CH2: Make a “badge” string:
        // If rank is A or B => "Honors"
        // If rank is C or D => "Standard"
        // If rank is F => "Retry"
        //
        // Print: "Badge: <badge>"
        // ------------------------------------------------------------

        Console.WriteLine("\n=== End of Decision Dungeon ===");
    }
}