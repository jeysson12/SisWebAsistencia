using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.serv;

namespace WebSite.Controllers
{ 
    public class AreasController : Controller
    {
        readonly IAreasRepositorio _areaRepositorio;

        public AreasController()
        {
            _areaRepositorio = new AreasRepositorio();
        }

        public AreasController(IAreasRepositorio repositorio)
        {
            _areaRepositorio = repositorio;
        }

        public ActionResult listarAreasTest()
        {
            var model = _areaRepositorio.ListarAreasT();
            return View(model);
        }

        sys_web_controlAsistenciaPersonalEntities db = new sys_web_controlAsistenciaPersonalEntities();
        
        public ActionResult Index()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var query = (from a in db.AREAS select a).ToList();
                return View(query);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Areas/Details/5
        public ActionResult Details(int id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                return View();
            }else
                {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Areas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMBRE")]AREAS Model)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.AREAS.Add(Model);
                        db.SaveChanges();
                        this.Response.RemoveOutputCacheItem(Url.Action("Index").ToString());
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        return View(Model);
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", ex);
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        

        // GET: Areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var query = db.AREAS.Find(id);
                if (query == null)
                {
                    return this.HttpNotFound();
                }
                return View(query);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Areas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AREAS areas)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var query = (db.AREAS.Find(id));
                if (query == null)
                {
                    return this.HttpNotFound();
                }
                if (!ModelState.IsValid)
                {
                    return View(areas);
                }
                if (!TryUpdateModel(query, new string[] { "NOMBRE" }))
                {
                    return View(areas);
                }
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                    return View(areas);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var query = db.AREAS.Find(id);
                if (query == null)
                {
                    return this.HttpNotFound();
                }
                return View(query);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Areas/Delete/5
        [HttpPost]
        
        [ActionName("Delete")]
        public ActionResult PostDelete(int id)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var query = db.AREAS.Find(id);
                if (query != null)
                {
                    try
                    {
                        db.AREAS.Remove(query);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex);
                        return View(query);
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Prueba()
        {
            ViewBag.Messa = "Prueba";
            return View();
        }

        public ActionResult Prueba2()
        {
            ViewBag.Messa = "Prueba";
            return View();
        }
    }

    
}
