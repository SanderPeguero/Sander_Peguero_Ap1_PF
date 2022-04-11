using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Dispositivo{
    
    [Key]
    public int DispositivoId {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(2, ErrorMessage = "Marca debe tener mas de 2 caracteres")]
    public string Marca {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(2, ErrorMessage = "Modelo debe tener mas de 2 caracteres")]
    public string Modelo {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string SO {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(15, ErrorMessage = "IMEI debe tener mas de 15 digitos")]
    public string IMEI {get; set;}

    public string Color {get; set;}

    [Required(ErrorMessage = "Campo Obligatorio")]
    public bool Teclado {get; set;}

    public int ClienteId { get; set; }
    
}