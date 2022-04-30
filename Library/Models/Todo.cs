using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public int? Roomid { get; set; }
        public bool Cleaned { get; set; }
        public bool Maintained { get; set; }
        public bool Serviced { get; set; }
        public string? Notes { get; set; }

        public virtual Room? Room { get; set; }
    }
}
