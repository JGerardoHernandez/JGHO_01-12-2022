using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        [HttpGet]
        public ActionResult SelectAlumnoMateria()
        {
            return View();
        }

    }
}
