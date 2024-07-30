using System.ComponentModel.DataAnnotations;

namespace FamilyRecipesApp.Shared.Models
{
    // Model representing a user's profile
    public class UserProfile
    {
        // Unique identifier for the user, used as the primary key
        [Key]
        public string UserName { get; set; }

        // First name of the user
        [Required]
        public string FirstName { get; set; }

        // Last name of the user
        [Required]
        public string LastName { get; set; }

        // Email address of the user, must be in a valid email format
        [Required, EmailAddress]
        public string Email { get; set; }

        // Brief biography of the user
        [Required]
        public string Bio { get; set; }

        // Optional URL for the user's profile image
        public string? ProfileImg { get; set; }
    }
}
