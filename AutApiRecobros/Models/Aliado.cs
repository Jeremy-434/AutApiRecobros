using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Aliado
{
    [Key]
    [Column("id_aliado")]
    public int IdAliado { get; set; }

    [Column("nombre_aliado")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NombreAliado { get; set; }

    [Column("usuario")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Usuario { get; set; }

    [Column("estado")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column("fecha")]
    public int? Fecha { get; set; }

    [InverseProperty("IdAliadoNavigation")]
    public virtual ICollection<Aplicaciones> Aplicaciones { get; } = new List<Aplicaciones>();

    [InverseProperty("IdAliadoNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();

    [InverseProperty("IdAliadoNavigation")]
    public virtual ICollection<ControlArchivo> ControlArchivos { get; } = new List<ControlArchivo>();
}
