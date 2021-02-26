using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private object number = 0;

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
            _scenarioContext.Add("testTempAns", number);
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
            int n1 = _scenarioContext.Get<int>("num1");
            int n2 = _scenarioContext.Get<int>("num2");
            _scenarioContext.Add("result", n1 + n2);

        }

        [Then("the two blobs are (.*) and the second is (.*)")]
        public void twoBlobsHomework(string oper, int secondNumber)
        {
            //TODO: implement assert (verification) logic

        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            int ans = _scenarioContext.Get<int>("result");

            //int ans = _scenarioContext.Get<int>("result");
            System.Console.WriteLine("result shoult be " + result + ", but is " + ans);
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


        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            int n1 = _scenarioContext.Get<int>("num1");
            int n2 = _scenarioContext.Get<int>("num2");
            _scenarioContext.Add("result", n1 * n2);
        }

        [When(@"operation (.*) is done to the number (.*)")]
        public void WhenOperation_IsDoneToTheNumber(char oper, int n2)
        {
            //Get the previous answer (or num 1)
            int ans = 0;
            int tAns = _scenarioContext.Get<int>("testTempAns");

            //Determine which operator it is.
            if (oper == '*')
            {
                //ans = tempAns * n2;
                ans = tAns * n2;

                //tempAns = ans;
                _scenarioContext.Set<int>(ans, "testTempAns");
            }
            if (oper == '/')
            {
                //ans = tempAns / n2;
                ans = tAns / n2;

                //tempAns = ans;
                _scenarioContext.Set<int>(ans, "testTempAns");
            }
            if (oper == '+')
            {
                //ans = tempAns + n2;
                ans = tAns + n2;

                //tempAns = ans;
                _scenarioContext.Set<int>(ans, "testTempAns");
            }
            if (oper == '-')
            {
                //ans = tempAns - n2;
                ans = tAns - n2;

                //tempAns = ans; 
                _scenarioContext.Set<int>(ans, "testTempAns");
            }
            if (oper == '%')
            {
                //ans = tempAns % n2;
                ans = tAns % n2;

                //tempAns = ans;
                _scenarioContext.Set<int>(ans, "testTempAns");
            }

            //Save the answer to both tempAns and final result
            //_scenarioContext.Add("result", ans);
            //_scenarioContext.Add("tempAns", ans);


            if (_scenarioContext.ContainsKey("result"))
            {
                _scenarioContext.Set<int>(ans, "result");
            }
            else
                _scenarioContext.Add("result", ans);
        }


    }
}
