Feature: Verify Daily,Hourly Report for Selected City

A short summary of the feature

@tag1
Scenario Outline: Verify Daily Report for the selected City
	Given I login to the application
	When I Click on WeatherAPI Menu and search for the given '<City>' 
	Then I should be able to see the daily Report of the selected '<City>'
Examples: 
| City      |
| Hyderabad |
| Banglore  |
| Chennai   |