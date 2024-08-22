using System;
using System.Collections.Generic;

namespace GymControl.Models;

public partial class Plane
{
    public int Idplan { get; set; }

    public string NombrePlan { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal PrecioMensual { get; set; }

    public int DuracionMeses { get; set; }

    public virtual ICollection<Subscripcione> Subscripciones { get; set; } = new List<Subscripcione>();
}
