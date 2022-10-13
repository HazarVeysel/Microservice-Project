using Business.Concrete;
using Core.Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EntryTypeController : Controller
    {
        private readonly IEntryTypeService _entrytypeService;

        public EntryTypeController(IEntryTypeService entrytypeService)
        {
            _entrytypeService = entrytypeService;
        }

        //----------------

        [HttpGet("getentrytypelist")]
        public IActionResult GetEntryTypeList()
        {
            var result = _entrytypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //-----------

        [HttpPost("AddEntryType")]
        public IActionResult AddEntryType(EntryType entrytype)
        {
            var result = _entrytypeService.Add(entrytype);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}