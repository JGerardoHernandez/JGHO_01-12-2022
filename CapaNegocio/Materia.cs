using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string? Nombre { get; set; }
        public decimal? Costo { get; set; }
        public List<object>? Materias { get; set; }

        public static Result SelectMaterias()
        {
            Result result = new Result();
            try
            {       
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Materia.FromSqlRaw($"SelectMateria").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {

                            Materia materia = new Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo;

                            result.Objects.Add(materia);
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
        public static Result SelectMateria(int IdMateria)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {

                    var query = context.Materia.FromSqlRaw($"SelectPorIdMateria {IdMateria}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        CapaNegocio.Materia materia = new CapaNegocio.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo;    

                        result.Object = materia;//BOXING

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
        public static Result InsertMateria(Materia materia)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    //EXECUTESQLRAW ADD, UPDATE Y DELETE
                    var query = context.Database.ExecuteSqlRaw($"InsertMateria '{materia.Nombre}', '{materia.Costo}'");
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
        public static Result ActualizarMateria(Materia materia)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    //EXECUTESQLRAW ADD, UPDATE Y DELETE
                    var query = context.Database.ExecuteSqlRaw($"ActualizarMateria {materia.IdMateria},  '{materia.Nombre}', '{materia.Costo}'");

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
        public static Result EliminarMateria(Materia materia)
        {
            Result result = new Result();

            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Database.ExecuteSqlRaw($"EliminarMateria {materia.IdMateria}");
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
