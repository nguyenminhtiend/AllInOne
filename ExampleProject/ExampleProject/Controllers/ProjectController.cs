using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ExampleProject.Models;

namespace ExampleProject.Controllers
{
    public class ProjectController : Controller
    {
        private const int ItemPerPage = 5;
        private static ProjectModel projectModel;

        private static CriteriaSearch _criteriaSearch;
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
                        Customer = "Customer " + i.ToString(),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(i)
                    });
                }
            }
        }

        //
        // GET: /Project/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllProject()
        {
            return Json(new
            {
                Projects = ListProject.Take(10).Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Number = x.Number,
                    Customer = x.Customer,
                    StartDate = x.StartDate.ToShortDateString(),
                    EndDate = x.EndDate.ToShortDateString()
                }),
                TotalPage = 9,
                CurrentPage = 2
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
                    result = paramRequest.DirectionSort == "asc" ? result.OrderBy(x => x.Customer) : result.OrderByDescending(x => x.Customer);
                    break;
            }
            var projectSearchModel = new ProjectSearchModel
            {
                Page = new Paging
                {
                    CurrentPage = paramRequest.CurrentPage,
                    Total = totalItem / paramRequest.ItemPerPage
                },
                Projects = result.ToList()
            };
            return PartialView("_ListProject", projectSearchModel);
        }
        //
        // GET: /Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View(project);

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Temp1Data()
        {
            TempData["project"] = new Project { Name = "Project 1", Number = 11122 };
            return RedirectToAction("TempData1");
        }
        public ActionResult TempData1()
        {
            var project = TempData["project"] as Project;
            return View("Create", project);
        }

        public ActionResult CheckExist(int number)
        {
            //if (listProjects.Any(project => project.Number == number))
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
