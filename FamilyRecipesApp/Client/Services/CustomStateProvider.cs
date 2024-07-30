using System.Security.Claims;
using FamilyRecipesApp.Client.Services;
using FamilyRecipesApp.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService api; // API service for authentication
    private CurrentUser _currentUser; // Holds the current user's information

    // Constructor to initialize the IAuthService
    public CustomStateProvider(IAuthService api)
    {
        this.api = api;
    }

    // Overrides the GetAuthenticationStateAsync method to provide the current authentication state
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(); // Initialize an empty ClaimsIdentity
        try
        {
            var userInfo = await GetCurrentUser(); // Get the current user's info
            if (userInfo.IsAuthenticated)
            {
                // Create claims based on the current user's info
                var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName )}
                    .Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                identity = new ClaimsIdentity(claims, "Server authentication"); // Create a ClaimsIdentity with the user's claims
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString()); // Log the exception if the request fails
        }

        return new AuthenticationState(new ClaimsPrincipal(identity)); // Return the AuthenticationState
    }

    // Gets the current user's info, caches it, and returns it
    private async Task<CurrentUser> GetCurrentUser()
    {
        if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser; // Return cached user info if already authenticated
        _currentUser = await api.CurrentUserInfo(); // Fetch the current user's info from the API
        return _currentUser;
    }

    // Logs out the user and notifies about the authentication state change
    public async Task Logout()
    {
        await api.Logout(); // Call the API to log out
        _currentUser = null!; // Clear the current user's info
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync()); // Notify about the authentication state change
    }

    // Logs in the user and notifies about the authentication state change
    public async Task Login(LoginRequest loginParameters)
    {
        await api.Login(loginParameters); // Call the API to log in
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync()); // Notify about the authentication state change
    }

    // Registers the user and notifies about the authentication state change
    public async Task Register(RegisterRequest registerParameters)
    {
        await api.Register(registerParameters); // Call the API to register
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync()); // Notify about the authentication state change
    }
}
