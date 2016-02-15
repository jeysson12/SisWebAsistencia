using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AsistenciaController : Controller
    {
        private sys_web_controlAsistenciaPersonalEntities db = new sys_web_controlAsistenciaPersonalEntities();

        // GET: Asistencia
        public ActionResult Index()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                var query = db.EMPLEADOS.Include(e => e.AREAS).Include(e => e.CARGOS);
                return View(query);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult MarcarHora(int? id, EMPLEADOS empl)
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                if (id != null)
                {
                    var query = db.EMPLEADOS.Find(id);
                    if (query != null)
                    {
                        string a = DateTime.Now.ToShortDateString();
                        var query2 = (db.ASISTENCIAS.Where(c => c.FECHA.Equals(a) && c.ID_EMPLEADO == id)).FirstOrDefault();
                        var query3 = (from c in db.ASISTENCIAS where c.FECHA.Equals(a) && c.ID_EMPLEADO == id select c).ToList();//(db.ASISTENCIAS.Where(c => c.FECHA == DateTime.Now && c.ID_EMPLEADO == id)).ToList();

                        string hora = DateTime.Now.ToString("hh:mm:ss");
                        if (query3.Count == 0)
                        {

                            var asis = new ASISTENCIAS();
                            asis.FECHA = a;
                            asis.ID_EMPLEADO = id;
                            asis.HORA_INGRESO = hora;
                            asis.HORA_SALIDA = "";
                            asis.OBSERVACIONES = "";
                            db.ASISTENCIAS.Add(asis);
                            db.SaveChanges();
                            ViewData["MenSal"] = "Ha marcado su hora de Entrada, Fecha: " + a + " Hora: " + hora;
                            return View();
                        }
                        else
                        {
                            if (query2.HORA_SALIDA == "")
                            {
                                query2.HORA_SALIDA = hora;
                                db.SaveChanges();
                                ViewData["MenSal"] = "Ha marcado su hora de Salida, Fecha: " + a + " Hora: " + hora;
                                return View();
                            }

                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}