using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cliente{

    [Key]
    public int ClienteId {get; set;}

    public string Nombre {get; set;}

    public string Apellido {get; set;}

    public string Cedula {get; set;}

    public string Telefono {get; set;}

    public DateTime Fecha {get; set;} = DateTime.Now;

    [ForeignKey("ClienteId")]    
    public virtual List<Dispositivo> Dispositivos {get; set;} = new List<Dispositivo>();


}