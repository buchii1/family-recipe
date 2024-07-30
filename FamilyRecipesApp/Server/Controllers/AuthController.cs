using FamilyRecipesApp.Server.Models;
using FamilyRecipesApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRecipesApp.Server.Controllers
{
    // Defines the base route for the controller and marks it as an API controller
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        // Constructor to initialize UserManager and SignInManager
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Endpoint to handle user login
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // Find the user by username
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return BadRequest("User does not exist");

            // Check if the password is correct
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            // Sign in the user
            await _signInManager.SignInAsync(user, request.RememberMe);
            return Ok();
        }

        // Endpoint to handle user registration
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            var user = new ApplicationUser
            {
                UserName = parameters.UserName
            };

            // Create the user with the provided password
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            // Automatically log in the user after registration
            return await Login(new LoginRequest
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }

        // Endpoint to handle user logout, requires authorization
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Sign out the user
            await _signInManager.SignOutAsync();
            return Ok();
        }

        // Endpoint to get the current user's information
        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
            return new CurrentUser
            {
                IsAuthenticated = User.Identity!.IsAuthenticated,
                UserName = User.Identity.Name!,
                Claims = User.Claims.ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}
