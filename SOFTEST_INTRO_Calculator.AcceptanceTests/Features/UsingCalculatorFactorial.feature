@Factorial
Feature: UsingCalculatorFactorial
  In order to calculate factorials correctly
  As a calculator user
  I want valid results and unsupported inputs to be rejected

  Scenario: Calculate a normal factorial
    Given I have a calculator
    When I calculate the factorial of 5
    Then the factorial result should be 120

  Scenario: Calculate the factorial of zero
    Given I have a calculator
    When I calculate the factorial of 0
    Then the factorial result should be 1

  Scenario: Reject an unsupported factorial input
    Given I have a calculator
    When I calculate the factorial of 21
    Then the factorial calculation should be rejected