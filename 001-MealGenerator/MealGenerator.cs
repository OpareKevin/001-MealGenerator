using _001_MealGenerator.Models;
using Newtonsoft.Json;

namespace _001_MealGenerator;

public class MealGenerator: IMealGenerator
{
    private readonly IRecipeApiClient _recipeApiClient;


    public MealGenerator(IRecipeApiClient recipeApiClient)
    {
        _recipeApiClient = recipeApiClient;
    }
    
    public async Task<Meal> GetRandomRecipeAsync()
    {
        try
        {
            var randomRecipeId = await _recipeApiClient.GetRecipeAsync("");
            var recipeResponse = await _recipeApiClient.GetRecipeAsync(randomRecipeId);

            if (!string.IsNullOrEmpty(recipeResponse))
            {
                using (var jsonReader = new StringReader(recipeResponse))
                using (var reader = new JsonTextReader(jsonReader))
                {
                    var serializer = new JsonSerializer();
                    var root = serializer.Deserialize<Root>(reader);
                    if (root?.Meals is { Count: > 0 })
                    {
                        return root.Meals[0];
                    }
                }
            }

            return new Meal();
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately (e.g., log or throw)
            // For now, returning a new empty Meal object, but you might want to handle errors more gracefully
            return new Meal();
        }
    }
}