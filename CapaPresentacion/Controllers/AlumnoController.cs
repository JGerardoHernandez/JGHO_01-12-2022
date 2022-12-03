using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Net.Http;

namespace CapaPresentacion.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        public ActionResult SelectAlumnos()
        {
            return View();
        }
    }
}
