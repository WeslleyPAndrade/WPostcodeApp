using Microsoft.AspNetCore.Mvc;
using Wpostcode.AppService.Interfaces;

namespace Wpostcode.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressAppService _appService;

        public AddressController(IAddressAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("{postcode}")]
        public async Task<IActionResult> GetAddressByPostCode([FromRoute] string postcode)
        {
            try
            {
                var result = await _appService.GetAddressByPostCode(postcode);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
