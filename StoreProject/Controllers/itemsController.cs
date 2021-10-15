using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading;
namespace StoreProject.Controllers
{
    public class itemsController : Controller
    {
        // GET: items
        public ActionResult Index()
        {
            return View();
        }

        Models.DB db = new Models.DB();
        Models.DATA qq = new Models.DATA();
        public Models.DATA send(int x)
        {
            var q = from i in db.data where (i.id == x) select i;
            return q.Single();
        }

        public ActionResult send2()
        {
            var data = from i in db.data select i.id;
            if (!(data.Count() >= 1))
            {
                revers();
            }
            else if (data.Count() >= 2)
            {
                send(data.Max());
            }
            else
            {
                send(data.Single());
            }
            var q = send(data.Max());
            qq = q;
            db.data.Remove(q);
            db.SaveChanges();
            return Json(qq, JsonRequestBehavior.AllowGet);
        }

        public ActionResult revers()
        {
            foreach (var i in db.items)
            {
                Models.DATA d = new Models.DATA();
                d.name = i.name;
                d.code_mahsoul = i.code_mahsoul;
                d.prise = i.prise;
                d.detail = i.detail;
                d.img_src = i.img_src;
                d.exist = i.exist;
                db.data.Add(d);
            }         
            db.SaveChanges();
            return Json(0,JsonRequestBehavior.AllowGet);
        }

       

      

     

       


      
       
    }
}