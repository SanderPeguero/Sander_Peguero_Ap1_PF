using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ClientesBLL{
    private static Contexto contexto = new Contexto();

    public static bool Create(Cliente cliente){//Inserta un Cliente a la base de datos

        bool successfull = false;
        
        try{

            contexto.Add(cliente);

            successfull = contexto.SaveChanges() > 0;

        }catch(Exception e){
            
            Console.WriteLine(e.Message);

        }

        return successfull;

    }

    public static Cliente Read(int Id){//Lee el Cliente con el id dado en la base de datos y lo devuelve

        Cliente cliente = new Cliente();
        
        try{

            cliente = contexto.Clientes.Include(x => x.Dispositivos).Where(x => x.ClienteId == Id).SingleOrDefault();

        }catch(Exception e){
            
            Console.WriteLine(e.Message);

        }
        
        return cliente;

    }

    public static bool Update(Cliente cliente){//Dado un Cliente, modifica el equivalente en la base de datos
        
        bool successfull = false;

        try{

            if(cliente.Dispositivos.Any()){
                
                Delete(cliente);
                
                Create(cliente);

            }else if(contexto.Clientes.Any(l => l.ClienteId == cliente.ClienteId)){
                
                contexto.Clientes.Update(cliente);
                
                successfull = contexto.SaveChanges() > 0;

            }

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
        
        return successfull;

    }

    public static bool Delete(Cliente cliente){//Dado un Cliente, elimina el equivalente en la base de datos
    
        bool successfull = false;

        try{

            contexto.Remove(cliente);
            
            successfull = contexto.SaveChanges() > 0;

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
        
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

        try{

            clientes = contexto.Clientes.Where(criterio).ToList();

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
            
        return clientes;

    }

    public static List<Cliente> GetList(){

        return contexto.Clientes.ToList();
        
    }

    public static List<Cliente> GetListDispositivos(Func<Cliente, bool> criterio){

        List<Cliente> dispositivos = new List<Cliente>();
        
        try{

            dispositivos = contexto.Clientes.Include(x => x.Dispositivos).Where(x => x.Dispositivos.Count() > 0 ).AsNoTracking().ToList();

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
        
        return dispositivos;
        
    }

}