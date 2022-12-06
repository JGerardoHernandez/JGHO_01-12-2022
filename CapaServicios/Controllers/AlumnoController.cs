using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CapaServicios.Controllers
{
    [Route("api/alumno/")]
    [ApiController]
    public class AlumnoController : Controller
    {
        [EnableCors("API")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult SelectAlumnos()
        {
            CapaNegocio.Alumno alumno = new CapaNegocio.Alumno();//Instancia de Usuario

            CapaNegocio.Result result = CapaNegocio.Alumno.SelectAlumnos();//Instancia para traer alumno 

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
        [HttpGet]
        [Route("GetById{IdAlumno}")]
        //GET api/asignatura/5
        public IActionResult SelectAlumno(int IdAlumno)
        {
            CapaNegocio.Result result = CapaNegocio.Alumno.SelectAlumno(IdAlumno);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [HttpPost]
        [Route("Add")]
        public IActionResult InsertAlumno([FromBody] CapaNegocio.Alumno alumno)
        {
            CapaNegocio.Result result = CapaNegocio.Alumno.InsertAlumno(alumno);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [HttpPost]
        [Route("Update")]
        public IActionResult ActualizarAlumno(int IdAlumno, [FromBody] CapaNegocio.Alumno alumno)
        {

            CapaNegocio.Result result = CapaNegocio.Alumno.ActualizarAlumno(alumno);

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
        [Route("Delete{IdAlumno}")]
        //GET api/asignatura/5
        public IActionResult EliminarAlumno(int IdAlumno)
        {
            CapaNegocio.Alumno alumno = new CapaNegocio.Alumno();
            alumno.IdAlumno = IdAlumno;

            CapaNegocio.Result result = CapaNegocio.Alumno.EliminarAlumno(alumno);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPost]
        //[Route("GetByUserName/{userName}")] //Nombre de Stored Procedure
        //public IActionResult Login(string userName)
        //{
        //    CapaNegocio.Result result = CapaNegocio.Alumno.GetByUserName(userName);
        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
