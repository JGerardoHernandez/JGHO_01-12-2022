using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Result
    {
        public bool Correct { get; set; }//Validar
        public string ErrorMessage { get; set; }//Excepciones
        public object Object { get; set; }//Guardar Informacion de 1
        public List<object> Objects { get; set; }//Guardar Informacion de Varios
        public Exception Ex { get; set; } //Excepciones
    }
}
