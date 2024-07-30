using System.Net.Http.Json;
using FamilyRecipesApp.Shared.Models;

namespace FamilyRecipesApp.Client.Services
{
    // Interface defining the authentication service methods
    public interface IAuthService
    {
        Task Login(LoginRequest loginRequest); // Method to handle user login
        Task Register(RegisterRequest registerRequest); // Method to handle user registration
        Task Logout(); // Method to handle user logout
        Task<CurrentUser> CurrentUserInfo(); // Method to get the current user's information
    }

    // Implementation of the IAuthService interface
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient; // HttpClient to make HTTP requests

        // Constructor to initialize the HttpClient
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get the current user's information
        public async Task<CurrentUser> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/auth/currentuserinfo"); // Send GET request to get current user info
            return result!; // Return the result
        }

        // Method to handle user login
        public async Task Login(LoginRequest loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest); // Send POST request to login
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(await result.Content.ReadAsStringAsync()); // Throw exception if status code is BadRequest
            result.EnsureSuccessStatusCode(); // Ensure the request was successful
        }

        // Method to handle user logout
        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/auth/logout", null); // Send POST request to logout
            result.EnsureSuccessStatusCode(); // Ensure the request was successful
        }

        // Method to handle user registration
        public async Task Register(RegisterRequest registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest); // Send POST request to register
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(await result.Content.ReadAsStringAsync()); // Throw exception if status code is BadRequest
            result.EnsureSuccessStatusCode(); // Ensure the request was successful
        }
    }
}
