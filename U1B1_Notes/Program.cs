/*
CAP - Unit 01 - Block 04 (Extension): C# Operators + Operator Overloading (Guided Notes)
Name: ____________________________   Date: _______________

Instructions:
- Students: fill in the blanks by writing answers in COMMENTS.
- Run this file often to see what happens.
- For TODOs: make small changes, run, and observe the output.
- Goal: understand core operators AND how operator overloading works in C#.

Suggested pacing (~20 minutes):
0–2 min   Warm-up + quick predictions
2–8 min   Core operator behavior (division, %, ++, precedence)
8–12 min  Boolean logic + short-circuit + checked/unchecked
12–20 min Operator overloading (rules + a Fraction example)
*/

namespace Operators;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== CAP_U1B4 Guided Notes: Operators + Operator Overloading ===\n");

        PartA_VocabularyAndCategories();
        PartB_ArithmeticDivisionAndModulo();
        PartC_IncrementDecrement();
        PartD_LogicShortCircuit();
        PartE_Precedence();
        PartF_CheckedUnchecked();

        Console.WriteLine("\n=== Operator Overloading Demo (Fraction) ===\n");
        FractionDemo();

        Console.WriteLine("\nDONE.");
    }

    // ============================================================
    // PART A: Vocabulary + Categories (2–8 min total begins here)
    // ============================================================
    static void PartA_VocabularyAndCategories()
    {
        Console.WriteLine("=== PART A: Vocabulary + Categories ===\n");

        /*
        Vocabulary (fill in the blanks):

        Operator: a symbol that performs an operation on one or more operands.
        Operand: the value(s) an operator works on.
        Unary operator: works on 1 operand.
        Binary operator: works on 2 operands.
        Ternary operator: works on 3 operands  ?:  (example: n > 2 ? "Greater Than 2" : Not Greater than 2)

        Short-circuit: the runtime may skip evaluating the right side of a boolean expression
                       if the result is already determined by the left side.

        Overload (operator overloading): defining how an operator like + or == behaves for a
                                         custom type (your own struct/class).

        Categories of operators (examples):
        - Arithmetic:  +  -  *  /  %
        - Assignment:  =  +=  -=  *=  /=
        - Comparison:  ==  !=  <  >  <=  >=
        - Logical:     &&  ||  !
        - Bitwise:     &  |  ^  ~  <<  >>
        - Conditional: condition ? expr1 : expr2
        - Null-related: ??  ??=
        */

        Console.WriteLine("Write your vocabulary answers in the comments above.\n");
    }

    // ============================================================
    // PART B: Arithmetic, Division, and Modulo (2–8 min)
    // ============================================================
    static void PartB_ArithmeticDivisionAndModulo()
    {
        Console.WriteLine("=== PART B: Arithmetic, Division, Modulo ===\n");

        int a = 7;
        int b = 2;

        // Predict BEFORE running:
        // 7 / 2 = 3
        // 7 / 2.0 = 3.5
        // -7 / 2 = -3
        // -7 % 2 = -1
        Console.WriteLine($"7 / 2 = {7 / 2}");
        Console.WriteLine($"7 / 2.0 = {7 / 2.0}");
        Console.WriteLine($"-7 / 2 = {-7 / 2}");
        Console.WriteLine($"-7 % 2 = {-7 % 2}");

        /*
        Notes:
        - Integer division truncates (drops the decimal part).
        - If either operand is floating-point, you get floating-point division.
        - Modulo (%) matches the sign behavior of division in C#.

        Quick check:
        If we want 7/2 to be 3.5 using ints, we can cast:
            (double)7 / 2
        */
        Console.WriteLine($"(double)7 / 2 = {(double)7 / 2}\n");
    }

    // ============================================================
    // PART C: ++ and -- (prefix vs postfix) (8–10 min)
    // ============================================================
    static void PartC_IncrementDecrement()
    {
        Console.WriteLine("=== PART C: ++ and -- (Prefix vs Postfix) ===\n");

        int x = 5;

        // Fill in predictions:
        // After y = ++x, x is 6 and y is 6.
        int y = ++x;

        Console.WriteLine($"After y = ++x; x={x}, y={y}");

        x = 5;

        // Fill in predictions:
        // After z = x++, x is 6 and z is 5.
        int z = x++;

        Console.WriteLine($"After z = x++; x={x}, z={z}\n");


        /*
        Rule:
        - Prefix (++x): increment first, then use the value.
        - Postfix (x++): use the value first, then increment.
        */
    }

    // ============================================================
    // PART D: Boolean logic + short-circuit (10–12 min)
    // ============================================================
    static void PartD_LogicShortCircuit()
    {
        Console.WriteLine("=== PART D: Boolean Logic + Short-Circuit ===\n");

        bool A()
        {
            Console.WriteLine("A() ran");
            return false;
        }

        bool B()
        {
            Console.WriteLine("B() ran");
            return true;
        }

        Console.WriteLine("Case 1: A() && B()");
        bool r1 = A() && B();
        Console.WriteLine($"Result: {r1}\n");

        Console.WriteLine("Case 2: A() & B()");
        bool r2 = A() & B();
        Console.WriteLine($"Result: {r2}\n");

        /*
        Fill in:
        - && is a logical operator (may skip evaluating the right side).
        - & (on bool) is short-circuit logical operator (always evaluates both sides).

        Why it matters:
        - Use && / || for normal boolean logic and safety checks.
        - Use & / | with bool only when you *intentionally* want both sides evaluated.
        */
    }

    // ============================================================
    // PART E: Operator precedence (12–13 min)
    // ============================================================
    static void PartE_Precedence()
    {
        Console.WriteLine("=== PART E: Operator Precedence ===\n");

        // Predict BEFORE running:
        // 2 + 3 * 4 = 2 + 12 = 14
        // (2 + 3) * 4 = 5 * 4 = 20
        Console.WriteLine($"2 + 3 * 4 = {2 + 3 * 4}");
        Console.WriteLine($"(2 + 3) * 4 = {(2 + 3) * 4}\n");

        /*
        Notes:
        - * and / happen before + and -.
        - Parentheses win. Use them for clarity, not just correctness.
        */
    }

    // ============================================================
    // PART F: checked vs unchecked overflow (13–15 min)
    // ============================================================
    static void PartF_CheckedUnchecked()
    {
        Console.WriteLine("=== PART F: checked vs unchecked (Overflow) ===\n");

        // Predict BEFORE running:
        // int.MaxValue + 1 in unchecked context becomes int.MinValue (wraps around).
        unchecked
        {
            int n = int.MaxValue;
            n = n + 1;
            Console.WriteLine($"unchecked: int.MaxValue + 1 = {n}");
        }

        // checked throws an exception for overflow (OverflowException).
        try
        {
            checked
            {
                int n = int.MaxValue;
                n = n + 1;
                Console.WriteLine($"checked: int.MaxValue + 1 = {n}"); // typically never reached
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("checked: OverflowException thrown (good!)");
        }

        Console.WriteLine();

        /*
        Fill in:
        - Use checked when overflow would be a bad bug.
        - unchecked can be useful when you WANT wraparound behavior (rare in beginner apps).
        */
    }

    // ============================================================
    // PART G: Operator Overloading (12–20 min target)
    // ============================================================
    static void FractionDemo()
    {
        /*
        Operator overloading rules (fill in):
        1) Operator overloads must be immutable and static.
        2) They must be defined inside the class or struct being overloaded.
        3) You cannot overload assignment operators like =.
        4) If you overload == you should also overload !=, and implement:
           - Equals(...)
           - GetHashCode()
           - (Recommended) IEquatable<T>

        Good reasons to overload:
        - math-like types (Vector, Fraction, Complex, Money)
        - units (Meters, Seconds) to avoid mixing incompatible values
        */

        // NOTE: Our Fraction struct below intentionally includes TODO stubs.
        // It compiles, but some operations may be incorrect until you implement them.

        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(3, 4);


        Console.WriteLine($"f1 = {f1}  (should be 1/2)");
        Console.WriteLine($"f2 = {f2}  (should be 3/4)");

        // TODO: After implementing +, this should become 5/4.
        Fraction sum = f1 + f2;
        Console.WriteLine($"f1 + f2 = {sum}  (expected 5/4 after TODO)");

        // TODO: After implementing *, this should become 3/8.
        Fraction prod = f1 * f2;
        Console.WriteLine($"f1 * f2 = {prod}  (expected 3/8 after TODO)");

        // TODO: After implementing == and != correctly, this should be False.
        Console.WriteLine($"f1 == f2 ? {f1 == f2}  (expected False after TODO)");

        // Conversion operators demo
        Fraction two = 2; // implicit from int
        Console.WriteLine($"two = {two}  (expected 2/1)");

        double asDouble = (double)f1; // explicit to double
        Console.WriteLine($"(double)f1 = {asDouble}  (expected 0.5)\n");

        /*
        Mini-Reflection:
        - Overloading + should NOT secretly mutate f1 or f2. Why?
          Answer: that would defeat the purpose.  3 + 2 is a new number 5
        */
    }
}

