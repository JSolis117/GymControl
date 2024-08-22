using System;
using System.Collections.Generic;

namespace GymControl.Models;

public partial class SubscripcionesCombo
{
    public int IdsubscripcionCombo { get; set; }

    public int? Idsubscripcion { get; set; }

    public DateOnly FechaAplicacion { get; set; }

    public decimal DescuentoAplicado { get; set; }

    public virtual Subscripcione? IdsubscripcionNavigation { get; set; }
}
