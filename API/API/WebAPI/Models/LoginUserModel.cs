using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIQRI.EMP.WebAPI.Models
{
    public class LoginUserModel
    {
        //[JsonProperty("username")]
        public string UserName { get; set; }

        //[JsonProperty("password")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
