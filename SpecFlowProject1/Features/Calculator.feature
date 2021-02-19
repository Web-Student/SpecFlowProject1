Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject1/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@2nd Test
Scenario: Add one positive and 1 negative
	Given the first number is 50
	And the second number is -30
	When the two numbers are added
	Then the result should be 20

@subtraction
Scenario:  Subtract a smaller number from a larger number
	Given the first number is 88
	And the second number is 32
	When the two numbers are subtracted
	Then the result should be 56

@sub2
Scenario: Subtract a larger number from a smaller number
	Given the first number is 18
	And the second number is 32
	When the two numbers are subtracted
	Then the result should be -14

@Divide By Smaller Number
Scenario: Divide a larger integer by a smaller integer
	Given the first number is 24
	And the second number is 2
	When the two numbers are divided
	Then the result should be 12

@ Divide By a negative number
Scenario: Divide an integer by a negative integer
	Given the first number is 10
	And the second number is -3
	When the two numbers are divided
	Then the result should be -3

