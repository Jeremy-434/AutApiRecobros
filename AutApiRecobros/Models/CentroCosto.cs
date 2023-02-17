using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class CentroCosto
{
    [Key]
    [Column("id_centro_costo")]
    public int IdCentroCosto { get; set; }

    [Column("login_user")]
    [StringLength(30)]
    [Unicode(false)]
    public string? LoginUser { get; set; }

    [Column("nombre_user")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NombreUser { get; set; }

    [Column("ceco")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Ceco { get; set; }
}
