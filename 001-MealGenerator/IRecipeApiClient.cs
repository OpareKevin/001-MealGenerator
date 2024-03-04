namespace _001_MealGenerator;

public interface IRecipeApiClient
{
    Task<string> GetRecipeAsync(string recipeId);
}