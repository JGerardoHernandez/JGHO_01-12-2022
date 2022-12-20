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

        [EnableCors("API")]
        [HttpPost]
        [Route("Add/{idAlumno}/{idMateria}")]
        public IActionResult InsertAlumnoMateria(int idAlumno,int idMateria)
        {
            CapaNegocio.AlumnoMateria alumnoMateria = new CapaNegocio.AlumnoMateria();
            alumnoMateria.Alumno = new CapaNegocio.Alumno();
            alumnoMateria.Materia = new CapaNegocio.Materia();

            alumnoMateria.Alumno.IdAlumno = idAlumno;
            alumnoMateria.Materia.IdMateria = idMateria;
            
            CapaNegocio.Result result = CapaNegocio.AlumnoMateria.InsertAlumnoMateria(alumnoMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetById{IdAlumno}")]
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
        public IActionResult EliminarAlumnoMateria(int IdMateria, int IdAlumno)
        {

            CapaNegocio.Result result = CapaNegocio.AlumnoMateria.EliminarAlumnoMateria(IdMateria, IdAlumno);

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
