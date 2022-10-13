using Business.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AddressCardController : ControllerBase
    {
        private readonly IAddressCardService _addresscardService;

        public AddressCardController(IAddressCardService addresscardService)
        {
            _addresscardService = addresscardService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAddressCardList()
        {
            var result = _addresscardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
