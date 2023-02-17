using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Servicios
{
    [Key]
    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("nombre_servicio")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreServicio { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("driver")]
    public int? Driver { get; set; }

    [Column("responsable_reporte")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ResponsableReporte { get; set; }

    [Column("clase_actividad")]
    [StringLength(30)]
    [Unicode(false)]
    public string ClaseActividad { get; set; } = null!;

    [Column("clase_costo")]
    [StringLength(30)]
    [Unicode(false)]
    public string ClaseCosto { get; set; } = null!;

    [Column("lider_servicio")]
    [StringLength(30)]
    [Unicode(false)]
    public string? LiderServicio { get; set; }

    [Column("porcentaje_comparacion")]
    public int? PorcentajeComparacion { get; set; }

    [JsonIgnore]
    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<Aplicaciones> Aplicaciones { get; } = new List<Aplicaciones>();

    [JsonIgnore]
    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();
}
