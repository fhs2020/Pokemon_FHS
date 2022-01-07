using System.ComponentModel.DataAnnotations;

namespace PokemonWebApplication.Models
{
    public class MestrePokemon
    {
        [Key]
        public int IdDoPokemon { get; set; }
        public string Nome { get; set; }
        public int  Idade { get; set; }
        public string CPF { get; set; }
    }
}
