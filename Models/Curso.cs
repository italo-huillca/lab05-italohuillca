using System;
using System.Collections.Generic;

namespace Lab5_ItaloHuillca.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Creditos { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
