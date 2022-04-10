using Microsoft.EntityFrameworkCore;

public class RecepcionesBLL{

    private static Contexto contexto = new Contexto();

    public static bool Create(Recepcion recepcion){//Inserta una Recepcion a la base de datos

        bool successfull = false;

        // contexto.Entry(recepcion).State = EntityState.Added;
        contexto.Recepciones.Add(recepcion);

        successfull = contexto.SaveChanges() > 0;

        return successfull;

    }

    public static Recepcion Read(int Id){//Lee la Recepcion con el id dado en la base de datos y la devuelve

        Recepcion recepcion = new Recepcion();

        recepcion = contexto.Recepciones.Find(Id);

        return recepcion;

    }

    public static bool Update(Recepcion recepcion){//Dada una Recepcion, modifica la equivalente en la base de datos
        
        bool successfull = false;

        // if(contexto.Recepciones.Any(l => l.RecepcionId == recepcion.RecepcionId)){

        //     // contexto.Entry(recepcion).State = EntityState.Modified;
        //     contexto.Recepciones.Update(recepcion);
        //     successfull = contexto.SaveChanges() > 0;

        // }


        if(recepcion.Problemas.Any()){
            
            Delete(recepcion);
            successfull = contexto.SaveChanges() > 0;

            Create(recepcion);
            successfull = contexto.SaveChanges() > 0;


        }else if(contexto.Recepciones.Any(l => l.RecepcionId == recepcion.RecepcionId)){
            
            contexto.Recepciones.Update(recepcion);
            
            successfull = contexto.SaveChanges() > 0;

        }


        return successfull;

    }

    public static bool Delete(Recepcion recepcion){//Dada una Recepcion, elimina la equivalente en la base de datos
    
        bool successfull = false;

        // contexto.Entry(recepcion).State = EntityState.Deleted;
        // List<RecepcionDetalle> nueva = new List<RecepcionDetalle>();
        // recepcion.Problemas = nueva;
        // Update(recepcion);

        

        contexto.Remove(recepcion);
        successfull = contexto.SaveChanges() > 0;
        
        return successfull;

    }

    public static Recepcion BuscarTecnico(string Tecnico){
        
        return contexto.Recepciones
            .Where(x => x.Tecnico == Tecnico)
            .FirstOrDefault();

    }

}