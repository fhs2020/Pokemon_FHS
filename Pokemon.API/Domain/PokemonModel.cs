using System.ComponentModel.DataAnnotations;

namespace Pokemon.API.Domain
{
    public class PokemonModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }

        public bool? ehPokemonMestre { get; set; } = false;
        public bool? PokemonFoiCapturado { get; set; } = false;

    }
}
