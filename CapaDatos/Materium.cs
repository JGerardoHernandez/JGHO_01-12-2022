using System;
using System.Collections.Generic;

namespace CapaDatos;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string? Nombre { get; set; }

    public decimal? Costo { get; set; }

    //public int IdAlumnoMateria { get; set; }

    //public int IdAlumno { get; set; }
    public virtual ICollection<AlumnosMateria> AlumnosMateria { get; } = new List<AlumnosMateria>();
}
