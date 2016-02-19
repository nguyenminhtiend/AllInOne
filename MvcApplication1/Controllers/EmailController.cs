using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/

        public ActionResult Index()
        {
            // Save the Excel spreadsheet to a MemoryStream and return it to the client
            using (var exportData = new MemoryStream())
            {
                NpoiExport.GetWorkbook().Write(exportData);
                string saveAsFileName = string.Format("MembershipExport-{0:d}.xls", DateTime.Now).Replace("/", "-");
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
                Response.Clear();
                Response.BinaryWrite(exportData.GetBuffer());
                Response.End();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Send(EmailViewModel emailViewModel)
        {
            return RedirectToAction("Index");
        }

    }
}
