using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnProject.Areas.Default.Controllers;

namespace LearnProject.Areas.Default.Controllers
{
    public class RoleController : DefaultController
    {
        // GET: Role
        public ActionResult Index()
        {
            var roles = Repository.Roles.ToList();
            return View(roles);
        }
    }
}