using System.ComponentModel.DataAnnotations;

namespace FamilyRecipesApp.Shared.Models
{
    public class UserProfile
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Bio { get; set; }
        public string? ProfileImg { get; set; }

        // public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}