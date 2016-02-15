using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        sys_web_controlAsistenciaPersonalEntities db = new sys_web_controlAsistenciaPersonalEntities();
        public ActionResult Index()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                return RedirectToAction("Casa");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID_USUARIO,CONTRASEÑA")] Login user)
        {
            if (ModelState.IsValid)
            {
                var row = (from u in db.USUARIOS
                           where u.ID_USUARIO == user.ID_USUARIO.ToString() && u.CONTRASEÑA == user.CONTRASEÑA.ToString()
                           select new { u.ID_USUARIO, u.TIPO }).FirstOrDefault();
                
                if (row != null)
                {
                    ViewBag.Mensaje = "aaaaa";
                    Session["MiUsuario"] = row.ID_USUARIO;
                    Session["MiTipo"] = row.TIPO;
                    return RedirectToAction("Casa");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o contraseña incorrectos";
                    return View(user);    
                }
            }
            return View(user);
        }

        public ActionResult Casa()
        {
            if (Session["MiUsuario"] != null && Session["MiTipo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult CerrarSession()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }




    }
}