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
            private bool isNull = false; // indicates if the number should be considered "null" instead of as an integer.
            // isNull is useful for dividing by zero.

            //empty constructor
            public answerNode()
            {
                number = 0;
                isNull = false;
            }

            //constructor that accepts a number and a isNull value
            public answerNode(int n, bool nullNotNull)
            {
                number = n;
                isNull = nullNotNull;
            }

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

            public void setNumber(int n, bool shouldBeNull)
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
            answerNode n1 = new answerNode(number, false);
            _scenarioContext.Add("num1", number);
            _scenarioContext.Add("testTempAns", n1);
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
        public void ThenTheResultShouldBe(object result)
        {
            answerNode ans = _scenarioContext.Get<answerNode>("result");

            //if the result was supposed to be null, check
            if (result == null)
            {
                //check to see if the answer was null
                bool isNull = ans.getIsNull();
                isNull.Should().Be((bool)result);
            }
            else
            {
                int answer = ans.getNumber();
                answer.Should().Be((int)result);
            }
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
            //get the previous answer
            answerNode tempAns = _scenarioContext.Get<answerNode>("testTempAns");

            if (tempAns.getIsNull())
            {
                //then the previous answer was null, and the only thing I can do about it is to continue to make the answer null.
                return;
            }
            //tempAns must be an int, because it was not null.
            // proceed to process the number and perform a calculator operation.
            else
            {

                int tAns = tempAns.getNumber();

                answerNode ans = new answerNode(); // to hold temporary answer.

                //Determine which operator it is.
                if (oper == '*')
                {
                    ans.setNumber(tAns * n2, false); //set the number as the product, false because does not need to be set to null.

                    _scenarioContext.Set<answerNode>(ans, "testTempAns");
                }
                if (oper == '/')
                {
                    //We are not allowed to divide by zero!!!!!!!!! Return null
                    if (n2 == 0)
                    {
                        //set the answer to null!!!!!!!!!
                        ans.setNumber(n2, true); // pass n2 as the number we were trying to divide by (zero).
                    }
                    ans.setNumber(tAns / n2, false);
                    _scenarioContext.Set<answerNode>(ans, "testTempAns");
                }
                if (oper == '+')
                {
                    ans.setNumber(tAns + n2, false);
                    _scenarioContext.Set<answerNode>(ans, "testTempAns");
                }
                if (oper == '-')
                {
                    ans.setNumber(tAns - n2, false);
                    _scenarioContext.Set<answerNode>(ans, "testTempAns");
                }
                if (oper == '%')
                {
                    //We are not allowed to divide by zero!!!!!!!!! Return null
                    if (n2 == 0)
                    {
                        //set the answer to null!!!!!!!!!
                        ans.setNumber(n2, true); // pass n2 as the number we were trying to modulo by (zero).
                    }
                    ans.setNumber(tAns % n2, false);
                    _scenarioContext.Set<answerNode>(ans, "testTempAns");
                }

                if (_scenarioContext.ContainsKey("result"))
                {
                    _scenarioContext.Set<answerNode>(ans, "result");
                }
                else
                    _scenarioContext.Add("result", ans);
            }
        }


    }
}
