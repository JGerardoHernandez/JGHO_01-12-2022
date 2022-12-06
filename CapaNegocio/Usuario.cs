using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Usuario
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }

        public static Result GetByUserName(string userName)
        {
            Result result = new Result();
            try
            {
                using (CapaDatos.Jgho01122022Context context = new CapaDatos.Jgho01122022Context())
                {
                    var query = context.Usuarios.FromSqlRaw($"GetByIdUserName '{userName}'").AsEnumerable().SingleOrDefault();

                    if (query != null)
                    {
                        CapaNegocio.Usuario usuario = new CapaNegocio.Usuario();

                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;


                        result.Object = usuario;//BOXING

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
    }
}
