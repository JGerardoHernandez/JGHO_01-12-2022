using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            CapaNegocio.Usuario usuario = new CapaNegocio.Usuario();
            CapaNegocio.Result result = new CapaNegocio.Result();

            result = CapaNegocio.Usuario.GetByUserName(userName);

            if (result.Correct = true)
            {
                usuario = (CapaNegocio.Usuario)result.Object;

                if (usuario.Password == password && usuario.UserName == userName)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "El password es incorrecto";
                }
            }
            else
            {
                ViewBag.Message = "El usuario ingresado no existe";
            }
            return View();
        }
    }
}
