Feature: Profile

The user wants to validate the profile page of the Book Store application. 

@positive @RequiresLogin
  Scenario: Verify profile page loads successfully  
    Given the user is on the profile page
    When the user navigates to the profile page  
    Then the profile page should display the logged-in user's username "nischal108"  
    And the "Log out" button should be visible

 @positive @RequiresLogin
  Scenario: Validate profile action buttons  
    Given the user is on the profile page  
    Then the various buttons should be visible and clickable 
      

 @negative
  Scenario: Validate restricted profile access without login  
    Given the user is not logged into the application  
    When the user tries to access the profile page  
    Then the user should  see the message"Currently you are not logged into the Book Store application, please visit the login page to enter or register page to register yourself." 