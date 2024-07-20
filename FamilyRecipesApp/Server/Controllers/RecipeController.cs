using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FamilyRecipesApp.Server.Data;
using FamilyRecipesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyRecipesApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RecipeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipes.OrderByDescending(r => r.CreatedAt).ToListAsync();
        }

        [HttpGet("user/{username}")]
        public async Task<ActionResult<List<Recipe>>> GetRecipesByUser(string username)
        {
            var recipes = await _context.Recipes
                .Where(r => r.UserName == username)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return Ok(recipes);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRecipe([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Add recipe to context
                _context.Recipes.Add(recipe);

                // Save changes to db
                await _context.SaveChangesAsync();

                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding recipe: {ex.Message}");
            }
        }

        // GET api/recipe/{recipeId}
        [HttpGet("{recipeId:int}")]
        // [Authorize]
        public async Task<IActionResult> GetRecipeById(int recipeId)
        {
            try
            {
                var recipe = await _context.Recipes.FindAsync(recipeId);

                if (recipe == null)
                {
                    return NotFound($"Recipe with ID '{recipeId}' not found.");
                }

                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error getting recipe: {ex.Message}");
            }
        }

        // PUT api/recipe/{recipeId}
        [HttpPut("{recipeId:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateRecipe(int recipeId, [FromBody] Recipe updatedRecipe)
        {
            if (recipeId != updatedRecipe.RecipeId)
            {
                return BadRequest("Recipe ID mismatch.");
            }

            _context.Entry(updatedRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(updatedRecipe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating recipe: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            try
            {
                var recipe = await _context.Recipes.FindAsync(id);
                if (recipe == null)
                {
                    return NotFound();
                }

                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();

                return NoContent(); // Or Ok() with a message if needed
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting recipe: {ex.Message}");
            }
        }
    }
}
