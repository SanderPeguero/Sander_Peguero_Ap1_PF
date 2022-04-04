using Microsoft.EntityFrameworkCore;

public class Contexto:DbContext{
    public DbSet<Categoria> Categorias {get; set;}

    public DbSet<Producto> Productos {get; set;}

    public DbSet<Cliente> Clientes {get; set;}

    public DbSet<Recepcion> Recepciones {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
        optionsBuilder.UseSqlite("Data Source=Datos.db");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaId = 1, Nombre = "Bateria", Descripcion = "El dispositivo no enciende sin estar conectado al cargador"},
            new Categoria { CategoriaId = 2, Nombre = "Pantalla", Descripcion = "El dispositivo no muestra nada en pantalla pero suena y da algunas respuestas a la interaccion"},
            new Categoria { CategoriaId = 3, Nombre = "Tarjeta Madre", Descripcion = "El dispositivo no ha sufrido daños fisicos, la bateria y la pantalla funcionan al intercambiarla con un dispositivo de prueba"},
            new Categoria { CategoriaId = 4, Nombre = "Pin de Carga", Descripcion = "El dispositivo no carga, la bateria se muestra en buen estado al intercambiarla con un dispositivo de prueba"}
        );

        modelBuilder.Entity<Producto>().HasData(
            new Producto { ProductoId = 1, Nombre = "Cambio de Bateria", Precio = 400, Descripcion ="El tecnico retira la bateria vieja y la cambia por una nueva" },
            new Producto { ProductoId = 2, Nombre = "Cambio de Pantalla", Precio = 800, Descripcion ="El tecnico retira la bateria vieja y la cambia por otra" },
            new Producto { ProductoId = 3, Nombre = "Cambio de Tarjeta Madre", Precio = 1200, Descripcion ="El tecnico retira la bateria vieja y la cambia por otra" },
            new Producto { ProductoId = 4, Nombre = "Cambio de Pin de Carga", Precio = 1600, Descripcion ="El tecnico retira la bateria vieja y la cambia por otro" }
        );

    }
}
