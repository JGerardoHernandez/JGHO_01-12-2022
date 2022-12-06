using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CapaServicios.Controllers
{
    [Route("api/alumnomateria/")]
    [ApiController]
    public class AlumnoMateriaController : Controller
    {
        [EnableCors("API")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult SelectAlumnoMateria()
        {
            CapaNegocio.AlumnoMateria alumnomateria = new CapaNegocio.AlumnoMateria();//Instancia de Usuario

            CapaNegocio.Result result = CapaNegocio.AlumnoMateria.SelectAlumnoMateria();//Instancia para traer alumno 

            if (result.Correct)//Para realizar la validacionde result
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetById{IdAlumno}")]
        //GET api/asignatura/5
        public IActionResult ObtenerMateriasAsignadasAlumno(int IdAlumno)
        {
            CapaNegocio.Result result = CapaNegocio.AlumnoMateria.ObtenerMateriasAsignadasAlumno(IdAlumno);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("ObtenerMateriasNoAsignadasAlumno{IdAlumno}")]
        //GET api/asignatura/5
        public IActionResult ObtenerMateriasNoAsignadasAlumno(int IdAlumno)
        {
            CapaNegocio.Result result = CapaNegocio.AlumnoMateria.ObtenerMateriasNoAsignadasAlumno(IdAlumno);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Delete{IdAlumno}/{IdMateria}")]
        //GET api/asignatura/5
        public IActionResult EliminarAlumnoMateria(int IdAlumno, int IdMateria)
        {

            CapaNegocio.Result result = CapaNegocio.AlumnoMateria.EliminarAlumnoMateria(IdAlumno, IdMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
