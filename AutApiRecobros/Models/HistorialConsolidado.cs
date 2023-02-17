using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

[Table("HistorialConsolidado")]
public partial class HistorialConsolidado
{
    [Key]
    [Column("id_historial_consolidado")]
    public int IdHistorialConsolidado { get; set; }

    [Column("mes")]
    public int Mes { get; set; }

    [Column("anio")]
    public int Anio { get; set; }

    [Column("registro")]
    [StringLength(30)]
    [Unicode(false)]
    public string Registro { get; set; } = null!;

    [Column("nombre")]
    [StringLength(30)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("nombre_servicio")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreServicio { get; set; } = null!;

    [Column("sub_servicio")]
    [StringLength(30)]
    [Unicode(false)]
    public string? SubServicio { get; set; }

    [Column("clase_actividad")]
    [StringLength(30)]
    [Unicode(false)]
    public string ClaseActividad { get; set; } = null!;

    [Column("clase_costo")]
    [StringLength(30)]
    [Unicode(false)]
    public string ClaseCosto { get; set; } = null!;

    [Column("driver")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Driver { get; set; }

    [Column("centro_costo_receptor")]
    [StringLength(30)]
    [Unicode(false)]
    public string? CentroCostoReceptor { get; set; }

    [Column("descripcion_ceco_emisor")]
    [StringLength(30)]
    [Unicode(false)]
    public string? DescripcionCecoEmisor { get; set; }

    [Column("cantidad")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Cantidad { get; set; }

    [Column("tarifa")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Tarifa { get; set; }

    [Column("costo")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Costo { get; set; }

    [Column("detalle")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Detalle { get; set; }

    [Column("regional")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Regional { get; set; }

    [Column("localidad")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Localidad { get; set; }

    [Column("serial")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Serial { get; set; }

    [Column("nombre_pc")]
    [StringLength(30)]
    [Unicode(false)]
    public string? NombrePc { get; set; }

    [Column("producto_instalado")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ProductoInstalado { get; set; }

    [Column("nombre_aplicacion")]
    [StringLength(70)]
    [Unicode(false)]
    public string? NombreAplicacion { get; set; }

    [Column("fecha")]
    public int? Fecha { get; set; }

    [Column("id_consolidado")]
    public int IdConsolidado { get; set; }

    [Column("id_control_archivo")]
    public int IdControlArchivo { get; set; }

    [Column("id_aplicacion")]
    public int IdAplicacion { get; set; }

    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("id_aliado")]
    public int? IdAliado { get; set; }
}
