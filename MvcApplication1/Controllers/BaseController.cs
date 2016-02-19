using log4net;
using MvcApplication1.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            GlobalContext.Properties["UserName"] = "UserTest";
            GlobalContext.Properties["Source"] = "Server";
            LogHelper.Log(filterContext.Exception.Message, filterContext.Exception);
            filterContext.ExceptionHandled = true;
        }

    }
}
