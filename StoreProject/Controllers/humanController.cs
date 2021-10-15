using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StoreProject.Controllers
{
    public class humanController : Controller
    {
        // GET: human
        public ActionResult Index()
        {
            return View();
        }
        Models.DB db = new Models.DB();

        public ActionResult rgister(Models.human h)
        {
            Models.human h1 = new Models.human();
            h1.name = h.name;
            h1.family = h.family;
            h1.number = h.number;
            db.humen.Add(h1);
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }



        public ActionResult singin(Models.human h)
        {
            var q = from i in db.humen where (h.number == i.number && h.family == i.family) select i;
            if (q.Count() >= 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}