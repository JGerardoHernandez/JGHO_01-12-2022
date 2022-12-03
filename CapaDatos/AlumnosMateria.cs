﻿using System;
using System.Collections.Generic;

namespace CapaDatos;

public partial class AlumnosMateria
{
    public int IdAlumnoMateria { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdMateria { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Materium? IdMateriaNavigation { get; set; }
}
