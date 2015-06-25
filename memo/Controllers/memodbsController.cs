using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using memo.Models;

namespace memo.Controllers
{
    public class memodbsController : Controller
    {
        private Entities db = new Entities();

        // GET: memodbs
        public ActionResult Index()
        {
            return View(db.memodb.ToList());
        }

        // GET: memodbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memodb memodb = db.memodb.Find(id);
            if (memodb == null)
            {
                return HttpNotFound();
            }
            return View(memodb);
        }

        // GET: memodbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: memodbs/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,detail,state")] memodb memodb)
        {
            if (ModelState.IsValid)
            {
                db.memodb.Add(memodb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memodb);
        }

        // GET: memodbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memodb memodb = db.memodb.Find(id);
            if (memodb == null)
            {
                return HttpNotFound();
            }
            return View(memodb);
        }

        // POST: memodbs/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,detail,state")] memodb memodb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memodb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memodb);
        }

        // GET: memodbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memodb memodb = db.memodb.Find(id);
            if (memodb == null)
            {
                return HttpNotFound();
            }
            return View(memodb);
        }

        // POST: memodbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            memodb memodb = db.memodb.Find(id);
            db.memodb.Remove(memodb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
