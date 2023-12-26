using System;
using System.Collections.Generic;

namespace BK_Server.Models
{
    public partial class Player
    {
        public short Playerid { get; set; }
        public sbyte Teamid { get; set; }
        public string Name { get; set; } = null!;
        public sbyte Age { get; set; }
        public sbyte Strength { get; set; }
        public sbyte Speed { get; set; }
        public sbyte Shooting { get; set; }
        public sbyte Finishing { get; set; }
        public sbyte Playmaking { get; set; }
        public sbyte Defence { get; set; }
        public sbyte Blocking { get; set; }
        public sbyte Rebounding { get; set; }
        public double Overall { get; set; }
        public double Marketvalue { get; set; }
        public double Wage { get; set; }
        public short Height { get; set; }
        public short Weight { get; set; }
        public string Position { get; set; } = null!;
        public sbyte Energy { get; set; }
        public sbyte Retiringage { get; set; }
        public sbyte IsStarter { get; set; }
        public sbyte IsInjured { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}