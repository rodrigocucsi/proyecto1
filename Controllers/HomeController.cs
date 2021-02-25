using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFInal2021Beta.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace WebFInal2021Beta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var idUsuarioActual = User.Identity.GetUserId();

                    var roleManager = new RoleManager<IdentityRole>
                        (new RoleStore<IdentityRole>(db));


                    //CREAR ROLE

                    //var resultado = roleManager.Create(new IdentityRole("ApruebaAcciones"));
                    var resultado2 = roleManager.Create(new IdentityRole("AccederPagina"));


                    var userManager = new UserManager<ApplicationUser>
                        (new UserStore<ApplicationUser>(db));

                    //AGREGAR AL USUARIO AL ROL


                    //resultado = userManager.AddToRole(idUsuarioActual, "ApruebaAcciones");
                    resultado2 = userManager.AddToRole(idUsuarioActual, "AccederPagina");

                    //USUARIO ESTA EN EL ROL?

                    var usuarioEstaEnRol = userManager.IsInRole(idUsuarioActual, "ApruebaAcciones");
                    var usuarioEstaEnRol2 = userManager.IsInRole(idUsuarioActual, "AccederPagina");


                    //Roles Usuario

                    var roles = userManager.GetRoles(idUsuarioActual);


                    //Remover Usuario de Rol

                    //resultado = userManager.RemoveFromRole(idUsuarioActual, "ApruebaAcciones");


                    //Borrar ROL

                    //var rolVendedor = roleManager.FindByName("ApruebaAcciones");
                    //roleManager.Delete(rolVendedor);



                }
            }



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Descargas()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Drivers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Hardware()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Limpiadores()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Navegadores()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Navegadores_Descargas()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Utilidades()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


    }
}