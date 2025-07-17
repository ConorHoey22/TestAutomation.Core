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

## 🚀 File Structure

/TestAutomation.Core
│
├── Abstraction/              # Interfaces  (Abstraction)
├── Container/                # Dependency injection 
├── DriverController/         # Manages WebDrivers sessions  , Switch statement to determine the browser entered within Config
├── Drivers/                  # WebDriver classes - e.g. Chrome , Edge 
├── Features/                 # Gherkin .feature files
├── Hooks/                    # Test initialization - e.g. BeforeScenario , AfterScenario
├── Pages/                    # Page Object Models (POM)
├── Params/                   # Parameter and Configuration Methods 
├── Reports/                  # Reporting utilities or test results
├── Resources/                # ApplicationSettings and Framework settings classes
├── Runner/                   # Test execution entry points
├── Steps/                    # Step definitions
├── applicationSettings.env   # Application environment config
└── frameworkSettings.env     # Framework-specific config






