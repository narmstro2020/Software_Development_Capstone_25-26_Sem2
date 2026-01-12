/*
CAP - Unit 01 - Block __ - Classes Practice
Pair Programming Lab: Arcade Card Simulator
Names: ______________________  ______________________  (______________________)

Instructions:
- Complete each TODO in order.
- Run the program after EVERY small change.
- Keep methods small and focused (do one thing).
- Prefer private fields + public properties (encapsulation).
- Do NOT delete the test code. Make your classes pass the tests.

Roles (switch halfway)

Driver: types, runs the code, shares screen/keyboard
Navigator: reads instructions, watches for mistakes, explains “why”

(Optional 3rd) Coach: checks requirements, tests edge cases, keeps time

Timeline (70 minutes total)
0–5 min: Assign roles, create project, run once (expect failures).
5–20 min: Part A (ArcadeCard basics) + run tests.
20–35 min: Part B (ArcadeCard behaviors) + run tests.
35 min: Switch Driver/Navigator.
35–55 min: Part C (ArcadeGame + playing) + run tests.
55–65 min: Part D (Prize + redemption) + run tests.
65–70 min: Part E (polish + reflection) + final run + push to GitHub.

Each person will turn in a complete copy. Make sure all work is present for both students.
When finished turn this in on GitHub and Canvas.

This portion is worth 15 points.
*/

