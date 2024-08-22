using System;
using System.Collections.Generic;

namespace GymControl.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? EstadoSubscripcion { get; set; }

    public string Contrasena { get; set; } = null!;

    public int? Idrol { get; set; }

    public virtual Role? IdrolNavigation { get; set; }

    public virtual ICollection<Rutina> Rutinas { get; set; } = new List<Rutina>();

    public virtual ICollection<Subscripcione> Subscripciones { get; set; } = new List<Subscripcione>();
}
