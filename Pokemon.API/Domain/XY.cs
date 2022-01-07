using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class XY
        {
            public string front_default { get; set; }

            [NotMapped]
            public object front_female { get; set; }
            public string front_shiny { get; set; }

            [NotMapped]
            public object front_shiny_female { get; set; }
        }

    }
}
