using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutApiRecobros.Models;

public partial class Parametros
{
    [Key]
    [Column("id_parametro")]
    public int IdParametro { get; set; }

    [Column("ruta_archivos_procesar")]
    [StringLength(250)]
    [Unicode(false)]
    public string RutaArchivosProcesar { get; set; } = null!;

    [Column("num_meses_eliminacion_historico")]
    [StringLength(30)]
    [Unicode(false)]
    public string? NumMesesEliminacionHistorico { get; set; }
}
