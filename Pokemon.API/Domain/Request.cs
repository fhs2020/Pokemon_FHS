using System.Collections.Generic;

namespace Pokemon.API.Domain
{
    public class Request
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public ICollection<Pokemones> results { get; set; }
    }
}
