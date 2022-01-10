using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.Text;
using Tasks_managers.data;
using Tasks_managers.Service;

namespace Tasks_managers.Controllers
{
    public class UserController : Controller
    {
        IUserService user;
        public UserController(IUserService _user)
        {
            user = _user;

        }
        public IActionResult Login_Page()
        {

            return View("Login");
        }
        public IActionResult Login(user userr)
        {

            string password = userr.ENCPassword;

            string hashedData = ComputeStringToSha256Hash(password);

           user user1 = user.Checkuser(userr.email,hashedData);
            if (user1 != null)
            {

               return RedirectToAction("Load_Tasks","Task");
            }

            static string ComputeStringToSha256Hash(string pass)
            {
                // Create a SHA256 hash from string   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // Computing Hash - returns here byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

                    // now convert byte array to a string   
                    StringBuilder stringbuilder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        stringbuilder.Append(bytes[i].ToString("x2"));
                    }
                    return stringbuilder.ToString();
                }

               
            }

            ViewData["message"] = "Passwored or username or email is incorrect";
            return View("Login");

        }

       

       
    }
}
