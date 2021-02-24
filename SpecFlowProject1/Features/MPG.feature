Feature: SpecFlowFeature1

Scenario: MPG - easy
	Given Miles driven is 80
	And Gallons used is 10
	When calc_mpg is called
	Then the fuel efficiency should be 8

Scenario: MPG-more
	Given Miles driven in 85
	And Gallons used is 10
	When calc_mpg is called
	Then the fuel efficiency should be 8.5