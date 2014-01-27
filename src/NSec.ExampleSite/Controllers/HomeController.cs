using NSec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSec.ExampleSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnsuccessfulLoginAttempt()
        {
            NSecManager.ReportSecurityEvent(EventType.UnsuccessfulLoginAttempt);
            return View("Index");
        }
    }
}