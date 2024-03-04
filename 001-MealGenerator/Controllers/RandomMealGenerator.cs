using _001_MealGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace _001_MealGenerator.Controllers
{
    public class RandomMealGenerator : Controller
    {
        private readonly IRecipeApiClient _recipeApiClient;
        private readonly IMealGenerator _mealGeneratorService;

        public RandomMealGenerator(IRecipeApiClient recipeApiClient, IMealGenerator mealGeneratorService)
        {
            _recipeApiClient = recipeApiClient;
            _mealGeneratorService = mealGeneratorService;
        }
        
        [HttpGet("GenerateRandomMeal")]
        public async Task<IActionResult> Recipe()
        {
            try
            {
                Meal recipe = await _mealGeneratorService.GetRandomRecipeAsync();

                return View("Recipe", recipe); // Specify the full path
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }   
    }
}