using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RecepcionDetalle{

    [Key]
    public int RecepcionDetalleId {get; set;}

    public string Detalle {get; set;}

}