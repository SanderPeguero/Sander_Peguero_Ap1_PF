using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cliente{

    [Key]
    public int ClienteId {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(2, ErrorMessage = "Nombre debe tener mas de 2 caracteres")]
    public string Nombre {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(2, ErrorMessage = "Apellido debe tener mas de 2 caracteres")]
    public string Apellido {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(2, ErrorMessage = "Cédula debe tener mas de 2 caracteres")]
    public string Cedula {get; set;}

    [MinLength(10, ErrorMessage = "Telefono debe tener mas de 10 caracteres")]
    public string Telefono {get; set;}

    public DateTime Fecha {get; set;} = DateTime.Now;

    [ForeignKey("ClienteId")]    
    public virtual List<Dispositivo> Dispositivos {get; set;} = new List<Dispositivo>();


}