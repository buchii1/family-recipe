namespace FamilyRecipesApp.Shared.Models
{
    // Model representing the current user
    public class CurrentUser
    {
        // Indicates whether the user is authenticated
        public bool IsAuthenticated { get; set; }
        
        // Stores the username of the current user
        public string UserName { get; set; }
        
        // Stores the claims associated with the current user
        // Key: Claim type, Value: Claim value
        public Dictionary<string, string> Claims { get; set; }
    }
}
