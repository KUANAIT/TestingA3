# KuanyshAitzhanov_Assignment3 – Selenium WebDriver Practice

## Description
This project is created as **Assignment 3 (Practice with Selenium WebDriver)**.  
It demonstrates automated UI testing using **C#**, **Selenium WebDriver**, and **NUnit**.

The project contains automated test cases for:
- search functionality
- login and logout functionality
- flight booking in a web-based flight reservation system

All tests are written using different locator strategies, including **CSS selectors** and **XPath**.

---

## Technologies Used
- C#
- .NET
- Selenium WebDriver
- NUnit
- ChromeDriver
- WebDriverManager

---

## Test Coverage

### 1. Search Functionality Test
- Web application: **Wikipedia**
- Steps:
    - Open Wikipedia main page
    - Enter search query
    - Navigate to the article page
    - Verify article title
- Locators used:
    - CSS selectors

---

### 2. Login and Logout Test
- Web application: **the-internet.herokuapp.com**
- Steps:
    - Open login page
    - Enter valid credentials
    - Verify successful login message
    - Perform logout
    - Verify return to login page
- Locators used:
    - XPath
    - CSS selectors

---

### 3. Flight Booking Test with Title Checkpoint
- Web application: **BlazeDemo**
- Steps:
    - Select departure and destination cities
    - Search available flights
    - Verify page title / heading (checkpoint)
    - Choose a flight
    - Fill passenger and payment details
    - Complete booking
    - Verify successful purchase message
- Locators used:
    - CSS selectors
    - XPath

---

## Project Structure

```text
KuanyshAitzhanov_Assignment3.Tests
│
├── BaseUiTest.cs           // WebDriver setup and teardown
├── SearchTests.cs          // Search functionality test
├── LoginLogoutTests.cs     // Login and logout test
└── FlightBookingTests.cs  // Flight booking test
```

## How to Run the Tests

### Prerequisites
- Installed **.NET SDK**
- Installed **Google Chrome**
- Internet connection (tests use public websites)

### Steps
1. Clone or download the project
2. Open the project folder in terminal
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Run all tests:
   ```bash
   dotnet test
   ```

### Notes
- ChromeDriver is automatically managed via **WebDriverManager**
- Browser window opens in maximized mode
- Tests use explicit waits for better stability