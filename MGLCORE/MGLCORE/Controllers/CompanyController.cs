
using Core.JWT;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MGLCORE.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IAuthApiService authApiService;
        private readonly ICompanyService companyService;

        public CompanyController(IAuthApiService _authApiService, ICompanyService _company)
        {
            authApiService = _authApiService;
            companyService = _company;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetCompany()
        {
            //string token = authApiService.SetToken(AccessToken token);
            //AccessToken token


            string jsonveri= authApiService.GetCompany().Result;
            Company company = JsonConvert.DeserializeObject<Company>(jsonveri);
            //string ad = "Veysel";
            return View("GetCompany", company);

           
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAddressCards()
        {
            //string token = authApiService.SetToken(AccessToken token);
            //AccessToken token


            string jsonveri = authApiService.GetAddressCardList().Result;
            ApiReturnData<Tbl_AdresKartlari> adresKartlari = JsonConvert.DeserializeObject<ApiReturnData<Tbl_AdresKartlari>>(jsonveri);
            //string ad = "Veysel";
            return View("GetAddressCards", adresKartlari.data);


        }

    }
}
