using System;
using System.Collections.Generic;

namespace BK_Server.Models
{
    public partial class Infrastructure
    {
        public sbyte Id { get; set; }
        public sbyte Gym { get; set; }
        public sbyte Coaches { get; set; }

        public virtual Team IdNavigation { get; set; } = null!;
    }
}