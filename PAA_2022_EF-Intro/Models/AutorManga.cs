using System.ComponentModel.DataAnnotations.Schema;

namespace PAA_2022_EF_Intro.Models
{
    [Table("AutorManga")] // Indicar la tabla al que pertenecerá la clase POCO
    public class AutorManga
    {
        public int Id { get; set; }
        public string NombreAutor { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public int CantidadObras { get; set; }

        // Relaciones
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
