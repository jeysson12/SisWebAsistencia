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
    public class USUARIOSController : Controller
    {
        private sys_web_controlAsistenciaPersonalEntities db = new sys_web_controlAsistenciaPersonalEntities();

        // GET: USUARIOS
        public ActionResult Index()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var uSUARIOS = db.USUARIOS.Include(u => u.EMPLEADOS);
                return View(uSUARIOS.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(string id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIOS uSUARIOS = db.USUARIOS.Find(id);
                if (uSUARIOS == null)
                {
                    return HttpNotFound();
                }
                return View(uSUARIOS);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADOS, "ID_EMPLEADO", "DNI");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,CONTRASEÑA,TIPO,ID_EMPLEADO,ACTIVO")] USUARIOS uSUARIOS)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.USUARIOS.Add(uSUARIOS);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADOS, "ID_EMPLEADO", "DNI", uSUARIOS.ID_EMPLEADO);
                return View(uSUARIOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIOS uSUARIOS = db.USUARIOS.Find(id);
                if (uSUARIOS == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADOS, "ID_EMPLEADO", "DNI", uSUARIOS.ID_EMPLEADO);
                return View(uSUARIOS);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,CONTRASEÑA,TIPO,ID_EMPLEADO,ACTIVO")] USUARIOS uSUARIOS)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(uSUARIOS).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADOS, "ID_EMPLEADO", "DNI", uSUARIOS.ID_EMPLEADO);
                return View(uSUARIOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIOS uSUARIOS = db.USUARIOS.Find(id);
                if (uSUARIOS == null)
                {
                    return HttpNotFound();
                }
                return View(uSUARIOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                USUARIOS uSUARIOS = db.USUARIOS.Find(id);
                db.USUARIOS.Remove(uSUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }else
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
