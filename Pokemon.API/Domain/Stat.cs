﻿namespace Pokemon.API.Domain
{
    public partial class Rootobject
    {
        public class Stat
        {
            public int base_stat { get; set; }
            public int effort { get; set; }
            public Stat1 stat { get; set; }
        }

    }
}
