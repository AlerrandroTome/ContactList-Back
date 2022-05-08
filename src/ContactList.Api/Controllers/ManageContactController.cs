using ContactList.Application.Interfaces;
using ContactList.Application.Services;
using ContactList.Core.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ContactList.Api.Controllers
{
    /*[Authorize]*/
    [ApiController]
    [ApiExplorerSettings]
    /*[ODataRoutePrefix("Contact")]*/
    [Route("api/[controller]")]
    public class ManageContactController : ODataController
    {
        private readonly IManageContactService _service;

        public ManageContactController(ManageContactService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto dto)
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
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            var response = await _service.Update(dto);
            return StatusCode(/*response.StatusCode*/200, response);
        }
    }
}
