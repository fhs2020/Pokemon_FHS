namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Past_Types
        {
            public Generation generation { get; set; }
            public Type[] types { get; set; }
        }

    }
}
