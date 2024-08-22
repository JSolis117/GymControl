using System;
using System.Collections.Generic;

namespace GymControl.Models;

public partial class Rutina
{
    public int Idrutina { get; set; }

    public int? Idusuario { get; set; }

    public string NombreRutina { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int? DuracionDias { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
