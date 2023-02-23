using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Servicios
{
    [Key]
    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("nombre_servicio")]
    [StringLength(80)]
    [Unicode(false)]
    public string NombreServicio { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("driver")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Driver { get; set; }

    [Column("responsable_reporte")]
    [StringLength(100)]
    [Unicode(false)]
    public string ResponsableReporte { get; set; } = null!;

    [Column("clase_actividad")]
    [StringLength(50)]
    [Unicode(false)]
    public string ClaseActividad { get; set; } = null!;

    [Column("clase_costo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ClaseCosto { get; set; } = null!;

    [Column("porcentaje_comparacion")]
    public double? PorcentajeComparacion { get; set; }

    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<Aplicaciones> Aplicaciones { get; } = new List<Aplicaciones>();

    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();
}
