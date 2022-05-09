using ContactList.Application.Interfaces;
using ContactList.Core.Dtos.Login;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageLoginController : ControllerBase
    {
        private readonly IManageLoginService service;

        public ManageLoginController(IManageLoginService service)
        {
            this.service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var response = await service.Login(dto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
