using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}