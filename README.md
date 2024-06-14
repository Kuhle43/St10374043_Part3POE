# St10374043_Part3POE
Table of Contents
Introduction
System Requirements
Dependencies
Installation Instructions
Compilation Instructions
Running the Application
Usage
Troubleshooting
Contributing
License
Introduction
The Recipe Manager Application is a desktop application designed to help you manage your recipes efficiently. It allows you to add ingredients and steps to your recipes, filter recipes based on specific criteria, and reset all recipes when needed. This README file provides detailed instructions on how to compile and run the software.

System Requirements
To run the Recipe Manager Application, ensure your system meets the following requirements:

Operating System: Windows 7 or later
.NET Framework: Version 4.5 or later
Development Environment: Visual Studio 2019 or later (recommended)
Dependencies
The Recipe Manager Application relies on the following dependencies:

.NET Framework 4.5 or later
WPF (Windows Presentation Foundation) for the user interface
Installation Instructions
Download the Source Code: Clone or download the source code from the repository.

git clone https://github.com/your-repository/recipemanager.git
Open in Visual Studio: Open the solution file Recipemanager.sln in Visual Studio.

Compilation Instructions
Restore NuGet Packages:

In Visual Studio, go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
Restore any missing packages.
Build the Solution:

In Visual Studio, select Build > Build Solution or press Ctrl+Shift+B.
Ensure that the build completes successfully without any errors.
Running the Application
Start the Application:

In Visual Studio, press F5 or select Debug > Start Debugging to run the application.
Run from Executable:

Navigate to the bin\Debug or bin\Release folder within your project directory.
Double-click the Recipemanager.exe file to run the application.
Usage
Adding Ingredients
Enter the ingredient details (Name, Quantity, Unit, Calories, and Food Group).
Click the "Add Ingredient" button.
A confirmation message will appear indicating the ingredient has been added successfully.
Clearing Ingredient Fields
Click the "Clear Ingredient Fields" button.
All input fields related to the ingredient will be cleared.
Adding Steps
Enter the step description in the Step Description TextBox.
Click the "Add Step" button.
A confirmation message will appear indicating the step has been added successfully.
Clearing Step Description Field
Click the "Clear Step Description" button.
The step description input field will be cleared.
Adding a Recipe
Enter the recipe name in the Recipe Name TextBox.
Ensure you have added all the desired ingredients and steps.
Click the "Add Recipe" button.
A confirmation message will appear indicating the recipe has been added successfully.
Filtering Recipes
Enter the filter criteria (Ingredient Name, Food Group, and Maximum Calories).
Click the "Filter Recipes" button.
The ListBox will update to display only the recipes that match the filter criteria.
Resetting Recipes
Click the "Reset Recipes" button.
A confirmation message box will appear asking if you are sure you want to reset all recipes.
Click "Yes" to reset all recipes.
Troubleshooting
Ensure that all required fields are filled in correctly when adding ingredients or steps.
Ensure that your system meets the necessary requirements and that all dependencies are installed.
If you encounter any errors during compilation, check for missing NuGet packages and restore them.
Contributing
Contributions are welcome! If you would like to contribute to this project, please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Commit your changes and push them to your forked repository.
Submit a pull request detailing your changes.
