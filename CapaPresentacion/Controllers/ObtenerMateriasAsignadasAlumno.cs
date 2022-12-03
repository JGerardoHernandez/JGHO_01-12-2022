using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ObtenerMateriasAsignadasAlumno : Controller
    {
        public ActionResult ObtenerMateriasAsignadasAlumno()
        {
            //GetAll 1er Vista
            CapaNegocio.Result result = new CapaNegocio.Result();

            CapaNegocio.Alumno alumno = new CapaNegocio.Alumno();
            result = CapaNegocio.Alumno.GetAllSP();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Error";
                return PartialView("Modal");
            }
        }

        //GetAll Materias 2da vista
        [HttpGet]
        public ActionResult GetMateriasAsignadas(int IdAlumno)
        {
            ML.Result resultMaterias = BL.AlumnoMateria.GetMateriasAsignadas(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultAlumno = BL.Alumno.GetByIdSP(IdAlumno);

            //alumnoMateria.Materia = new ML.Materia();
            //alumnoMateria.Alumno = new ML.Alumno();

            if (resultAlumno.Correct)
            {
                alumnoMateria.AlumnosMaterias = resultMaterias.Objects;

                alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;
                return View(alumnoMateria);

            }
            return View(alumnoMateria);
        }

        // Eliminar Materia
        [HttpGet]
        public ActionResult Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            result = BL.AlumnoMateria.DeleteAlumnoMateria(alumnoMateria);


            if (result.Correct)
            {
                ViewBag.Message = "Materia Eliminada";
            }
            else
            {
                ViewBag.Message = "Materia No eliminada";
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult GetMateriasNoAsignadas(int IdAlumno)
        {
            ML.Result resultMaterias = BL.AlumnoMateria.GetMateriasNoAsignadas(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetByIdSP(IdAlumno);

            alumnomateria.AlumnosMaterias = resultMaterias.Objects;
            alumnomateria.Alumno = (ML.Alumno)resultalumno.Object;

            return View(alumnomateria);
        }


        [HttpPost]
        public ActionResult GetMateriasNoAsignadas(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnosMaterias != null)
            {
                foreach (string IdMateria in alumnoMateria.AlumnosMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.Alumno = new ML.Alumno();
                    alumnomateriaItem.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnomateriaItem.Materia = new ML.Materia();
                    alumnomateriaItem.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.MateriaAlumnoAdd(alumnomateriaItem);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }



    }
}
