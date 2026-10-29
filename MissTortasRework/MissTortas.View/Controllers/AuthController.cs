using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Security;
using MissTortas.View.ErrorHandling.Exceptions;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(ISecurityService securityService, IUserService userServices, IValidator<MissTortasRegisterRequest> registerRequestValidator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("signout")]
        public async Task<ActionResult> SignOutUser()
        {
            Response.Cookies.Append(
                "X-Access-Token",
                Guid.NewGuid().ToString().Replace("-", ""),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UnixEpoch
                });
            Response.Cookies.Append(
                "X-Refresh-Token",
                Guid.NewGuid().ToString().Replace("-", ""),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UnixEpoch
                });
            Response.Cookies.Append(
                ".AspNetCore.Identity.Application",
                Guid.NewGuid().ToString().Replace("-", ""),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UnixEpoch
                });

            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult> SignInUser(LoginRequest request)
        {
            var loginDto = new LoginUserDTO
            {
                Email = request.Email,
                Password = request.Password
            };
            var result = await securityService.SignInUserAsync(loginDto);

            if (result == null)
                throw new UserNotFoundException("User not found.", "USRNF1");

            if (!result.SignInResult.Succeeded)
            {
                 throw result.SignInResult switch
                {
                    { IsLockedOut: true } =>
                        new AuthenticationFailedException("User is locked out.", "USRLO1"),

                    { IsNotAllowed: true } =>
                        new AuthenticationFailedException("User is not allowed to sign in.", "USRNO1"),

                    { RequiresTwoFactor: true } =>
                        new AuthenticationFailedException("Two-factor authentication is required.", "USR2F1"),

                    _ => new AuthenticationFailedException("Invalid login attempt.", "USRINV1")
                };
            }

            Response.Cookies.Append("X-Access-Token", result.AccessToken,
                new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
            Response.Cookies.Append("X-Refresh-Token", result.RefreshToken,
                new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });

            return Ok(new { accessToken = result.AccessToken, refreshToken = result.RefreshToken });
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> SignUpUser(MissTortasRegisterRequest request)
        {
            await registerRequestValidator.ValidateAndThrowAsync(request);

            var createUserDTO = new CreateUserDTO
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Roles = [UserConstants.UserRoleName]
            };
            var userId = await userServices.CreateUserAsync(createUserDTO);
            var serviceDto = new SignUpUserDTO
            {
                UserId = userId,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };
            var result = await securityService.SignUpUserAsync(serviceDto);
            var identityResult = result.IdentityResult;
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(",", identityResult.Errors.Select(err => err.Description));
                throw new UserAlreadyCreatedException($"{errors}", "USRCONFLICT30");
            }
            return Ok(new { result.UserId });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest("Refresh token is required.");
            }
            var result = await securityService.RefreshTokenAsync(request.RefreshToken);
            if (result == null)
            {
                return Unauthorized("Invalid or expired refresh token.");
            }
            Response.Cookies.Append("X-Access-Token", result.AccessToken,
                new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
            Response.Cookies.Append("X-Refresh-Token", result.RefreshToken,
                new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
            return Ok(result);
        }
        public class RefreshTokenRequest
        {
            public string RefreshToken { get; set; } = string.Empty;
        }
    }
}
