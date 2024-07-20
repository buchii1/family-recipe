using System.ComponentModel.DataAnnotations;

namespace FamilyRecipesApp.Shared.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string PreparationSteps { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? RecipeImg { get; set; }
        public string UserName { get; set; }
    }
}