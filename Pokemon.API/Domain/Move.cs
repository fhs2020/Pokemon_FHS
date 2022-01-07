namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Move
        {
            public Move1 move { get; set; }
            public Version_Group_Details[] version_group_details { get; set; }
        }

    }
}
