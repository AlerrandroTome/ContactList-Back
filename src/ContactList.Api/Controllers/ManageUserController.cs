using ContactList.Core.Dtos.User;
using ContactList.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ContactList.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings]
    [Route("api/[controller]")]
    public class ManageUserController : ODataController
    {
        private readonly IManageUserService service;

        public ManageUserController(IManageUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var response = await service.Create(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await service.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        virtual public IActionResult Get() => Ok(service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            var response = await service.Update(dto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
