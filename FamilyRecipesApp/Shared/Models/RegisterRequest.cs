using System.ComponentModel.DataAnnotations;

namespace FamilyRecipesApp.Shared.Models
{
    // Model representing a user registration request
    public class RegisterRequest
    {
        // The username of the user registering
        [Required]
        public string UserName { get; set; }

        // The password of the user registering
        [Required]
        public string Password { get; set; }

        // Confirmation of the password to ensure it matches the original password
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string PasswordConfirm { get; set; }
    }
}
