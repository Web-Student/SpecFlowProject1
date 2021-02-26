using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        public class answerNode
        {
            private int number;
            private bool isNull = false;

            public int getNumber()
            {
                return number;
            }
            public bool getIsNull()
            {
                return isNull;
            }

            //public int asInt;
            //void setNumber(object objPassedIn)
            //{
            //    //One potential problem with this is if the answer is zero
            //    int num = Convert.ToInt32(objPassedIn);

            //    //if num is not zero, save it as the number
            //    if(num != 0)
            //    {
            //        number = num;
            //    }
            //    // if num is zero, either the string is null, the int is zero, or it is some other format.
            //    else if(objPassedIn == null)
            //    {
            //        isNull = true;
            //    }
                
            //    else if((int)objPassedIn == 0) // if the zero truly is the integer value, we can type cast it to an int.
            //    {
            //        number = 0;
            //    }
            //}

            void setNumber(int n, bool shouldBeNull)
            {
                if(shouldBeNull)
                {
                    isNull = true;
                }
                else
                {
                    isNull = false;
                    number = n;
                }
            }
        }

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
            object ans = 0;
            object tAns = _scenarioContext.Get<int>("testTempAns"); // come back and fix this line!!!!!

            answerNode tempAns = _scenarioContext.Get<answerNode>("testTempAns");
            if (tempAns.getIsNull())
            {
                //then the previous answer was null, and the only thing I can do about it is to continue to make the answer null.
                return;
            }
            else // proceed to process the array.
            {
                //Determine which operator it is.
                if (oper == '*')
                {
                    ans = tAns * n2;

                    _scenarioContext.Set<object>(ans, "testTempAns");
                }
                if (oper == '/')
                {
                    //We are not allowed to divide by zero!!!!!!!!! Return null
                    if (n2 == 0)
                    {
                        ans = null;
                    }
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
}
