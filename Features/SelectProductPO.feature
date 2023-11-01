Feature: Select Product in Store PO
  @PO
  Scenario Outline: Selecting Product with Success PO <user>
    Given I access SauceDemo store PO
    When I filled a user <user> and password <password> PO
    And I click in Login PO
    Then I verify the home page's title "Products" PO
    And show cart's link PO
    When I click in product <productTitle> PO
    Then I verify the product title <productTitle> PO
    And I verify the product price <productPrice> PO
    When I click in Add to Cart PO
    And I click in Cart icon PO
    Then I verify the page's title "Your Cart" PO
    And I verify the product title <productTitle> in cart PO
    And I verify the quantity is "1" PO
    And I verify the product price <productPrice> in cart PO

    Examples: 
      | user                      | password       | productTitle            | productPrice |
      | "standard_user"           | "secret_sauce" | "Sauce Labs Backpack"   | "$29.99"     |
      | "performance_glitch_user" | "secret_sauce" | "Sauce Labs Bike Light" | "$9.99"      |
