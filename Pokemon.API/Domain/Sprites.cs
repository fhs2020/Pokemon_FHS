using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Sprites
        {
            public string back_default { get; set; }

            [NotMapped]
            public object back_female { get; set; }
            public string back_shiny { get; set; }

            [NotMapped]
            public object back_shiny_female { get; set; }
            public string front_default { get; set; }

            [NotMapped]
            public object front_female { get; set; }
            public string front_shiny { get; set; }

            [NotMapped]
            public object front_shiny_female { get; set; }
            public Other other { get; set; }
            public Versions versions { get; set; }
        }

    }
}
