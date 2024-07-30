using System.ComponentModel.DataAnnotations;

namespace FamilyRecipesApp.Shared.Models
{
    // Model representing a recipe
    public class Recipe
    {
        // Unique identifier for the recipe
        [Key]
        public int RecipeId { get; set; }
        
        // Title of the recipe
        [Required]
        public string Title { get; set; }
        
        // Description of the recipe
        [Required]
        public string Description { get; set; }
        
        // List of ingredients required for the recipe
        [Required]
        public string Ingredients { get; set; }
        
        // Step-by-step preparation instructions for the recipe
        [Required]
        public string PreparationSteps { get; set; }
        
        // Date and time when the recipe was created
        public DateTime CreatedAt { get; set; }
        
        // Optional image URL for the recipe
        public string? RecipeImg { get; set; }
        
        // Username of the person who created the recipe
        public string UserName { get; set; }
    }
}
