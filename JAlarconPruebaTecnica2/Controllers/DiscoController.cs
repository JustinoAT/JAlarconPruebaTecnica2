using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JAlarconPruebaTecnica2.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();

            var result = BL.Disco.GetAll();

            if (result.Correct)
            {
                disco.Discos = result.Objects.ToList();
            }
            return View(disco);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Disco disco) {
           
            disco = new ML.Disco();
            ML.Result result = BL.Disco.GetAll();
            disco.Discos = result.Objects;

            return View(disco);

        }




        [HttpGet]
        public ActionResult Form(int? IdDisco)
        {
            ML.Disco disco = new ML.Disco();

            if (IdDisco != null)
            {
                ML.Result result = BL.Disco.GetByI(IdDisco.Value);

                if (result.Correct)
                {

                    disco = (ML.Disco)result.Object;

                }

            }
         


            return View(disco);
        }

        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if(ModelState.IsValid) { 

            if (disco.IdDisco == 0)
            {
                ML.Result result = BL.Disco.Add(disco);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha completado el registro";
                }
                else
                {
                    ViewBag.Mensaje = "Error" + result.ErrorMessage;
                }

            }

            }
            else
            {
                ML.Result result = BL.Disco.Update(disco);
                if (result.Correct)
                {

                    ViewBag.Mensaje = "Se ha completado la actualizacion";
                }
                else
                {
                    ViewBag.Mensaje = "Error" + result.ErrorMessage;
                }
            }


            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(int IdDisco)
        {

            ML.Result result = BL.Disco.Delete(IdDisco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eleiminado correctamente el departamento";

            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar el departamento" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

    }
}