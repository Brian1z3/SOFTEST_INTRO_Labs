using System.Globalization;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorAvailabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly ReliabilityContext _reliability;

    public UsingCalculatorAvailabilitySteps(
        CalculatorContext context,
        ReliabilityContext reliability)
    {
        _context = context;
        _reliability = reliability;
    }

    [When("I have entered {double} and {int} into the calculator and press MTBF")]
    public void WhenICalculateMTBF(double operatingTime, int failures)
    {
        _context.Result = _context.Calculator.MTBF(operatingTime, failures);
    }

    [When("I have entered {double} and {double} into the calculator and press Availability")]
    public void WhenICalculateAvailability(double mtbf, double mttr)
    {
        _context.Result = _context.Calculator.Availability(mtbf, mttr);
    }

    [Given("the reliability values are")]
    public void GivenTheReliabilityValuesAre(DataTable table)
    {
        var values = table.Rows[0];

        _reliability.Mtbf = double.Parse(
            values["MTBF"], CultureInfo.InvariantCulture);

        _reliability.Mttr = double.Parse(
            values["MTTR"], CultureInfo.InvariantCulture);
    }

    [When("I calculate Availability from these values")]
    public void WhenICalculateAvailabilityFromTheseValues()
    {
        _context.Result = _context.Calculator.Availability(
            _reliability.Mtbf, _reliability.Mttr);
    }
}