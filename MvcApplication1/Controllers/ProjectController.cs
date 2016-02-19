using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        private static List<Project> ListProject;

        public ProjectController()
        {
            if (ListProject == null)
            {
                ListProject = new List<Project>();
                for (int i = 0; i < 100; i++)
                {
                    ListProject.Add(new Project
                    {
                        Id = i,
                        Name = "Project " + i.ToString(),
                        Number = i,
                        Cusotmer = "Customer " + i.ToString(),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(i)
                    });
                }
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View(new ProjectTest());
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Create(ProjectTest projectTest)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        [HttpPost]
        public JsonResult GetData(ParamRequest paramRequest)
        {
            var query = new List<Project>();
            if (string.IsNullOrEmpty(paramRequest.SearchString))
            {
                query = ListProject;
            }
            else
            {
                query = ListProject.Where(x => x.Name.Contains(paramRequest.SearchString)).ToList();
            }
            var totalItem = query.Count;

            var result = query.Skip(paramRequest.CurrentPage * paramRequest.ItemPerPage).Take(paramRequest.ItemPerPage);

            switch (paramRequest.ColumnSort)
            {
                case 1:
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
                    break;
                case 2:
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Number) : result.OrderByDescending(x => x.Number);
                    break;
                case 3:
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Cusotmer) : result.OrderByDescending(x => x.Cusotmer);
                    break;
            }

            return Json(new
            {
                totalItem = totalItem,
                data = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetProject(ParamRequest paramRequest)
        {
            var query = new List<Project>();
            if (string.IsNullOrEmpty(paramRequest.SearchString))
            {
                query = ListProject;
            }
            else
            {
                query = ListProject.Where(x => x.Name.Contains(paramRequest.SearchString)).ToList();
            }
            var totalItem = query.Count;

            var result = query.Skip(paramRequest.CurrentPage * paramRequest.ItemPerPage).Take(paramRequest.ItemPerPage);

            switch (paramRequest.ColumnSort)
            {
                case 1:
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
                    break;
                case 2:
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Number) : result.OrderByDescending(x => x.Number);
                    break;
                case 3:
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Cusotmer) : result.OrderByDescending(x => x.Cusotmer);
                    break;
            }

            return PartialView("_ListProject", query);
        }

    }
}
