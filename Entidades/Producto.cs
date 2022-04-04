using System.ComponentModel.DataAnnotations;

public class Producto{

    [Key]
    public int ProductoId {get; set;}

    public string Nombre {get; set;}

    public int Precio {get; set;}

    public string Descripcion {get; set;}
    
}