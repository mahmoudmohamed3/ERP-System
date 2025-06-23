using ERP_System.Persistence.Entities;

namespace ERP_System.Authentication
{
    public interface IJwtProvider
    {
        (string Token, int ExpiresIn) GenerateToken(ApplicationUser user);
    }
}
