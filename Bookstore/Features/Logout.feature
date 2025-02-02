Feature: Logout

The user wants to log out of the Book Store application securely. 


@positive @RequiresLogin
  Scenario: Verify logout button visibility  
    Given the user is on the profile page  
    Then the "Log out" button should be visible and clickable

@positive @RequiresLogin 
  Scenario: Verify successful logout  
    Given the user is on the profile page
    When the user clicks on the "Log out" button  
    Then the user should be redirected to the login page  
    