Feature: SpecFlowFeature1
@first test
Scenario: MPG - easy
	Given Miles driven is 80
	And Gallons used is 10
	When calc_mpg is called
	Then the fuel efficiency should be 8
@Hi
Scenario: MPG-more
	Given Miles driven is 85.0
	And Gallons used is 10.0
	When calc_mpg is called
	Then the fuel efficiency should be 8.5
@Hi
Scenario: MPG - repeat
	Given Miles driven is 85.0
	And Gallons used is 10.0
	When calc_mpg is called
	Then the fuel efficiency should be 8.5
