using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class CARGOSController : Controller
    {
        private sys_web_controlAsistenciaPersonalEntities db = new sys_web_controlAsistenciaPersonalEntities();

        // GET: CARGOS
        public ActionResult Index()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var cARGOS = db.CARGOS.Include(c => c.AREAS);
                return View(cARGOS.ToList());
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: CARGOS/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CARGOS cARGOS = db.CARGOS.Find(id);
                if (cARGOS == null)
                {
                    return HttpNotFound();
                }
                return View(cARGOS);
                }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: CARGOS/Create
        public ActionResult Create()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMBRE,ID_AREA")] CARGOS cARGOS)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.CARGOS.Add(cARGOS);
                    db.SaveChanges();
                    this.Response.RemoveOutputCacheItem(Url.Action("Index").ToString());
                    return RedirectToAction("Index");
                }

                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", cARGOS.ID_AREA);
                return View(cARGOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: CARGOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CARGOS cARGOS = db.CARGOS.Find(id);
                if (cARGOS == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", cARGOS.ID_AREA);
                return View(cARGOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CARGOS,NOMBRE,ID_AREA")] CARGOS cARGOS)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cARGOS).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", cARGOS.ID_AREA);
                return View(cARGOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: CARGOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CARGOS cARGOS = db.CARGOS.Find(id);
                if (cARGOS == null)
                {
                    return HttpNotFound();
                }
                return View(cARGOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: CARGOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                CARGOS cARGOS = db.CARGOS.Find(id);
                db.CARGOS.Remove(cARGOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
