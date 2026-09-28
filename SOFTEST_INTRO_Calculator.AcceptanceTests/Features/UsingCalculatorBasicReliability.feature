@BasicMusa
Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures and intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  Scenario: Initial failure intensity before execution
    Given I have a calculator
    When I calculate failure intensity with initial intensity 10 failures per hour, expected total failures 100 and execution time 0 hours
    Then the result should be 10

  Scenario: Failure intensity decreases with execution time
    Given I have a calculator
    When I calculate failure intensity with initial intensity 10 failures per hour, expected total failures 100 and execution time 10 hours
    Then the result should be 3.678794411714423

      Scenario: No failures before execution
    Given I have a calculator
    When I calculate cumulative failures with initial intensity 10 failures per hour, expected total failures 100 and execution time 0 hours
    Then the result should be 0

  Scenario: Expected failures after execution
    Given I have a calculator
    When I calculate cumulative failures with initial intensity 10 failures per hour, expected total failures 100 and execution time 10 hours
    Then the result should be 63.21205588285577