using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int? Roomnr { get; set; }
        public int? Userid { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool? CheckedIn { get; set; }
        public bool? CheckedOut { get; set; }

        public virtual Room? RoomnrNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
