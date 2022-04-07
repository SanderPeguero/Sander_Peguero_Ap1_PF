using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ClientesBLL{
    private static Contexto contexto = new Contexto();

    public static bool Create(Cliente cliente){//Inserta un Cliente a la base de datos

        bool successfull = false;
        contexto.Clientes.Add(cliente);
        // contexto.Entry(cliente).State = EntityState.Added;

        successfull = contexto.SaveChanges() > 0;

        return successfull;

    }

    public static Cliente Read(int Id){//Lee el Cliente con el id dado en la base de datos y lo devuelve

        Cliente cliente = new Cliente();

        // cliente = contexto.Clientes.Find(Id);

        cliente = contexto.Clientes.Include(x => x.Dispositivos).Where(x => x.ClienteId == Id).SingleOrDefault();

        return cliente;

    }

    public static bool Update(Cliente cliente){//Dado un Cliente, modifica el equivalente en la base de datos
        
        bool successfull = false;

        if(contexto.Clientes.Any(l => l.ClienteId == cliente.ClienteId)){
            contexto.Clientes.Update(cliente);
            //contexto.Entry(cliente).State = EntityState.Modified;
            successfull = contexto.SaveChanges() > 0;

        }

        return successfull;

    }

    public static bool Delete(Cliente cliente){//Dado un Cliente, elimina el equivalente en la base de datos
    
        bool successfull = false;

        
        contexto.Remove(cliente);
        // contexto.Entry(cliente).State = EntityState.Deleted;
        successfull = contexto.SaveChanges() > 0;
        
        return successfull;

    }

    public static Cliente BuscarNombre(string Nombre){//Busca y retorna el objeto que contiene el nombre
        
        return contexto.Clientes
            .Where(x => x.Nombre == Nombre)
            .FirstOrDefault();

    }

    public static List<Cliente> GetList(Expression<Func<Cliente, bool>> criterio)
    {
        List<Cliente> clientes = new List<Cliente>();
    
        clientes = contexto.Clientes.Where(criterio).ToList();
            
        return clientes;
    }

    public static List<Cliente> GetList(){

        return contexto.Clientes.ToList();
        
    }

    public static List<Cliente> GetListDispositivos(Func<Cliente, bool> criterio){

        List<Cliente> dispositivos = new List<Cliente>();
        
        dispositivos = contexto.Clientes.Include(x => x.Dispositivos).Where(x => x.Dispositivos.Count() > 0 ).AsNoTracking().ToList();
        
        return dispositivos;
        
    }


}