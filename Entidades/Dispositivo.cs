using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Dispositivo{
    
    [Key]
    public int DispositivoId {get; set;}

    public string Marca {get; set;}

    public string Modelo {get; set;}

    public string SO {get; set;}

    public string IMEI {get; set;}

    public string Color {get; set;}

    public bool Teclado {get; set;}

    public int ClienteId { get; set; }
    
}