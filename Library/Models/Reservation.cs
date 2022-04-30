using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int? Roomnr { get; set; }
        public int? Userid { get; set; }

        public virtual Room? RoomnrNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
