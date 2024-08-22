using System;
using System.Collections.Generic;

namespace GymControl.Models;

public partial class Role
{
    public int Idrol { get; set; }

    public string NombreRol { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
