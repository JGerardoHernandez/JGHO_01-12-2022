
using Microsoft.EntityFrameworkCore;

namespace CapaNegocio
{
    public class Alumno
    {

        public int IdAlumno { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Imagen { get; set; }
        public List<object>? Alumnos { get; set; }

        public static Result SelectAlumnos()
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
        public static Result SelectAlumno(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {

                    var query = context.Alumnos.FromSqlRaw($"SelectPorIdAlumno {IdAlumno}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        CapaNegocio.Alumno alumno = new CapaNegocio.Alumno();

                        alumno.IdAlumno = query.IdAlumno;//Se debe de convertir a tipo string 
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPaterno = query.ApellidoPaterno;
                        alumno.ApellidoMaterno = query.ApellidoMaterno;
                        alumno.Imagen = query.Imagen;
                        
                        result.Object = alumno;//BOXING

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Usuario";
                    }
                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static Result InsertAlumno(Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    //EXECUTESQLRAW ADD, UPDATE Y DELETE
                    var query = context.Database.ExecuteSqlRaw($"InsertAlumno '{alumno.Nombre}',  '{alumno.ApellidoPaterno}', '{alumno.ApellidoMaterno}',  '{alumno.Imagen}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Ex = ex;
            }
            return (result);
        }
        public static Result ActualizarAlumno(Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    //EXECUTESQLRAW ADD, UPDATE Y DELETE
                    var query = context.Database.ExecuteSqlRaw($"ActualizarAlumno {alumno.IdAlumno},  '{alumno.Nombre}', '{alumno.ApellidoPaterno}', '{alumno.ApellidoMaterno}', '{alumno.Imagen}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Ex = ex;
            }
            return (result);
        }
        public static Result EliminarAlumno(Alumno alumno)
        {
            Result result = new Result();

            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Database.ExecuteSqlRaw($"EliminarAlumno {alumno.IdAlumno}");
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

    }
}