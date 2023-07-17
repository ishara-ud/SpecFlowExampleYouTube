Feature: YouTubeSearch

Searching the given text on YouTube

@search

	Scenario: YouTube Search
	Given I am on YouTube website
	When I type "BMW Cars" in the search field
	And I click search button
	Then Search results should be is displayed
