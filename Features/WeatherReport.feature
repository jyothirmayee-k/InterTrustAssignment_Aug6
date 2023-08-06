Feature: WeatherData 

A short summary of the feature

@test1
Scenario Outline: Verify if the given location is fetching Weather Report 
	Given I login to the application 
	When I click on WeatherData to enter the '<City>' and hit search
	And I should be navigated to WeatherDataResults page for the '<City>'
	Then I should be able to see the weatcher Data of '<City>'
Examples: 
| City      |
| Hyderabad |
| Banglore  |
| Chennai   |