namespace _02_Assignment
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Arcade Card Simulator Lab ===\n");

            // Run the tests. You should NOT edit the tests.
            // TODO: Make these tests pass by completing the classes below.
            RunAllTests();

            Console.WriteLine("\nAll tests ran. If you see no FAIL messages, you're done.\n");
        }

        // ============================================================
        // TESTS (DO NOT EDIT)
        // ============================================================

        static void RunAllTests()
        {
            Test_ArcadeCard_Constructor_And_Properties();
            Test_ArcadeCard_LoadCredits_And_AddTickets();
            Test_ArcadeCard_PlayGame_Success_And_Fail();
            Test_ArcadeCard_Deactivate_BlocksActions();
            Test_ArcadeGame_Basics();
            Test_Prize_Redemption_Success_And_Fail();
        }

        static void Test_ArcadeCard_Constructor_And_Properties()
        {
            Console.WriteLine("TEST: ArcadeCard constructor + properties");

            int before = ArcadeCard.TotalCardsIssued;

            ArcadeCard card = new ArcadeCard("A100");

            AssertEqual("A100", card.CardId, "CardId should match constructor input");
            AssertEqual(0, card.Credits, "New card Credits should start at 0");
            AssertEqual(0, card.Tickets, "New card Tickets should start at 0");
            AssertEqual(true, card.IsActive, "New card should be active");

            AssertEqual(before + 1, ArcadeCard.TotalCardsIssued, "TotalCardsIssued should increment");

            Console.WriteLine("  PASS\n");
        }

        static void Test_ArcadeCard_LoadCredits_And_AddTickets()
        {
            Console.WriteLine("TEST: ArcadeCard LoadCredits + AddTickets");

            ArcadeCard card = new ArcadeCard("A200");

            card.LoadCredits(20);
            AssertEqual(20, card.Credits, "Credits should increase after LoadCredits");

            card.AddTickets(50);
            AssertEqual(50, card.Tickets, "Tickets should increase after AddTickets");

            // Negative loads should not change state (and should not crash)
            card.LoadCredits(-10);
            AssertEqual(20, card.Credits, "Credits should not change for negative LoadCredits");

            card.AddTickets(-999);
            AssertEqual(50, card.Tickets, "Tickets should not change for negative AddTickets");

            Console.WriteLine("  PASS\n");
        }

        static void Test_ArcadeCard_PlayGame_Success_And_Fail()
        {
            Console.WriteLine("TEST: ArcadeCard PlayGame success/fail");

            ArcadeCard card = new ArcadeCard("A300");
            card.LoadCredits(10);

            ArcadeGame skeeBall = new ArcadeGame("Skee Ball", creditCost: 3, ticketPayout: 10);

            bool played1 = card.TryPlayGame(skeeBall);
            AssertEqual(true, played1, "TryPlayGame should return true when enough credits");
            AssertEqual(7, card.Credits, "Credits should decrease by game cost");
            AssertEqual(10, card.Tickets, "Tickets should increase by game payout");

            bool played2 = card.TryPlayGame(skeeBall);
            AssertEqual(true, played2, "TryPlayGame should return true on second play");
            AssertEqual(4, card.Credits, "Credits should be 4 after second play");
            AssertEqual(20, card.Tickets, "Tickets should be 20 after second play");

            bool played3 = card.TryPlayGame(skeeBall);
            AssertEqual(true, played3, "TryPlayGame should return true on third play");
            AssertEqual(1, card.Credits, "Credits should be 1 after third play");
            AssertEqual(30, card.Tickets, "Tickets should be 30 after third play");

            // Now should fail (only 1 credit left, cost is 3)
            bool played4 = card.TryPlayGame(skeeBall);
            AssertEqual(false, played4, "TryPlayGame should return false when NOT enough credits");
            AssertEqual(1, card.Credits, "Credits should NOT change on failed play");
            AssertEqual(30, card.Tickets, "Tickets should NOT change on failed play");

            Console.WriteLine("  PASS\n");
        }

        static void Test_ArcadeCard_Deactivate_BlocksActions()
        {
            Console.WriteLine("TEST: Deactivate blocks actions");

            ArcadeCard card = new ArcadeCard("A400");
            card.LoadCredits(10);
            card.AddTickets(10);

            card.Deactivate();

            // Should not change after deactivation
            card.LoadCredits(999);
            card.AddTickets(999);

            ArcadeGame game = new ArcadeGame("Dance Dance", creditCost: 2, ticketPayout: 5);
            bool played = card.TryPlayGame(game);

            AssertEqual(false, played, "TryPlayGame should return false when card is inactive");
            AssertEqual(10, card.Credits, "Credits should not change when inactive");
            AssertEqual(10, card.Tickets, "Tickets should not change when inactive");

            Console.WriteLine("  PASS\n");
        }

        static void Test_ArcadeGame_Basics()
        {
            Console.WriteLine("TEST: ArcadeGame basics");

            ArcadeGame game = new ArcadeGame("Claw Machine", creditCost: 4, ticketPayout: 1);

            AssertEqual("Claw Machine", game.Name, "Game name should match");
            AssertEqual(4, game.CreditCost, "CreditCost should match");
            AssertEqual(1, game.TicketPayout, "TicketPayout should match");

            Console.WriteLine("  PASS\n");
        }

        static void Test_Prize_Redemption_Success_And_Fail()
        {
            Console.WriteLine("TEST: Prize redemption success/fail");

            ArcadeCard card = new ArcadeCard("A500");
            card.AddTickets(60);

            Prize gummyWorms = new Prize("Gummy Worms", ticketCost: 25, quantity: 2);

            bool redeemed1 = gummyWorms.TryRedeem(card);
            AssertEqual(true, redeemed1, "First redeem should succeed");
            AssertEqual(35, card.Tickets, "Tickets should decrease by prize cost");
            AssertEqual(1, gummyWorms.Quantity, "Prize quantity should decrease");

            bool redeemed2 = gummyWorms.TryRedeem(card);
            AssertEqual(true, redeemed2, "Second redeem should succeed");
            AssertEqual(10, card.Tickets, "Tickets should be 10 after second redeem");
            AssertEqual(0, gummyWorms.Quantity, "Prize quantity should be 0 after second redeem");

            // Should fail: out of stock
            bool redeemed3 = gummyWorms.TryRedeem(card);
            AssertEqual(false, redeemed3, "Redeem should fail when prize is out of stock");
            AssertEqual(10, card.Tickets, "Tickets should not change on failed redeem");
            AssertEqual(0, gummyWorms.Quantity, "Quantity should remain 0");

            // Another prize should fail: not enough tickets
            Prize bigBear = new Prize("Big Teddy Bear", ticketCost: 200, quantity: 5);
            bool redeemed4 = bigBear.TryRedeem(card);
            AssertEqual(false, redeemed4, "Redeem should fail when not enough tickets");
            AssertEqual(10, card.Tickets, "Tickets should not change when not enough tickets");
            AssertEqual(5, bigBear.Quantity, "Quantity should not change on failed redeem");

            Console.WriteLine("  PASS\n");
        }

        // Small assert helpers
        static void AssertEqual<T>(T expected, T actual, string message)
        {
            if (!Equals(expected, actual))
            {
                Console.WriteLine($"  FAIL: {message}");
                Console.WriteLine($"        Expected: {expected}");
                Console.WriteLine($"        Actual:   {actual}\n");
            }
        }
    }

    // ============================================================
    // PART A: ArcadeCard (Fields, Constructor, Properties)
    // ============================================================
    public class ArcadeCard
    {
        // TODO: Create a private backing field for CardId (string).
        // TODO: Create a private backing field for credits (int).
        // TODO: Create a private backing field for tickets (int).
        // TODO: Create a private backing field for isActive (bool).

        // TODO: Create a public static property TotalCardsIssued (int) with a private setter.
        //       - Increment it each time a new ArcadeCard is constructed.

        // TODO: Create a public read-only property CardId.
        // TODO: Create a public read-only property Credits.
        // TODO: Create a public read-only property Tickets.
        // TODO: Create a public read-only property IsActive.

        // TODO: Constructor ArcadeCard(string cardId)
        //       - Store the cardId
        //       - Start credits at 0
        //       - Start tickets at 0
        //       - Start active as true
        //       - Increment TotalCardsIssued

        public static int TotalCardsIssued { get; private set; } = 0;

        public string CardId
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public int Credits
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public int Tickets
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public bool IsActive
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public ArcadeCard(string cardId)
        {
            // TODO
            throw new NotImplementedException();
        }

        // ============================================================
        // PART B: ArcadeCard Behaviors (Load, Tickets, Deactivate)
        // ============================================================

        public void LoadCredits(int amount)
        {
            // TODO:
            // - If card is NOT active, do nothing.
            // - If amount <= 0, do nothing.
            // - Otherwise add amount to credits.
            throw new NotImplementedException();
        }

        public void AddTickets(int amount)
        {
            // TODO:
            // - If card is NOT active, do nothing.
            // - If amount <= 0, do nothing.
            // - Otherwise add amount to tickets.
            throw new NotImplementedException();
        }

        public void Deactivate()
        {
            // TODO:
            // - Set IsActive to false
            throw new NotImplementedException();
        }

        // ============================================================
        // PART C: ArcadeCard + ArcadeGame interaction
        // ============================================================

        public bool TryPlayGame(ArcadeGame game)
        {
            // TODO:
            // - If card is NOT active, return false.
            // - If game is null, return false.
            // - If Credits < game.CreditCost, return false.
            // - Otherwise:
            //     - subtract game.CreditCost from Credits
            //     - add game.TicketPayout to Tickets
            //     - return true
            throw new NotImplementedException();
        }

        // ============================================================
        // PART E: Polish (Optional but recommended)
        // ============================================================

        public override string ToString()
        {
            // TODO: Return a nice string like:
            // "Card A100 | Credits: 12 | Tickets: 40 | Active: True"
            throw new NotImplementedException();
        }
    }

    // ============================================================
    // PART C: ArcadeGame (Simple class)
    // ============================================================
    public class ArcadeGame
    {
        // TODO: Create private fields for:
        // - name (string)
        // - creditCost (int)
        // - ticketPayout (int)

        // TODO: Create read-only public properties:
        // - Name
        // - CreditCost
        // - TicketPayout

        // TODO: Constructor ArcadeGame(string name, int creditCost, int ticketPayout)
        // - Store values
        // - If creditCost < 0, treat it as 0
        // - If ticketPayout < 0, treat it as 0
        // - If name is null/empty/whitespace, set it to "Unnamed Game"

        public string Name
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public int CreditCost
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public int TicketPayout
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public ArcadeGame(string name, int creditCost, int ticketPayout)
        {
            // TODO
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // TODO: Something like "Skee Ball (Cost: 3, Payout: 10)"
            throw new NotImplementedException();
        }
    }

    // ============================================================
    // PART D: Prize (Redeem tickets for prizes)
    // ============================================================
    public class Prize
    {
        // TODO: Private fields:
        // - name (string)
        // - ticketCost (int)
        // - quantity (int)

        // TODO: Public read-only properties:
        // - Name
        // - TicketCost
        // - Quantity (but Quantity needs to decrease when redeemed, so:
        //     - either make it a property with a private setter
        //     - or a read-only property backed by a private field)

        // TODO: Constructor Prize(string name, int ticketCost, int quantity)
        // - Validate:
        //   - ticketCost < 0 => 0
        //   - quantity < 0 => 0
        //   - null/empty name => "Unnamed Prize"

        public string Name
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public int TicketCost
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public int Quantity
        {
            get { throw new NotImplementedException(); } // TODO
        }

        public Prize(string name, int ticketCost, int quantity)
        {
            // TODO
            throw new NotImplementedException();
        }

        public bool TryRedeem(ArcadeCard card)
        {
            // TODO:
            // - If card is null => false
            // - If prize Quantity <= 0 => false
            // - If card is NOT active => false
            // - If card.Tickets < TicketCost => false
            // - Otherwise:
            //    - subtract TicketCost from card's tickets
            //    - decrease Quantity by 1
            //    - return true
            //
            // NOTE: Since ArcadeCard.Tickets is read-only outside the class,
            // you may need to add a PRIVATE helper inside ArcadeCard that lets
            // Prize redemption reduce tickets safely.
            //
            // Hint approach:
            // - Add an internal method on ArcadeCard like:
            //      internal bool TrySpendTickets(int amount)
            //   that checks active + enough tickets and subtracts.
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // TODO: "Gummy Worms (Cost: 25 tickets, Qty: 2)"
            throw new NotImplementedException();
        }
    }
}

/*
PART E: Reflection (answer in COMMENTS)
------------------------------------------------------------
1) What is one advantage of making fields private and using properties?

// TODO: _________________________________________________

2) In your own words: what does it mean for a method to have a "side effect"?

// TODO: _________________________________________________

3) Where did you do input validation in this lab (name one place)? Why?

// TODO: _________________________________________________
*/
