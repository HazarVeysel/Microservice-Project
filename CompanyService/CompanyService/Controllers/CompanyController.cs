using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CompanyController : ControllerBase
    {
        [Authorize]
        [HttpGet]        
        public IActionResult Get()
        {
            return Content("{ \"name\":\"John\", \"age\":31, \"city\":\"New York\" }", "application/json");
        }

        

    }
}