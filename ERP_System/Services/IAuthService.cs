using ERP_System.Contracts.Authentication;

namespace ERP_System.Services
{
    public interface IAuthService
    {
        Task <AuthResponse?> GetTokenAsync (string Email , string Password , CancellationToken cancellationToken = default);
    }
}
