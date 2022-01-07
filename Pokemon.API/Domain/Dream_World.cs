using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Dream_World
        {
            public string front_default { get; set; }

            [NotMapped]
            public object front_female { get; set; }
        }

    }
}
