using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace WebAppVeterinaria.Models;

public partial class CitaMedica
{
    public long id { get; set; }

    public long MedicoId { get; set; }

    public long MascotaId { get; set; }

    public DateTime FechaCita { get; set; }

    public string Sintomas { get; set; } = null!;

    public string Diagnostico { get; set; } = null!;

    public string? Formula { get; set; }

    public virtual Mascota? Mascota { get; set; } /*= null!;*/   /*se agrega a Mascota el signo ?*/

    public virtual Medico? Medico { get; set; } /*= null!;*/    /*se agrega a Medico el signo ?*/
}
