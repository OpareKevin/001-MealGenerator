namespace _001_MealGenerator;

public class RecipeApiClient : IRecipeApiClient
{
    private readonly HttpClient _client;

    public RecipeApiClient()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "YOUR_API_KEY");
        _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "the-mexican-food-db.p.rapidapi.com");
    }

    public async Task<string> GetRecipeAsync(string recipeId)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/random.php"),
        };

        using (var response = await _client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
