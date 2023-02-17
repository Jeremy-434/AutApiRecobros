using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class LogErrores
{
    [Key]
    [Column("id_log_error")]
    public int IdLogError { get; set; }

    [Column("fecha_servidor")]
    [StringLength(30)]
    [Unicode(false)]
    public string? FechaServidor { get; set; }

    [Column("descripcion_error")]
    [StringLength(30)]
    [Unicode(false)]
    public string? DescripcionError { get; set; }

    [Column("anio")]
    public int? Anio { get; set; }

    [Column("mes")]
    public int? Mes { get; set; }

    [Column("id_consolidado")]
    public int IdConsolidado { get; set; }

    [ForeignKey("IdConsolidado")]
    [InverseProperty("LogErrores")]
    public virtual Consolidado IdConsolidadoNavigation { get; set; } = null!;
}
