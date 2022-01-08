using System.ComponentModel.DataAnnotations;

namespace Pokemon.API.Domain
{
    public class PokemonModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        [StringLength(11, ErrorMessage = "CPF nao pode ser maior que 11 numeros")]
        public string CPF { get; set; } = string.Empty;
        public bool? ehPokemonMestre { get; set; } = false;
        public bool? PokemonFoiCapturado { get; set; } = false;

    }
}
