using Microsoft.EntityFrameworkCore;

public class RecepcionesBLL{

    private static Contexto contexto = new Contexto();

    public static bool Create(Recepcion recepcion){//Inserta una Recepcion a la base de datos

        bool successfull = false;

        try{

            contexto.Recepciones.Add(recepcion);

            successfull = contexto.SaveChanges() > 0;

        }catch(Exception e){
            
            Console.WriteLine(e.Message);

        }

        return successfull;

    }

    public static Recepcion Read(int Id){//Lee la Recepcion con el id dado en la base de datos y la devuelve

        Recepcion recepcion = new Recepcion();

        try{

            recepcion = contexto.Recepciones.Include(x => x.Problemas).Where(x => x.RecepcionId == Id).SingleOrDefault();

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }

        return recepcion;

    }

    public static bool Update(Recepcion recepcion){//Dada una Recepcion, modifica la equivalente en la base de datos
        
        bool successfull = false;

        try{

            if(recepcion.Problemas.Any()){
                
                Delete(recepcion);
                successfull = contexto.SaveChanges() > 0;

                Create(recepcion);
                successfull = contexto.SaveChanges() > 0;


            }else if(contexto.Recepciones.Any(l => l.RecepcionId == recepcion.RecepcionId)){
                
                contexto.Recepciones.Update(recepcion);
                
                successfull = contexto.SaveChanges() > 0;

            }

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }

        return successfull;

    }

    public static bool Delete(Recepcion recepcion){//Dada una Recepcion, elimina la equivalente en la base de datos
    
        bool successfull = false;
        
        try{

            contexto.Remove(recepcion);
            successfull = contexto.SaveChanges() > 0;

        }catch(Exception e){

            Console.WriteLine(e.Message);

        }
        
        return successfull;

    }

    public static List<Recepcion> GetList(){

        return contexto.Recepciones.ToList();
        
    }

}