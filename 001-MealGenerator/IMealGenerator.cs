using _001_MealGenerator.Models;

namespace _001_MealGenerator;

public interface IMealGenerator
{ Task<Meal> GetRandomRecipeAsync();
}