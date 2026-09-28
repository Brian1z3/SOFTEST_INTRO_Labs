using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly BasicMusaContext _musa;

    public UsingCalculatorBasicReliabilitySteps(
        CalculatorContext context,
        BasicMusaContext musa)
    {
        _context = context;
        _musa = musa;
    }

    [When("I calculate failure intensity with initial intensity {double} failures per hour, expected total failures {double} and execution time {double} hours")]
    public void WhenICalculateFailureIntensity(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        _musa.InitialIntensity = initialIntensity;
        _musa.ExpectedTotalFailures = expectedTotalFailures;
        _musa.ExecutionTime = executionTime;

        _context.Result = _context.Calculator.FailureIntensity(
            _musa.InitialIntensity,
            _musa.ExpectedTotalFailures,
            _musa.ExecutionTime);
    }

    [When("I calculate cumulative failures with initial intensity {double} failures per hour, expected total failures {double} and execution time {double} hours")]
    public void WhenICalculateCumulativeFailures(
        double initialIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        _musa.InitialIntensity = initialIntensity;
        _musa.ExpectedTotalFailures = expectedTotalFailures;
        _musa.ExecutionTime = executionTime;

        _context.Result = _context.Calculator.CumulativeFailures(
            _musa.InitialIntensity,
            _musa.ExpectedTotalFailures,
            _musa.ExecutionTime);
    }
}