using System.ComponentModel.DataAnnotations.Schema;

namespace PAA_2022_EF_Intro.Models
{
    [Table("Manga")] // Indicar la tabla al que pertenecerá la clase POCO
    public class Manga
    {
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public string NombreManga { get; set; }
        public int CantidadTomos { get; set; }

        // Relaciones
        public virtual AutorManga AutorManga { get; set; }
    }
}
