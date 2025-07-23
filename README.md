# Test Automation Framework

A robust **Test Automation Framework** built using **C#**, **.NET**, **Selenium**, and **Reqnroll** (Cucumber-style BDD for .NET). Designed for clean test design, maintainability, and scalability.

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

  

## 📁 Project Structure

| Folders                   | Description                                              |
| ------------------------- | -------------------------------------------------------- |
| `Abstraction/`            | Interfaces for abstraction                               |
| `Container/`              | Dependency injection setup                               |
| `DriverController/`       | Manages WebDriver sessions and browser logic             |
| `Drivers/`                | WebDriver classes (e.g., Chrome, Edge)                   |
| `Features/`               | Gherkin `.feature` files for BDD                         |
| `Hooks/`                  | Test lifecycle hooks (`BeforeScenario`, `AfterScenario`) |
|`Runner/`                  | This is used to run before and after the test steps, allowing you to set up the environment, |
| `Pages/`                  | Page Object Model (POM) classes                          |
| `Params/`                 | Parameter and configuration methods                      |
| `Reports/`                | Reporting utilities and test results                     |
| `Resources/`              | Application and framework settings classes               |
| `Runner/`                 | Test execution entry points                              |
| `Steps/`                  | Step definition implementations                          |
| `applicationSettings.env` | App-level environment configuration                      |
| `frameworkSettings.env`   | Framework-specific environment configuration             |


## 📁 Test Cases 








