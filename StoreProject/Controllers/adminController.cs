using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StoreProject.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }

        Models.DB db = new Models.DB();

        public ActionResult readall()
        {
            var q = from i in db.items select i;
            return Json(q.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(int id)
        {
            var q = from i in db.items where (i.id == id) select i;
            db.items.Remove(q.Single());
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(Models.item i)
        {
            var q = from b in db.items where (i.id == b.id) select b;
            Models.item ii = new Models.item();
            ii = q.Single();
            ii.name = i.name;
            ii.code_mahsoul = i.code_mahsoul;
            ii.prise = i.prise;
            ii.img_src = i.img_src;
            ii.detail = i.detail;
            ii.exist = i.exist;
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult find(string x)
        {
            var q = from i in db.items where (i.code_mahsoul == x) select i;
            return Json(q.Single(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult create(Models.item it)
        {
            db.items.Add(it);
            db.SaveChanges();

            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}