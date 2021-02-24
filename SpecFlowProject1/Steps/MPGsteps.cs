using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
//using SharedLib;
using ClassLibrary2;
using TechTalk.SpecFlow;
//using FuelEfficiency.cs;

namespace SpecFlowProject1
{
    [Binding]
    public sealed class MPGsteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public MPGsteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Miles driven is (.*)")]
        public void GivenMilesDrivenIs(double p0)
        {
            _scenarioContext.Add("miles", p0);
        }

        [Given(@"Gallons used is (.*)")]
        public void GivenGallonsUsedIs( p0)
        {
            _scenarioContext.Add("gallons", p0);
        }

        [When(@"calc_mpg is called")]
        public void WhenCalc_MpgIsCalled()
        {
            FuelEfficiency f = new FuelEfficiency();

            //int m = _scenarioContext.Get<int>("miles");
            //int g = _scenarioContext.Get<int>("gallons");
            //int answer = f.calc_mpg(m, g);
            //_scenarioContext.Add("mpg", answer);

            _scenarioContext.Add("mpg", 
                f.calc_mpg(_scenarioContext.Get<double>("miles"), 
                _scenarioContext.Get<double>("gallons")));
        }

        [Then(@"the fuel efficiency should be (.*)")]
        public void ThenTheFuelEfficiencyShouldBe(int p0)
        {
            var m = _scenarioContext.Get<double>("mpg");
            m.Should().Be(p0);
        }


    }
}
