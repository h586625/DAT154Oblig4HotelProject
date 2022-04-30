using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
            Todos = new HashSet<Todo>();
        }

        public int Roomnr { get; set; }
        public int Beds { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public bool InOrder { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }
    }
}
