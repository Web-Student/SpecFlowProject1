using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Add("num1", number);

        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Add("num2", number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            int n1 = _scenarioContext.Get<int>("num1");
            int n2 = _scenarioContext.Get<int>("num2");
            _scenarioContext.Add("result", n1 + n2);

        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            int ans = _scenarioContext.Get<int>("result");
            ans.Should().Be(result);
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            int n1 = _scenarioContext.Get<int>("num1");
            int n2 = _scenarioContext.Get<int>("num2");
            _scenarioContext.Add("result", n1 - n2);
        }

        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            int n1 = _scenarioContext.Get<int>("num1");
            int n2 = _scenarioContext.Get<int>("num2");

            //If the denominator is zero, return null instead
            if (n2 == 0)
            {
                _scenarioContext.Add("resultObj", null);
            }
            else
            {
                _scenarioContext.Add("result", n1 / n2);
            }
        }

        [Then(@"the test should return (.*)")]
        public void ThenTheTestShouldReturnNull(object resultObj)
        {
            object ans = _scenarioContext.Get<object>("resultObj");
            ans.Should.Be(resultObj);
        }


    }
}
