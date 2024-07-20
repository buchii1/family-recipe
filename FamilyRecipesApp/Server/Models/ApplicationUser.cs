using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FamilyRecipesApp.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // [Required, EmailAddress]
        // public string Email { get; set; }
        public string? Bio { get; set; }

        public string? ProfileImg { get; set; }
    }
}