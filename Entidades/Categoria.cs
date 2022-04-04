using System.ComponentModel.DataAnnotations;

public class Categoria{

    [Key]
    public int CategoriaId {get; set;}
    
    public string Nombre {get; set;}

    public string Descripcion {get; set;}

}