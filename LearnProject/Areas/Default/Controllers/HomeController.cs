using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnProject.Model;
using Ninject;
using LearnProject.Areas.Default.Controllers;

namespace LearnProject.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {

        // GET: Home
        public ActionResult Index()
        {
            //var cookie = new HttpCookie("test_cookie")
            //{
            //    Name = "test_cookie",
            //    Value = DateTime.Now.ToString("dd.MM.yyyy"),
            //    Expires = DateTime.Now.AddMinutes(10),
            //};
            //Response.SetCookie(cookie);

            //var cookie = Request.Cookies["test_cookie"];
            //var value = cookie.Value;

            return View();
        }
        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}