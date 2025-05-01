using System;
using System.Collections.Generic;

namespace WebAppVeterinaria.Models;

public partial class Veterinaria
{
    public long id { get; set; }

    public string Nit { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string Email { get; set; } = null!;

    public int Empleados { get; set; }

    public DateOnly? FechaFundacion { get; set; }
}
