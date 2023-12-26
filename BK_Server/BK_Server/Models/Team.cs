using System;
using System.Collections.Generic;

namespace BK_Server.Models
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public sbyte Teamid { get; set; }
        public string Name { get; set; } = null!;
        public double Money { get; set; }
        public double Income { get; set; }
        public double Expense { get; set; }
        public sbyte MatchesPlayed { get; set; }
        public sbyte Wins { get; set; }
        public sbyte Losses { get; set; }
        public double WinningPercentage { get; set; }
        public short PointsScored { get; set; }
        public short PointsConceded { get; set; }
        public short PointDifference { get; set; }
        public sbyte Position { get; set; }

        public virtual Infrastructure? Infrastructure { get; set; }
        public virtual Stadium? Stadium { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}