using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Todo
    {
        public Todo()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public int Id { get; set; }
        public bool Cleaned { get; set; }

        public bool Maintained { get; set; }
        public bool Serviced { get; set; }

        public string Notes { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}