// ============================================================
// Fraction struct (Operator Overloading Practice)
// ============================================================
public readonly struct Fraction : IEquatable<Fraction>
{
    public int Num { get; }
    public int Den { get; }

    public Fraction(int num, int den)
    {
        if (den == 0) throw new ArgumentException("Denominator cannot be 0.");

        // Keep denominator positive
        if (den < 0)
        {
            num = -num;
            den = -den;
        }

        int g = Gcd(Math.Abs(num), den);
        Num = num / g;
        Den = den / g;
    }

    public override string ToString() => $"{Num}/{Den}";

    // -------------------------
    // TODO 1: Overload +
    // Expected: a/b + c/d = (ad + cb) / bd
    // -------------------------
    public static Fraction operator +(Fraction a, Fraction b)
    {
        var aNum = a.Num;
        var bNum = b.Num;
        var aDen = a.Den;
        var bDen = b.Den;

        var common = aDen * bDen;
        var newANum = common / aDen * aNum;
        var newBNum = common / bDen * bNum;

        var sum = newANum + newBNum;

        return new Fraction(sum, common);
    }

    // -------------------------
    // TODO 2: Overload *
    // Expected: a/b * c/d = (ac) / (bd)
    // -------------------------
    public static Fraction operator *(Fraction a, Fraction b)
    {
        var newNum = a.Num * b.Num;
        var newDen = a.Den * b.Den;

        return new Fraction(newNum, newDen);
    }

    // -------------------------
    // TODO 3: Overload unary -
    // Expected: -(a/b) = (-a)/b
    // -------------------------
    public static Fraction operator -(Fraction a)
    {
        return new Fraction(-a.Num, a.Den);
    }

    // -------------------------
    // TODO 4: Equality operators
    // Reminder: If you overload ==, also overload !=
    // -------------------------
    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.Num == b.Num && a.Den == b.Den;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    // IEquatable implementation (should match ==)
    public bool Equals(Fraction other)
    {
        // TODO: Replace placeholder
        return false;
    }

    public override bool Equals(object? obj) => obj is Fraction f && Equals(f);

    public override int GetHashCode()
    {
        // TODO: Replace placeholder with a stable hash based on Num and Den.
        return 0;
    }

    // -------------------------
    // TODO 5: Conversion operators
    // -------------------------
    public static implicit operator Fraction(int n)
    {
        // TODO: Replace placeholder
        return new Fraction(0, 1);
    }

    public static explicit operator double(Fraction f)
    {
        // TODO: Replace placeholder
        return 0.0;
    }

    // Helper: greatest common divisor
    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = a % b;
            a = b;
            b = t;
        }

        return a == 0 ? 1 : a;
    }
}

/*
Exit Ticket (last 1–2 minutes):
1) What is the difference between && and & for booleans?
   Answer: ____________________________________________________________

2) What’s the difference between ++x and x++?
   Answer: ____________________________________________________________

3) Name one rule you must follow when overloading ==.
   Answer: ____________________________________________________________

4) Why should operator overloads avoid mutating their operands?
   Answer: ____________________________________________________________
*/