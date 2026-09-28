using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange: the calculator is created in SetUp.

        // Act
        double result = _calculator.Add(10, 20);

        // Assert
        Assert.That(result, Is.EqualTo(31));
    }
    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(
        double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }
    [TestCase(1, 2, 0.5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_ValidInputs_ReturnsQuotient(
        double a, double b, double expected)
    {
        double result = _calculator.Divide(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }
    
    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b),
            Throws.TypeOf<ArgumentException>());
    }
    [TestCase(1, 2, -1)]
    [TestCase(-1, 15, -16)]
    [TestCase(2.5, 0, 2.5)]
    public void Subtract_RepresentativeInputs_ReturnsDifference(
        double a, double b, double expected)
    {
        double result = _calculator.Subtract(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }
    [TestCase(1, 2, 2)]
    [TestCase(0, 15, 0)]
    [TestCase(-4, 0.25, -1)]
    public void Multiply_RepresentativeInputs_ReturnsProduct(
        double a, double b, double expected)
    {
        double result = _calculator.Multiply(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        long result = _calculator.Factorial(0);
        Assert.That(result, Is.EqualTo(1L));
    }

    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_OutOfRange_ThrowsArgumentOutOfRangeException(int n)
    {
        Assert.That(() => _calculator.Factorial(n),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(1, 1L)]
    [TestCase(5, 120L)]
    [TestCase(20, 2432902008176640000L)]
    public void Factorial_ValidInputs_ReturnsFactorial(int n, long expected)
    {
        long result = _calculator.Factorial(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TriangleArea_PositiveDimensions_ReturnsArea()
    {
        double result = _calculator.TriangleArea(3, 4);
        Assert.That(result, Is.EqualTo(6).Within(1e-9));
    }

    [TestCase(0, 4)]
    [TestCase(3, 0)]
    public void TriangleArea_ZeroDimension_ReturnsZero(
        double height, double width)
    {
        double result = _calculator.TriangleArea(height, width);
        Assert.That(result, Is.EqualTo(0).Within(1e-9));
    }

    [TestCase(-3, 4)]
    [TestCase(3, -4)]
    public void TriangleArea_NegativeDimension_ThrowsArgumentOutOfRangeException(
        double height, double width)
    {
        Assert.That(() => _calculator.TriangleArea(height, width),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void CircleArea_RadiusOne_ReturnsPi()
    {
        double result = _calculator.CircleArea(1);
        Assert.That(result, Is.EqualTo(Math.PI).Within(1e-9));
    }

    [Test]
    public void CircleArea_ZeroRadius_ReturnsZero()
    {
        double result = _calculator.CircleArea(0);
        Assert.That(result, Is.EqualTo(0).Within(1e-9));
    }

    [Test]
    public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException()
    {
        Assert.That(() => _calculator.CircleArea(-1),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(5, 5, 120L)]
    [TestCase(5, 4, 120L)]
    [TestCase(5, 3, 60L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    [TestCase(4, 2, 12L)]
    public void UnknownFunctionA_ValidInputs_ReturnsPermutations(
        int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionA(n, r);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(5, 5, 1L)]
    [TestCase(5, 4, 5L)]
    [TestCase(5, 3, 10L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    [TestCase(4, 2, 6L)] 
    public void UnknownFunctionB_ValidInputs_ReturnsCombinations(
        int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionB(n, r);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(5, -1)]
    [TestCase(21, 0)]
    public void UnknownFunctionA_InvalidInputs_ThrowsArgumentOutOfRangeException(
        int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(5, -1)]
    [TestCase(21, 0)]
    public void UnknownFunctionB_InvalidInputs_ThrowsArgumentOutOfRangeException(
        int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionB(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }


    [TestCase(100, 5, 20)]
    [TestCase(90, 3, 30)]
    public void MTBF_ValidInputs_ReturnsAverage(
        double operatingTime, int failures, double expected)
    {
        double result = _calculator.MTBF(operatingTime, failures);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 5)]
    [TestCase(-100, 5)]
    [TestCase(100, 0)]
    [TestCase(100, -1)]
    public void MTBF_InvalidInputs_ThrowsArgumentOutOfRangeException(
        double operatingTime, int failures)
    {
        Assert.That(() => _calculator.MTBF(operatingTime, failures),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(90, 10, 0.9)]
    [TestCase(90, 0, 1)]
    [TestCase(0, 10, 0)]
    public void Availability_ValidInputs_ReturnsRatio(
        double mtbf, double mttr, double expected)
    {
        double result = _calculator.Availability(mtbf, mttr);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 10)]
    [TestCase(90, -1)]
    [TestCase(0, 0)]
    public void Availability_InvalidInputs_ThrowsArgumentOutOfRangeException(
        double mtbf, double mttr)
    {
        Assert.That(() => _calculator.Availability(mtbf, mttr),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(10, 100, 0, 10)]
    [TestCase(10, 100, 10, 3.678794411714423)]
    public void FailureIntensity_ValidInputs_ReturnsExpectedRate(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime,
        double expected)
    {
        double result = _calculator.FailureIntensity(
            initialIntensity, expectedTotalFailures, executionTime);

        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 100, 10)]
    [TestCase(-1, 100, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, -1, 10)]
    [TestCase(10, 100, -1)]
    public void FailureIntensity_InvalidInputs_ThrowsArgumentOutOfRangeException(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        Assert.That(
            () => _calculator.FailureIntensity(
                initialIntensity, expectedTotalFailures, executionTime),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(10, 100, 0, 0)]
    [TestCase(10, 100, 10, 63.21205588285577)]
    public void CumulativeFailures_ValidInputs_ReturnsExpectedCount(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime,
        double expected)
    {
        double result = _calculator.CumulativeFailures(
            initialIntensity, expectedTotalFailures, executionTime);

        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 100, 10)]
    [TestCase(-1, 100, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, -1, 10)]
    [TestCase(10, 100, -1)]
    public void CumulativeFailures_InvalidInputs_ThrowsArgumentOutOfRangeException(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        Assert.That(
            () => _calculator.CumulativeFailures(
                initialIntensity, expectedTotalFailures, executionTime),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

}

