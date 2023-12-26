using System;
using System.Collections.Generic;

namespace BK_Server.Models
{
    public partial class Stadium
    {
        public sbyte Id { get; set; }
        public short Ticketprice { get; set; }
        public int Capacity { get; set; }

        public virtual Team IdNavigation { get; set; } = null!;
    }
}