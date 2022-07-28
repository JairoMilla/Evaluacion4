using Microsoft.EntityFrameworkCore;

namespace PAA_2022_EF_Intro.Models
{
    public class EFContext : DbContext
    {
        // 1. Crear atributo que almacene la cadena de conexión a la BD
        private const string ConnectionString = "server=localhost;port=3306;database=manga_db;user=root;password=;Connect Timeout=5;";
       
        // para configurar la instancia inicial de MySQL en conexión al proyecto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString,
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

        // 2. Definir qué clases son modelos desde la base de datos
        public DbSet<AutorManga> AutorManga { get; set; }
        public DbSet<Manga> Manga { get; set; }

        // 3. Configurar los modelos 
        // * Definir clave primaria * Establecer las relaciones
        // * Definir cuáles son obligatorios * Cuál tiene valor por defecto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir claves primarias
            modelBuilder.Entity<Manga>().HasKey(i => i.Id);
            modelBuilder.Entity<AutorManga>().HasKey(j => j.Id);

            // Definir relaciones uno a muchos: Canción a Álbum
            modelBuilder.Entity<Manga>()
                .HasOne<AutorManga>(s => s.AutorManga)
                .WithMany(g => g.Mangas)
                .HasForeignKey(c => c.IdAutor);

            // Definimos los obligatorios (not null - mandatory) 
            // Canción:
            modelBuilder.Entity<Manga>().Property(s => s.IdAutor).IsRequired();
            modelBuilder.Entity<Manga>().Property(s => s.NombreManga).IsRequired();
            modelBuilder.Entity<Manga>().Property(s => s.CantidadTomos).IsRequired();

            // Álbum:
            modelBuilder.Entity<AutorManga>().Property(s => s.NombreAutor).IsRequired();
            modelBuilder.Entity<AutorManga>().Property(s => s.FechaNacimiento)
                .HasDefaultValue(DateTime.Now) // Indicar un valor por defecto
                .IsRequired();
            modelBuilder.Entity<AutorManga>().Property(s => s.CantidadObras).IsRequired();
        }

    }
}
