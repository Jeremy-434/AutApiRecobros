using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Aplicaciones
{
    [Key]
    [Column("id_aplicacion")]
    public int IdAplicacion { get; set; }

    [Column("nombre_de_aplicación")]
    [StringLength(70)]
    [Unicode(false)]
    public string? NombreDeAplicación { get; set; }

    [Column("estado_de_aplicación")]
    [StringLength(30)]
    [Unicode(false)]
    public string? EstadoDeAplicación { get; set; }

    [Column("nombre_de_segmento")]
    [StringLength(30)]
    [Unicode(false)]
    public string? NombreDeSegmento { get; set; }

    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("id_aliado")]
    public int IdAliado { get; set; }

    [InverseProperty("IdAplicacionNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();

    [ForeignKey("IdAliado")]
    [InverseProperty("Aplicaciones")]
    public virtual Aliado IdAliadoNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("Aplicaciones")]
    public virtual Servicios IdServicioNavigation { get; set; } = null!;
}
