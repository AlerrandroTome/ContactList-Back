using ContactList.Application.Services;
using ContactList.Core.Dtos.User;
using ContactList.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ContactListWebApi.Controllers
{
    /*[Authorize]*/
    [ApiController]
    [ApiExplorerSettings]
    /*[ODataRoutePrefix("User")]*/
    [Route("api/[controller]")]
    public class ManageUserController : ODataController
    {
        private readonly IManageUserService _service;

        public ManageUserController(ManageUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var response = await _service.Create(dto);
            return StatusCode(/*response.StatusCode*/200, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.Delete(id);
            return StatusCode(/*response.StatusCode*/200, response);
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        /*[ODataRoute]*/
        virtual public IActionResult Get() => Ok(_service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            var response = await _service.Update(dto);
            return StatusCode(/*response.StatusCode*/200, response);
        }
    }
}
