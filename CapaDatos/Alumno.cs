using System;
using System.Collections.Generic;

namespace CapaDatos;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<AlumnosMateria> AlumnosMateria { get; } = new List<AlumnosMateria>();
}
