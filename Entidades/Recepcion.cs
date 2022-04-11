using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recepcion{

    [Key]
    public int RecepcionId {get; set;}

    public DateTime Fecha {get; set;} = DateTime.Now;

    [ForeignKey("RecepcionId")]
    public virtual List<RecepcionDetalle> Problemas {get; set;} = new List<RecepcionDetalle>();

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(2, ErrorMessage = "Tecnico debe tener mas de 2 caracteres")]
    public string Tecnico {get; set;}
    
    public int ClienteId {get; set;}

    public int CategoriaId {get; set;}

    public int ProductoId {get; set;}


}