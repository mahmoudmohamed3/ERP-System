namespace ERP_System.Contracts.Authentication
{
    public record LoginRequest
    (
        string email,
        string password
    );
}
