using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        //UserData GetUserByID(Users user);
    }


    public class UserService : IUserService
    {
        private readonly IAuthApiService authApiService;
        public UserService(IAuthApiService _authApiService)
        {
            authApiService = _authApiService;
        }

        //public UserData GetUserByID(Users user)
        //{

        //    var jsonData = authApiService.GetUser("getuser", user).Result;

        //    return JsonConvert.DeserializeObject<UserData>(jsonData);

        //}


    }

    //public class UserData
    //{
    //    public Users data { get; set; }
    //    public int statusCode { get; set; }
    //    public object error { get; set; }

    //}

    

    //public class Token
    //{


    //    public Data data { get; set; }
    //    public int statusCode { get; set; }
    //    public object error { get; set; }

    //}
    //public class Data
    //{
    //    public int id { get; set; }
    //    public int userId { get; set; }
    //    public string token { get; set; }
    //    public DateTime expiration { get; set; }
    //    public object guid { get; set; }
    //}
}
