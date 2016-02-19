using System;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var project = new Project {Status = Status.Pending};
            return View(project);
        }

    }
}
