namespace BK_Server.DTO
{
    public class UpgradeDTO
    {
        public short Playerid { get; set; }
        public sbyte Teamid { get; set; }
        public string Attribute { get; set; } = null!;
        public DateTime Expirydate { get; set; }
        public short Cost { get; set; }
    }
}