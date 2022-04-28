using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Roomnr { get; set; }
        public int Beds { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public bool In_order { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}