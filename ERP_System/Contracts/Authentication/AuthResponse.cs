using Microsoft.AspNetCore.Http.Features;

namespace ERP_System.Contracts.Authentication
{
    public record AuthResponse(
        string id,
        string? email,
        string FirstName,
        string LastName,
        string Token,
        int expiresIn
    );
    
}
