﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

[Table("ControlArchivo")]
public partial class ControlArchivo
{
    [Key]
    [Column("id_control_archivo")]
    public int IdControlArchivo { get; set; }

    [Column("registro")]
    [StringLength(50)]
    [Unicode(false)]
    public string Registro { get; set; } = null!;

    [Column("usuario")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Usuario { get; set; }

    [Column("estado")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column("nombre_archivo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NombreArchivo { get; set; }

    [Column("fecha_servicio", TypeName = "datetime")]
    public DateTime? FechaServicio { get; set; }

    [Column("id_aliado")]
    public int IdAliado { get; set; }

    public int Mes { get; set; }

    [Column("anio")]
    public int Anio { get; set; }

    [InverseProperty("IdControlArchivoNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();

    [ForeignKey("IdAliado")]
    [InverseProperty("ControlArchivos")]
    public virtual Aliados IdAliadoNavigation { get; set; } = null!;
}
