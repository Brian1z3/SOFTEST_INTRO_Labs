namespace SOFTEST_INTRO_Calculator;

public class Calculator
{
    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }

        return a / b;
    }

    public double DoOperation(double a, double b, string op)
    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }

    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(n), "Input must be between 0 and 20.");
        }

        long result = 1L;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    public double TriangleArea(double height, double width)
    {
        //red
        //Previously, the method returned negative areas without throwing. Test result: 25 passed, 2 failed.
        if (height < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(height), "Height cannot be negative.");
        }

        if (width < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(width), "Width cannot be negative.");
        }
        //red
        //throw new NotImplementedException();

        return 0.5 * height * width;
    }

    public double CircleArea(double radius)
    {

        //red
        //Previously, without the radius < 0 check, the method returned Math.PI instead of throwing an exception.
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(radius), "Radius cannot be negative.");
        }

        return Math.PI * radius * radius;
    }

    public long UnknownFunctionA(int n, int r)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        if (r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException(nameof(r));
        }

        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        if (r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException(nameof(r));
        }

        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    //Lab qn: explain why a finite set of passing examples does not uniquely determine an implementation
    //Different formulas or hardcoded answers could match the tested inputs, but behave differently on inputs that were not tested.

    public double MTBF(double operatingTime, int failures)
    {
        if (operatingTime <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(operatingTime), "Operating time must be positive.");
        }

        if (failures <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(failures), "Number of failures must be positive.");
        }

        return operatingTime / failures;
    }

    public double Availability(double mtbf, double mttr)
    {
        if (mtbf < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mtbf), "MTBF cannot be negative.");
        }

        if (mttr < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mttr), "MTTR cannot be negative.");
        }

        if (mtbf + mttr <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mtbf), "MTBF and MTTR cannot both be zero.");
        }

        return mtbf / (mtbf + mttr);
    }

    public double FailureIntensity(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        if (initialIntensity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(initialIntensity), "Initial intensity must be positive.");
        }

        if (expectedTotalFailures <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(expectedTotalFailures),
                "Expected total failures must be positive.");
        }

        if (executionTime < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(executionTime), "Execution time cannot be negative.");
        }

        return initialIntensity * Math.Exp(
            -initialIntensity * executionTime / expectedTotalFailures);
    }

    public double CumulativeFailures(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        if (initialIntensity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(initialIntensity), "Initial intensity must be positive.");
        }

        if (expectedTotalFailures <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(expectedTotalFailures),
                "Expected total failures must be positive.");
        }

        if (executionTime < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(executionTime), "Execution time cannot be negative.");
        }

        return expectedTotalFailures * (1 - Math.Exp(
            -initialIntensity * executionTime / expectedTotalFailures));
    }
}