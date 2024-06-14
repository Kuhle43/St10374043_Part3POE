using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Recipemanager
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private List<Ingredient> currentIngredients;
        private List<Step> currentSteps;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
            currentIngredients = new List<Ingredient>();
            currentSteps = new List<Step>();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientQuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientUnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientCaloriesTextBox.Text) ||
                IngredientFoodGroupComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all ingredient fields.");
                return;
            }

            if (!double.TryParse(IngredientQuantityTextBox.Text, out double quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!int.TryParse(IngredientCaloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Please enter a valid calorie count.");
                return;
            }

            var foodGroupItem = (ComboBoxItem)IngredientFoodGroupComboBox.SelectedItem;
            var foodGroup = foodGroupItem.Content.ToString();

            var ingredient = new Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = quantity,
                Unit = IngredientUnitTextBox.Text,
                Calories = calories,
                FoodGroup = foodGroup
            };

            currentIngredients.Add(ingredient);
            MessageBox.Show("Ingredient added successfully.");

            ClearIngredientFields();
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepDescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a step description.");
                return;
            }

            var step = new Step
            {
                Description = StepDescriptionTextBox.Text
            };

            currentSteps.Add(step);
            MessageBox.Show("Step added successfully.");

            ClearStepDescriptionField();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            var recipe = new Recipe
            {
                Name = RecipeNameTextBox.Text,
                Ingredients = new List<Ingredient>(currentIngredients),
                Steps = new List<Step>(currentSteps)
            };

            recipes.Add(recipe);
            currentIngredients.Clear();
            currentSteps.Clear();

            UpdateRecipesListBox();
            UpdateRecipeDisplay();

            MessageBox.Show("Recipe added successfully.");
            RecipeNameTextBox.Clear();
        }

        private void FilterRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientNameTextBox.Text;
            string foodGroup = IngredientFoodGroupComboBox.SelectedItem != null ?
                ((ComboBoxItem)IngredientFoodGroupComboBox.SelectedItem).Content.ToString() : null;
            int maxCalories = 0;
            int.TryParse(IngredientCaloriesTextBox.Text, out maxCalories);

            var filteredRecipes = recipes
                .Where(r => (string.IsNullOrEmpty(ingredient) || r.ContainsIngredient(ingredient))
                            && (string.IsNullOrEmpty(foodGroup) || r.IsInFoodGroup(foodGroup))
                            && (maxCalories == 0 || r.TotalCalories() <= maxCalories))
                .ToList();

            UpdateRecipesListBox(filteredRecipes);

            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes match the filter criteria.");
            }
        }

        private void UpdateRecipesListBox(List<Recipe> recipesToShow = null)
        {
            RecipesListBox.Items.Clear();
            var recipesToDisplay = recipesToShow ?? recipes;

            foreach (var recipe in recipesToDisplay)
            {
                RecipesListBox.Items.Add(recipe.Name);
            }
        }

        private void UpdateRecipeDisplay()
        {
            RecipeDisplayTextBlock.Text = "";

            foreach (var recipe in recipes)
            {
                RecipeDisplayTextBlock.Text += $"Recipe: {recipe.Name}\n";
                RecipeDisplayTextBlock.Text += "Ingredients:\n";
                foreach (var ingredient in recipe.Ingredients)
                {
                    RecipeDisplayTextBlock.Text += $"- {ingredient.Name} ({ingredient.Quantity} {ingredient.Unit})\n";
                }
                RecipeDisplayTextBlock.Text += "Steps:\n";
                foreach (var step in recipe.Steps)
                {
                    RecipeDisplayTextBlock.Text += $"- {step.Description}\n";
                }
                RecipeDisplayTextBlock.Text += "\n";
            }
        }

        private void ClearIngredientFields()
        {
            IngredientNameTextBox.Clear();
            IngredientQuantityTextBox.Clear();
            IngredientUnitTextBox.Clear();
            IngredientCaloriesTextBox.Clear();
            IngredientFoodGroupComboBox.SelectedIndex = -1;
        }

        private void ClearStepDescriptionField()
        {
            StepDescriptionTextBox.Clear();
        }

        private void ClearIngredientFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            ClearIngredientFields();
        }

        private void ClearStepDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            ClearStepDescriptionField();
        }
        private void ResetRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirm with user before resetting recipes
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reset all recipes?",
                                                      "Confirmation",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                recipes.Clear();
                UpdateRecipesListBox();
                UpdateRecipeDisplay();
                MessageBox.Show("All recipes have been reset.");
            }
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public bool ContainsIngredient(string ingredientName)
        {
            return Ingredients.Any(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsInFoodGroup(string foodGroup)
        {
            return Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase));
        }

        public int TotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    public class Step
    {
        public string Description { get; set; }
    }
}
