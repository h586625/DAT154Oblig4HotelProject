using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Task
    {
        public Task()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public int Tasknr { get; set; }
        public string? Description { get; set; }
        public string? Role { get; set; }

        public string? State { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}