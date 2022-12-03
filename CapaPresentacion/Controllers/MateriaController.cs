using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult SelectMaterias()
        {
            return View();
        }
    }
}
