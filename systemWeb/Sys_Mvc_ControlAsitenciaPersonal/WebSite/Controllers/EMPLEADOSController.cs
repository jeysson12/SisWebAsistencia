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
    public class EMPLEADOSController : Controller
    {
        private sys_web_controlAsistenciaPersonalEntities db = new sys_web_controlAsistenciaPersonalEntities();

        // GET: EMPLEADOS
        public ActionResult Index()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var eMPLEADOS = db.EMPLEADOS.Include(e => e.AREAS).Include(e => e.CARGOS).Include(e => e.DISTRITOS);
                return View(eMPLEADOS.ToList());
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        // GET: EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {

                if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
                    if (eMPLEADOS == null)
                    {
                        return HttpNotFound();
                    }
                    return View(eMPLEADOS);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: EMPLEADOS/Create
        public ActionResult Create()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", "-1");
                ViewBag.ID_CARGO = new SelectList(new List<SelectListItem> { new SelectListItem { Selected = true, Text = string.Empty, Value = "-1" } }, "Value", "Text");//new SelectList(db.CARGOS, "ID_CARGOS", "NOMBRE");
                ViewBag.ID_DISTRITO = new SelectList(db.DISTRITOS, "ID_DISTRITO", "NOMBRE");
                return View();
            }
            else {
                return RedirectToAction("Index", "Login");
            }

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DNI,NOMBRES,APELLIDOS,SEXO,HORA_INGRESO,HORA_SALIDA,ID_AREA,ID_CARGO,ID_DISTRITO,DIRECCION,TELEFONO,CELULAR")] EMPLEADOS eMPLEADOS)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.EMPLEADOS.Add(eMPLEADOS);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", eMPLEADOS.ID_AREA);
                ViewBag.ID_CARGO = new SelectList(db.CARGOS.Where(c => c.ID_AREA == eMPLEADOS.ID_AREA).ToList(), "ID_CARGOS", "NOMBRE", eMPLEADOS.ID_CARGO);
                ViewBag.ID_DISTRITO = new SelectList(db.DISTRITOS, "ID_DISTRITO", "NOMBRE", eMPLEADOS.ID_DISTRITO);
                return View(eMPLEADOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AjaxAreas_Cargos(int ID_AREA)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var a = db.CARGOS.Where(c => c.ID_AREA == ID_AREA).ToList();
                var b = db.CARGOS.Find(ID_AREA);
                if (HttpContext.Request.IsAjaxRequest())
                {
                    return Json(db.CARGOS.Where(c => c.ID_AREA == ID_AREA).ToList().Select(c => new SelectListItem
                    {
                        Value = c.ID_CARGOS.ToString(),
                        Text = c.NOMBRE
                    }).ToList(), JsonRequestBehavior.AllowGet);
                }
                return View();
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
                if (eMPLEADOS == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", eMPLEADOS.ID_AREA);
                ViewBag.ID_CARGO = new SelectList(db.CARGOS, "ID_CARGOS", "NOMBRE", eMPLEADOS.ID_CARGO);
                ViewBag.ID_DISTRITO = new SelectList(db.DISTRITOS, "ID_DISTRITO", "NOMBRE", eMPLEADOS.ID_DISTRITO);
                return View(eMPLEADOS);
            }else{
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: EMPLEADOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPLEADO,DNI,NOMBRES,APELLIDOS,SEXO,HORA_INGRESO,HORA_SALIDA,ID_AREA,ID_CARGO,ID_DISTRITO,DIRECCION,TELEFONO,CELULAR")] EMPLEADOS eMPLEADOS)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(eMPLEADOS).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_AREA = new SelectList(db.AREAS, "ID_AREA", "NOMBRE", eMPLEADOS.ID_AREA);
                ViewBag.ID_CARGO = new SelectList(db.CARGOS.Where(c => c.ID_AREA == eMPLEADOS.ID_AREA), "ID_CARGOS", "NOMBRE", eMPLEADOS.ID_CARGO);
                ViewBag.ID_DISTRITO = new SelectList(db.DISTRITOS, "ID_DISTRITO", "NOMBRE", eMPLEADOS.ID_DISTRITO);
                return View(eMPLEADOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
                if (eMPLEADOS == null)
                {
                    return HttpNotFound();
                }
                return View(eMPLEADOS);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
                db.EMPLEADOS.Remove(eMPLEADOS);
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
