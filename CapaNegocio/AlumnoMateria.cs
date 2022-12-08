using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AlumnoMateria
    {
        public int IdAlumnoMateria { get; set; }
        public CapaNegocio.Alumno Alumno { get; set; }
        public CapaNegocio.Materia Materia { get; set; }
        public List<object>? AlumnosMaterias { get; set; }

        //public static Result InsertAlumno(AlumnoMateria alumnoMateria)
        //{
        //    Result result = new Result();
        //    try
        //    {
        //        using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
        //        {
        //            //EXECUTESQLRAW ADD, UPDATE Y DELETE
        //            var query = context.Database.ExecuteSqlRaw($"InsertAlumnoMateria '{alumnoMateria.Alumno.IdAlumno}', {alumnoMateria.Materia.IdMateria}");
        //            if (query > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = true;
        //        result.Ex = ex;
        //    }
        //    return (result);
        //}
        public static Result SelectAlumnoMateria()
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Alumnos.FromSqlRaw($"SelectAlumno").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Alumno alumno = new Alumno();
                            alumno.IdAlumno = obj.IdAlumno;//Se debe de convertir a tipo string 
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Imagen = obj.Imagen;

                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static Result ObtenerMateriasAsignadasAlumno(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.AlumnosMaterias.FromSqlRaw($"ObtenerMateriasAsignadasAlumno {IdAlumno}").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            AlumnoMateria alumnomateria = new AlumnoMateria();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnomateria.Alumno = new Alumno();
                            alumnomateria.Alumno.IdAlumno = obj.IdAlumno.Value;

                            alumnomateria.Materia = new Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria.Value;
                            alumnomateria.Materia.Nombre = obj.NombreMateria;
                            alumnomateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnomateria);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static Result EliminarAlumnoMateria(int IdAlumno, int IdMateria)
        {
            Result result = new Result();

            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Database.ExecuteSqlRaw($"EliminarAlumnoMateria {IdAlumno}, {IdMateria}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception Ex)
            {
                result.Ex = Ex;
                result.ErrorMessage = "Ocurrio un Error" + result.Ex.Message;
                throw;
            }

            return result;
        }
        public static Result ObtenerMateriasNoAsignadasAlumno(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Materia.FromSqlRaw($"MateriasNoAsignadasAlumno {IdAlumno}").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            AlumnoMateria alumnomateria = new AlumnoMateria();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnomateria.Alumno = new Alumno();
                            alumnomateria.Alumno.IdAlumno = obj.IdAlumno;

                            alumnomateria.Materia = new Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria;
                            alumnomateria.Materia.Nombre = obj.Nombre;
                            alumnomateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnomateria);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }

}
