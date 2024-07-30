using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FamilyRecipesApp.Server.Models
{
    // ApplicationUser class extends IdentityUser to include additional user-related properties
    public class ApplicationUser : IdentityUser
    {
        // Property for storing the user's first name
        public string? FirstName { get; set; }

        // Property for storing the user's last name
        public string? LastName { get; set; }

        // Property for storing a brief biography or description of the user
        public string? Bio { get; set; }

        // Property for storing the URL or path of the user's profile image
        public string? ProfileImg { get; set; }
    }
}
