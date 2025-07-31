# Test Automation Framework

**Test Automation Framework** built using **C#**, **.NET**, **Selenium**, and **Reqnroll** (Cucumber-style BDD for .NET). 

------

Within this Test Automation Framework built using C#, .NET, Selenium, and Reqnroll
- The Page Object Model (POM) design pattern is used to represent each web page or UI component as a separate class.
- Element locators using Selenium WebDriver
- Reusable methods for interacting with the page (e.g. entering text, clicking buttons)
-  Abstraction of UI logic, keeping step definitions clean and focused on business behavior
---

## 🚀 Tech Stack

- **Language:** C#, .NET  
- **Automation Tool:** Selenium WebDriver  
- **BDD Framework:** Reqnroll is an open-source Cucumber-style BDD test automation framework for .NET. It has been created as a reboot of the SpecFlow project.
- **Test Runner:** NUnit  
- **Environment Management:** DotNetEnv  


---

## 📦 NuGet Packages to Install

Ensure the following NuGet packages are installed in your project:

- NUnit
- DotNetEnv
- Reqnroll
- Reqnroll.NUnit
- Selenium.WebDriver
- Selenium.ChromeDriver
- Selenium.WebDriver.MSEdgeDriver
- WebDriverManager
-  ExtentReports

  

## 📁 Project Structure

| Folders                   | Description                                              |
| ------------------------- | -------------------------------------------------------- |
| `Abstraction/`            | Interfaces for abstraction                               |
| `Container/`              | Dependency injection setup                               |
| `DriverController/`       | Manages WebDriver sessions and browser logic             |
| `Drivers/`                | WebDriver classes (e.g., Chrome, Edge)                   |
| `Features/`               | Gherkin `.feature` files for BDD                         |
| `Hooks/`                  | Test lifecycle hooks (`BeforeScenario`, `AfterScenario`) |
|`Runner/`                  | This is used to run before and after the test steps, allowing you to set up the environment such as Extent Report|
| `Pages/`                  | Page Object Model (POM) classes                          |
| `Params/`                 | Parameter and configuration methods                      |
| `Reports/`                | Reporting utilities and test results                     |
| `Resources/`              | Application and framework settings classes               |
| `Runner/`                 | Test execution entry points                              |
| `Steps/`                  | Step definition implementations                          |
| `applicationSettings.env` | App-level environment configuration                      |
| `frameworkSettings.env`   | Framework-specific environment configuration             |


## 📁 Test Cases 

| Test Cases                   | Description                                              |
| ------------------------- | -------------------------------------------------------- |
| `Login/`            | Valid Credentials                              |
| `Login/`            | Invalid Credentials                            |
| `Checkout/`            | Checkout Functionality                      |

## 📁 Reporting

Extent Reports 

below is an Example of the Format used in the Extent report showing the scenarios and within each scenario has is own test steps and images attached of the Test run 
<img width="1260" height="536" alt="image" src="https://github.com/user-attachments/assets/89a8a099-0ece-4532-b33b-f8a34648205e" />



## 📁  Future developments / Plans  - Hook up the framework to Jenkins or Github Actions  








