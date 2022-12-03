using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CapaServicios.Controllers
{
    [Route("api/materia/")]
    [ApiController]
    public class MateriaController : Controller
    {
        [EnableCors("API")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult SelectAlumnos()
        {
            CapaNegocio.Materia materia = new CapaNegocio.Materia();//Instancia de Usuario

            CapaNegocio.Result result = CapaNegocio.Materia.SelectMaterias();//Instancia para traer alumno 

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
        [Route("GetById{IdMateria}")]
        //GET api/asignatura/5
        public IActionResult SelectMateria(int IdMateria)
        {
            CapaNegocio.Result result = CapaNegocio.Materia.SelectMateria(IdMateria);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult InsertMateria([FromBody] CapaNegocio.Materia materia)
        {
            CapaNegocio.Result result = CapaNegocio.Materia.InsertMateria(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult ActualizarMateria(int IdMateria, [FromBody] CapaNegocio.Materia materia)
        {
            CapaNegocio.Result result = CapaNegocio.Materia.ActualizarMateria(materia);

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
        [Route("Delete{IdMateria}")]
        //GET api/asignatura/5
        public IActionResult EliminarMateria(int IdMateria)
        {
            CapaNegocio.Materia materia = new CapaNegocio.Materia();
            materia.IdMateria = IdMateria;

            CapaNegocio.Result result = CapaNegocio.Materia.EliminarMateria(materia);

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
