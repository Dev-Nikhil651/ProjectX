using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication24.Controllers.LoginController
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Username and password are required.";
                return View();
            }

            string encryptedPassword = CryptoHelper.EncryptPassword(username, password);
            string decryptedPassword = CryptoHelper.DecryptPassword(username, encryptedPassword);

            ViewBag.EncryptedPassword = encryptedPassword;
            ViewBag.DecryptedPassword = decryptedPassword;

            return View();
        }
    }
}