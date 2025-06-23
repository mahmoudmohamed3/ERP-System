using ERP_System.Authentication;
using ERP_System.Contracts.Authentication;
using ERP_System.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace ERP_System.Services
{
    public class AuthService (UserManager<ApplicationUser> userManager , IJwtProvider jwtProvider): IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<AuthResponse?> GetTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user is null)
            {
                return null;
            }

            var isVaild = await _userManager.CheckPasswordAsync(user, Password);

            if (!isVaild)
            {
                return null;
            }


            var (Token, expiresIn) = _jwtProvider.GenerateToken(user);

            return new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, Token, expiresIn);
            
        }
    }
}
