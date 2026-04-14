using System;
using System.Collections.Generic;

namespace Lab5_ItaloHuillca.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Correo { get; set; }
}
