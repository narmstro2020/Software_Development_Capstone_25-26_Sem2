/*
Unit 01 - C# Fundamentals - Block 02 - CAP_U1B2
Pair Programming Lab: Complex Numbers Boot Camp (Class + Operators)
Names: ______________________  ______________________  (______________________)

Instructions:
- Complete each TODO in order.
- Run after each step (tiny wins > giant debugging session).
- Keep methods small and predictable.
- Use doubles for real/imaginary parts.

Roles (switch halfway)
Driver: types, runs the code, shares screen/keyboard
Navigator: reads instructions, watches for mistakes, explains “why”
(Optional 3rd) Coach: tests edge cases, keeps time

0–5 min: Assign roles, create project/file, run once.
5–30 min: Parts A–C (core class + basics)
30 min: Switch Driver/Navigator
30–65 min: Parts D–F (operators + division + equality)
65–70 min: Clean up + final run + push to GitHub

Each person will turn in a complete copy. Make sure all work is present for both students.
When finished, turn this in on GitHub and Canvas.
This portion is worth 15 points.
*/

namespace U1B2_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== CAP_U1B2: Complex Numbers Boot Camp ===\n");

            // ------------------------------------------------------------
            // PART A: Warm-up Construction + ToString
            // ------------------------------------------------------------
            Console.WriteLine("=== PART A: Construction + Display ===");

            // TODO A1: Create two complex numbers:
            //   a = 3 + 4i
            //   b = -2 + 5i
            // Then print them using Console.WriteLine.
            // Expected format examples:
            //   3 + 4i
            //   -2 + 5i

            // ------------------------------------------------------------
            // PART B: Basic Methods (Magnitude, Conjugate)
            // ------------------------------------------------------------
            Console.WriteLine("\n=== PART B: Magnitude + Conjugate ===");

            // TODO B1: Print magnitude of a.
            // Magnitude of (3 + 4i) is 5.

            // TODO B2: Print conjugate of b.
            // Conjugate of (-2 + 5i) is (-2 - 5i).

            // ------------------------------------------------------------
            // PART C: Add/Subtract (methods first, then operators later)
            // ------------------------------------------------------------
            Console.WriteLine("\n=== PART C: Add/Subtract (methods) ===");

            // TODO C1: Compute:
            //   sum = a.Add(b)
            //   diff = a.Subtract(b)
            // Print them.
            // a + b = (3 + -2) + (4 + 5)i = 1 + 9i
            // a - b = (3 - -2) + (4 - 5)i = 5 - 1i

            // ------------------------------------------------------------
            // PART D: Multiply (method) + Operator Overloads
            // ------------------------------------------------------------
            Console.WriteLine("\n=== PART D: Multiply + Operator Overloads ===");

            // TODO D1: Compute product = a.Multiply(b) and print it.
            // (3 + 4i)(-2 + 5i) =
            //   (3*-2 - 4*5) + (3*5 + 4*-2)i
            // = (-6 - 20) + (15 - 8)i
            // = -26 + 7i

            // TODO D2: Implement operator overloads in Complex so that:
            //   a + b, a - b, a * b work.
            // Then re-compute using operators and print results.

            // ------------------------------------------------------------
            // PART E: Division + Safety
            // ------------------------------------------------------------
            Console.WriteLine("\n=== PART E: Division ===");

            // TODO E1: Implement Divide in Complex using:
            // (a + bi) / (c + di) =
            //   [(ac + bd) / (c^2 + d^2)] + [(bc - ad) / (c^2 + d^2)] i
            //
            // If divisor magnitude squared (c^2 + d^2) is 0, throw:
            //   new DivideByZeroException("Cannot divide by 0 + 0i");

            // TODO E2: Compute q1 = a / b (using Divide method) and print it.
            // TODO E3: Add operator /, then compute q2 = a / b and print it.

            // ------------------------------------------------------------
            // PART F: Equality + Approx Comparisons (because doubles are weird)
            // ------------------------------------------------------------
            Console.WriteLine("\n=== PART F: Equality ===");

            // TODO F1: Implement Equals + GetHashCode + == and !=.
            // Use a small tolerance EPS = 1e-9:
            //   Two complex numbers are “equal” if both parts are within EPS.

            // TODO F2: Test equality:
            //   c = new Complex(1.0, 9.0)
            //   (a + b) == c  should be true (within EPS)

            // ------------------------------------------------------------
            // PART G: Mini “Test Suite” (no testing framework needed)
            // ------------------------------------------------------------
            Console.WriteLine("\n=== PART G: Mini Test Suite ===");

            // TODO G1: After everything is implemented, uncomment these tests
            // and make sure they all print PASS.

            // RunAllTests();

            Console.WriteLine("\n=== Done (for now). If something broke, it’s probably math being dramatic. ===\n");
        }

        // ------------------------------------------------------------
        // Mini test helpers (keep these as-is; fix your code instead)
        // ------------------------------------------------------------
        static void RunAllTests()
        {
            var a = new Complex(3, 4);
            var b = new Complex(-2, 5);

            AssertTrue(a.ToString() == "3 + 4i", "ToString A");
            AssertTrue(b.ToString() == "-2 + 5i", "ToString B");

            AssertNear(a.Magnitude(), 5.0, 1e-9, "Magnitude");

            AssertTrue(b.Conjugate().ToString() == "-2 - 5i", "Conjugate");

            AssertTrue((a.Add(b)).ToString() == "1 + 9i", "Add method");
            AssertTrue((a - b).ToString() == "5 - 1i", "Subtract operator");

            AssertTrue((a.Multiply(b)).ToString() == "-26 + 7i", "Multiply method");
            AssertTrue((a * b).ToString() == "-26 + 7i", "Multiply operator");

            var c = new Complex(1.0, 9.0);
            AssertTrue((a + b) == c, "Equality with EPS");

            // Division sanity check: b / b should be ~ 1 + 0i
            var one = b / b;
            AssertTrue(one == new Complex(1, 0), "Division (b/b)");

            // Divide by zero check
            try
            {
                var z = new Complex(0, 0);
                var boom = a / z;
                Console.WriteLine("FAIL: DivideByZero (no exception)");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("PASS: DivideByZero");
            }
        }

        static void AssertTrue(bool condition, string testName)
        {
            Console.WriteLine((condition ? "PASS: " : "FAIL: ") + testName);
        }

        static void AssertNear(double actual, double expected, double eps, string testName)
        {
            bool ok = Math.Abs(actual - expected) <= eps;
            Console.WriteLine((ok ? "PASS: " : "FAIL: ") + testName + $" (got {actual}, expected {expected})");
        }
    }

    // ============================================================
    // TODO: Implement this class
    // ============================================================
    public class Complex
    {
        // TODO A2: Create private fields for real and imaginary parts (double).
        // Suggested names: _real, _imag

        // TODO A3: Create a constructor Complex(double real, double imag)

        // TODO A4: (Optional but nice) Add public read-only properties:
        //   Real and Imag

        // TODO A5: Implement ToString():
        // - Format: "a + bi" or "a - bi"
        // - No parentheses
        // - Examples:
        //     3 + 4i
        //     5 - 1i
        // Hint: if imag is negative, use " - " and absolute value.

        // TODO B3: Implement Magnitude():
        // sqrt(real^2 + imag^2)

        // TODO B4: Implement Conjugate():
        // (a + bi) -> (a - bi)

        // TODO C2: Implement Add(Complex other)
        // TODO C3: Implement Subtract(Complex other)

        // TODO D3: Implement Multiply(Complex other)
        // (a + bi)(c + di) = (ac - bd) + (ad + bc)i

        // TODO E4: Implement Divide(Complex other) using formula in Main.

        // TODO D4: Implement operator overloads:
        //   +, -, *, /
        // Each should return a new Complex.

        // TODO F3: Implement equality:
        // - Override Equals(object? obj)
        // - Override GetHashCode()
        // - Implement operators == and !=
        //
        // Use EPS = 1e-9 comparisons for Real/Imag.
        // Note: hashing + EPS is awkward; simplest acceptable approach here:
        //   - Round both parts to 9 decimal places, then hash those.
        //
        // That keeps == and GetHashCode mostly consistent for this assignment.
    }
}
