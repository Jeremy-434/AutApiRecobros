using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Aliados
{
    [Key]
    [Column("id_aliado")]
    public int IdAliado { get; set; }

    [Column("nombre_aliado")]
    [StringLength(100)]
    [Unicode(false)]
    public string NombreAliado { get; set; } = null!;

    [Column("usuario")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Usuario { get; set; }

    [Column("estado")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column("correo_responsable")]
    [StringLength(200)]
    [Unicode(false)]
    public string CorreoResponsable { get; set; } = null!;

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [JsonIgnore]
    [InverseProperty("IdAliadoNavigation")]
    public virtual ICollection<Aplicaciones> Aplicaciones { get; } = new List<Aplicaciones>();

    [JsonIgnore]
    [InverseProperty("IdAliadoNavigation")]
    public virtual ICollection<Consolidado> Consolidados { get; } = new List<Consolidado>();

    [JsonIgnore]
    [InverseProperty("IdAliadoNavigation")]
    public virtual ICollection<ControlArchivo> ControlArchivos { get; } = new List<ControlArchivo>();
}
