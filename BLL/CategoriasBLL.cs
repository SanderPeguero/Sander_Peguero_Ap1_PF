using Microsoft.EntityFrameworkCore;

public class CategoriasBLL{
    private static Contexto contexto = new Contexto();

    public static bool Create(Categoria categoria){//Inserta una Categoria a la base de datos

        bool successfull = false;

        // contexto.Entry(categoria).State = EntityState.Added;
        contexto.Categorias.Add(categoria);

        successfull = contexto.SaveChanges() > 0;

        return successfull;

    }

    public static Categoria Read(int Id){//Lee la Categoria con el id dado en la base de datos y la devuelve

        Categoria categoria = new Categoria();

        categoria = contexto.Categorias.Find(Id);

        return categoria;

    }

    public static bool Update(Categoria categoria){//Dada una Categoria, modifica equivalente en la base de datos
        
        bool successfull = false;

        if(contexto.Categorias.Any(l => l.CategoriaId == categoria.CategoriaId)){

            // contexto.Entry(categoria).State = EntityState.Modified;
            contexto.Categorias.Update(categoria);
            successfull = contexto.SaveChanges() > 0;

        }

        return successfull;

    }

    public static bool Delete(Categoria categoria){//Dada una Categoria, elimina la equivalente en la base de datos
    
        bool successfull = false;

        // contexto.Entry(categoria).State = EntityState.Deleted;
        contexto.Remove(categoria);
        successfull = contexto.SaveChanges() > 0;
        
        return successfull;

    }


    public static int Count(){//Cuenta las Categorias que hay en la base de datos y la devuelve

        int cantidad = contexto.Categorias
        .GroupBy(x => x.CategoriaId)
        .Select(g => g.Count()).Count();

        return cantidad;

    }

    public static Categoria BuscarNombre(string Nombre){//Busca y retorna el objeto que contiene el nombre
        
        return contexto.Categorias
            .Where(x => x.Nombre == Nombre)
            .FirstOrDefault();

    }

    public static List<Categoria> GetList(){

        return contexto.Categorias.ToList();
        
    }

}