using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFInal2021Beta.Datos;
using WebFInal2021Beta.Models;
using WebFInal2021Beta.Models.ViewModels;

namespace WebFInal2021Beta.Controllers
{
    public class TablaController : Controller
    {

        //GET: Tabla
        [Authorize(Roles = "ApruebaAcciones")]
        public ActionResult Index()
        {


            List<ListTablaViewModel> lst;

            using (DemoWebEntities db = new DemoWebEntities())
            {



                lst = (from d in db.Tabla
                       select new ListTablaViewModel
                       {
                           ProgramaId = d.ProgramaId,
                           Nombre = d.Nombre,
                           Categoria = d.Categoria,


                       }).ToList();


            }


            return View(lst);
        }



        public ActionResult Nuevo()
        {

            return View();

        }


        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    using (DemoWebEntities db = new DemoWebEntities())
                    {
                        var oTabla = new Tabla();

                        oTabla.Nombre = model.Nombre;
                        oTabla.Categoria = model.Categoria;
                        oTabla.Fecha_Alta = model.Fecha_Alta;

                        db.Tabla.Add(oTabla);
                        db.SaveChanges();

                    }

                    return Redirect("~/Tabla/");

                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }




        }

        public ActionResult Editar(int Id)
        {

            TablaViewModel model = new TablaViewModel();

            using (DemoWebEntities db = new DemoWebEntities())
            {
                var oTabla = db.Tabla.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Categoria = oTabla.Categoria;

                model.ProgramaId = oTabla.ProgramaId;
            }


            return View(model);

        }


        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    using (DemoWebEntities db = new DemoWebEntities())
                    {
                        var oTabla = db.Tabla.Find(model.ProgramaId);

                        oTabla.Nombre = model.Nombre;
                        oTabla.Categoria = model.Categoria;
                        oTabla.Fecha_Alta = model.Fecha_Alta;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }

                    return Redirect("~/Tabla/");

                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }




        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {



            using (DemoWebEntities db = new DemoWebEntities())
            {


                var oTabla = db.Tabla.Find(Id);
                db.Tabla.Remove(oTabla);
                db.SaveChanges();
            }


            return Redirect("~/Tabla/");

        }



    }



}
