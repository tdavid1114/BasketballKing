namespace BK_Server.DTO
{
    public class GetPlayerDTO
    {
        public short Playerid { get; set; }
        public sbyte Teamid { get; set; }
        public string Name { get; set; } = null!;
        public sbyte Age { get; set; }
        public Tuple<sbyte, DateTime, short>? Strength { get; set; }
        public Tuple<sbyte, DateTime, short>? Speed { get; set; }
        public Tuple<sbyte, DateTime, short>? Shooting { get; set; }
        public Tuple<sbyte, DateTime, short>? Finishing { get; set; }
        public Tuple<sbyte, DateTime, short>? Playmaking { get; set; }
        public Tuple<sbyte, DateTime, short>? Defence { get; set; }
        public Tuple<sbyte, DateTime, short>? Blocking { get; set; }
        public Tuple<sbyte, DateTime, short>? Rebounding { get; set; }
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
    }
}