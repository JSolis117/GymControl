using System;
using System.Collections.Generic;

namespace GymControl.Models;

public partial class Subscripcione
{
    public int Idsubscripcion { get; set; }

    public int? Idusuario { get; set; }

    public int? Idplan { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string? EstadoPago { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal Monto { get; set; }

    public virtual Plane? IdplanNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<SubscripcionesCombo> SubscripcionesCombos { get; set; } = new List<SubscripcionesCombo>();
}
