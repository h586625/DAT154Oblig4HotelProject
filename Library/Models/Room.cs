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
        public int Numberofbeds { get; set; }
        public int Roomsize { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public bool Cleaned { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}