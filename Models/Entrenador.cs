using System.ComponentModel.DataAnnotations;

namespace ApiPokedex.Models
{
    public class Entrenador
    {
        [Key]
        public int EntrenadorId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}