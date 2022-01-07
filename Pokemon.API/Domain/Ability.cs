namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Ability
        {
            public int Id { get; set; }
            public Ability1 ability { get; set; }
            public bool is_hidden { get; set; }
            public int slot { get; set; }
        }

    }
}
