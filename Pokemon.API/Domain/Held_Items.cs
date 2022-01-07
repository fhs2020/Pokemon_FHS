namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Held_Items
        {
            public Item item { get; set; }
            public Version_Details[] version_details { get; set; }
        }

    }
}
