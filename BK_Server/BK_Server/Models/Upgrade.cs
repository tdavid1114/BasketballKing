using System;
using System.Collections.Generic;

namespace BK_Server.Models
{
    public partial class Upgrade
    {
        public short Id { get; set; }
        public short Playerid { get; set; }
        public sbyte Teamid { get; set; }
        public string Attribute { get; set; } = null!;
        public short Cost { get; set; }
        public DateTime Expirydate { get; set; }
        public sbyte Expired { get; set; }
    }
}