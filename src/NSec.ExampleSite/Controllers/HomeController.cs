using NSec;
using NSec.Infrastructure;
using NSec.Model;
using NSec.Repositories;
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
            var events = ServiceFactory.GetInstance<IDataContext>().SecurityEvents.Query.ToArray();
            return View(events);
        }

        public ActionResult UnsuccessfulLoginAttempt()
        {
            NSecManager.ReportSecurityEvent(EventType.UnsuccessfulLoginAttempt);
            return Redirect("/");
        }

        public ActionResult Clear()
        {
            NSecManager.UnlockCurrentProfile();
            return Redirect("/");
        }
    }
}