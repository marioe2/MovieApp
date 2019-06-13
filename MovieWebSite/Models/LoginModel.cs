using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebSite.Models
{
    public class test : UserBLL
    {

    }
     
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string ReturnURL { get; set; }
    }
}