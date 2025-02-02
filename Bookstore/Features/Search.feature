Feature: Search

The user wants to search books in the  Book Store application.


@positive @RequiresLogin
Scenario: Search the books by the title
	Given the user is on the books search page
	When The user enters  the book by the title "Git Pocket Guide"
	Then The user should see the book's title "Git Pocket Guide" in the search result
	And each book result should display the following columns:
	| Image | Title | Author | Publisher |

@positive  @RequiresLogin
  Scenario: Search books by author  
    Given the user is on the books search page  
    When the user enters an author's name "Kyle Simpson" in the search bar  
    Then the user should see a list of books written by the author"Kyle Simpson"  
    And each book result should display the following columns:
    | Image | Title | Author | Publisher |
       

@positive  @RequiresLogin
  Scenario: Search books using partial title  
    Given the user is on the books search page  
    When the user enters a partial book title "java" in the search bar 
    Then the user should see books matching the partial title "java"  
    And each book result should display the following columns:  
    | Image | Title | Author | Publisher |

@positive  @RequiresLogin
  Scenario: Search books by Publisher  
    Given the user is on the books search page  
    When the user enters an publisher's name "No Starch Press" in the search bar
    Then the user should see a list of books written by the Publisher "No Starch Press"   
    And each book result should display the following columns:  
    | Image | Title | Author | Publisher |

@negative  @RequiresLogin
  Scenario: Search with a non-existent book title  
    Given the user is on the books search page  
    When the user enters "Nonexistent Book" in the search bar and clicks the search button  
    Then the user should see a message saying "No rows found" 