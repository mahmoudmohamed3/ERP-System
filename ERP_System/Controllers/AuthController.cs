using ERP_System.Contracts.Authentication;
using ERP_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_System.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("")]
        public async Task<IActionResult> LoginAsync (LoginRequest request , CancellationToken cancellationToken)
        {
            var responseResult = await _authService.GetTokenAsync(request.email , request.password , cancellationToken);

            return responseResult is null
                ? BadRequest("Invalid Email/Password") 
                :Ok(responseResult);
        }
    }
}
