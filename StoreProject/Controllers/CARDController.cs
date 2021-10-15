using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StoreProject.Controllers
{
    public class CARDController : Controller
    {
        // GET: CARD
        public ActionResult Index()
        {
            return View();
        }

        Models.DB db = new Models.DB();

        public ActionResult add(string x)
        {
            var q = from i in db.items where (i.code_mahsoul == x) select i;
            var qq = q.Single();
            if(q.Count()>=1 && qq.exist >= 1)
            {
                Models.Card c = new Models.Card();
                c.code_mahsoul = qq.code_mahsoul;
                c.img_src = qq.img_src;
                c.name = qq.name;
                c.prise = qq.prise;
                c.detail = qq.detail;
                db.card.Add(c);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult readall()
        {
            var q = from i in db.card select i;
            return Json(q.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(int id)
        {
            var q = from i in db.card where (i.id == id) select i;
            db.card.Remove(q.Single());
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(Models.item i)
        {
            var q = from b in db.card where (i.id == b.id) select b;
            Models.Card ii = new Models.Card();
            ii = q.Single();
            ii.name = i.name;
            ii.code_mahsoul = i.code_mahsoul;
            ii.prise = i.prise;
            ii.img_src = i.img_src;
            ii.detail = "1";
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult find(string x)
        {
            var q = from i in db.items where (i.code_mahsoul == x) select i;
            return Json(q.Single(), JsonRequestBehavior.AllowGet);
        }
    }
}