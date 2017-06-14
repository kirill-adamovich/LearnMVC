using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnProject.Model;
using LearnProject.Models.Info;
using LearnProject.Models.ViewModels;
using LearnProject.Tools;
using LearnProject.Areas.Default.Controllers;
using LearnProject.Attribute.Validation;

namespace LearnProject.Areas.Default.Controllers
{
    public class UserController : DefaultController
    {
        // GET: User
        public ActionResult Index(int page = 1)
        {
            var data = new PageableData<User>(Repository.Users, page, 30);
            //var users = Repository.Users.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var newUserView = new UserView();
            return View(newUserView);
        }

        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            if (userView.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "UC. Текст с картинки введен неверно");
            }
            var anyUser = Repository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "UC. Пользователь с таким email уже зарегистрирован");
            }

            if (ModelState.IsValid)
            {
                var user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));
                Repository.CreateUser(user);
                return RedirectToAction("Index");
            }

            return View(userView);
        }

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }
    }
}