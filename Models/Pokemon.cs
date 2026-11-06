using System.ComponentModel.DataAnnotations;

namespace ApiPokedex.Models
{
    public class Pokemon
    {
        [Key]
        public int PokemonId { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
    }
}