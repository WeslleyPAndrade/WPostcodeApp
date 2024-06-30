using Microsoft.AspNetCore.Mvc;
using Wpostcode.AppService.Interfaces;

namespace Wpostcode.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAppService _appService;

        public AddressController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("{postcode}")]
        public async Task<IActionResult> GetAddressByPostCode(string postCode)
        {
            try
            {
                var result = _appService.GetAddressByPostCode(postCode);

                return Ok(result );
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
