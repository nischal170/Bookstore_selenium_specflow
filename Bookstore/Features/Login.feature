@login
Feature: Login to Book Store Application
The user wants to log in to the Book Store application so that the user can access their account.


@positive
Scenario: Successful Login with Valid Credentials
  Given The user navigates to the Book Store login page
  When The user enters valid username "nischal108"  and password "Apple123@"
  And The user clicks the login button
  Then The user should be logged in successfully
 



@negative 
Scenario Outline: Login with Invalid Credentials
   Given The user navigates to the Book Store login page
   When The user enters invalid "<username>" and invalid  "<password>"
   And The user clicks the login button
   Then The user should see an error message "Invalid username or password!"

   Examples:
   | username    | password  |
   | nischal1111 | Apple123@ |
   | nischal108  | 123S@d    |
   



@negative
Scenario Outline: Login with Empty Username and Password
    Given The user navigates to the Book Store login page
    When The user enters blank "<username>"  and "<password>"
    And The user clicks the login button
    Then The user shouldn't be able to login

    Examples: 
    | username | password |
    |          |          |

     