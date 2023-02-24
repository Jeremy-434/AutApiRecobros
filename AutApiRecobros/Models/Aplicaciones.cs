using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Aplicaciones
{
    [Key]
    [Column("id_aplicacion")]
    public int IdAplicacion { get; set; }

    [Column("nombre_aplicacion")]
    [StringLength(80)]
    [Unicode(false)]
    public string NombreAplicacion { get; set; } = null!;

    [Column("estado")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column("nombre_segmento")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NombreSegmento { get; set; }

    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("id_aliado")]
    public int IdAliado { get; set; }

    [JsonIgnore]
    [InverseProperty("IdAplicacionNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();

    [ForeignKey("IdAliado")]
    [InverseProperty("Aplicaciones")]
    public virtual Aliados? IdAliadoNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("Aplicaciones")]
    public virtual Servicios? IdServicioNavigation { get; set; } = null!;
}
