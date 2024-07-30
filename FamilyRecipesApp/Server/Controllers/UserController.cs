using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FamilyRecipesApp.Shared.Models;
using FamilyRecipesApp.Server.Models;

namespace FamilyRecipesApp.Server.Controllers
{
    [Authorize]  // Ensure the user is authenticated
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        // Constructor to initialize UserManager
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Endpoint to get user profile by username
        [HttpGet("{username}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserProfile>> GetUserProfile(string username)
        {
            // Find user by username
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            // Map ApplicationUser to UserProfile
            var userProfile = new UserProfile
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Bio = user.Bio,
                ProfileImg = user.ProfileImg
            };

            return Ok(userProfile);
        }

        // Endpoint to update user profile
        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfile userProfile)
        {
            if (userProfile == null)
            {
                return BadRequest("User profile is null.");
            }

            // Get the authenticated user's username
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Update the user's profile
            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;
            user.Email = userProfile.Email;
            user.Bio = userProfile.Bio;
            user.ProfileImg = userProfile.ProfileImg;

            // Save changes to the database
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating profile.");
            }
        }
    }
}
