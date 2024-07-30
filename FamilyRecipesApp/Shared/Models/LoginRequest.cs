using System.ComponentModel.DataAnnotations;

namespace FamilyRecipesApp.Shared.Models
{
    // Model representing a login request
    public class LoginRequest
    {
        // The username of the user attempting to log in
        [Required]
        public string UserName { get; set; }

        // The password of the user attempting to log in
        [Required]
        public string Password { get; set; }

        // Indicates whether the user wants to be remembered across sessions
        public bool RememberMe { get; set; }
    }
}
