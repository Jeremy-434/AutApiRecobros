using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class CierreMes
{
    [Key]
    [Column("id_cierre_mes")]
    public int IdCierreMes { get; set; }

    [Column("mes")]
    public int Mes { get; set; }

    [Column("anio")]
    public int Anio { get; set; }

    [Column("estado")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column("usuario")]
    [StringLength(100)]
    [Unicode(false)]
    public string Usuario { get; set; } = null!;

    [Column("fecha_servidor", TypeName = "datetime")]
    public DateTime? FechaServidor { get; set; }
}
