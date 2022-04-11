using  Microsoft.EntityFrameworkCore;

public class ProductosBLL{

    private static Contexto contexto = new Contexto();

    public static bool Create(Producto producto){//Inserta un Producto a la base de datos

        bool successfull = false;

        try{

            contexto.Productos.Add(producto);

            successfull = contexto.SaveChanges() > 0;

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }

        return successfull;

    }

    public static Producto Read(int Id){//Lee el Producto con el id dado en la base de datos y lo devuelve

        Producto producto = new Producto();
        
        try{

            producto = contexto.Productos.Find(Id);

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
        
        return producto;

    }

    public static bool Update(Producto producto){//Dado un Producto, modifica el equivalente en la base de datos
        
        bool successfull = false;

        try{

            if(contexto.Productos.Any(l => l.ProductoId == producto.ProductoId)){

                contexto.Productos.Update(producto);
                successfull = contexto.SaveChanges() > 0;

            }

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }

        return successfull;

    }

    public static bool Delete(Producto producto){//Dado un Producto, elimina el equivalente en la base de datos
    
        bool successfull = false;

        try{

            contexto.Productos.Remove(producto);
            successfull = contexto.SaveChanges() > 0;

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
        
        return successfull;

    }

    public static Producto BuscarNombre(string Nombre){//Busca y retorna el objeto que contiene el nombre
        
        return contexto.Productos
            .Where(x => x.Nombre == Nombre)
            .FirstOrDefault();

    }

    public static List<Producto> GetList(){

        return contexto.Productos.ToList();
        
    }

}