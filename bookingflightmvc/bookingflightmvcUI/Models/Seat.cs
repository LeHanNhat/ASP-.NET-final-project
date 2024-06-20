using System.ComponentModel.DataAnnotations.Schema;

namespace bookingflightmvcUI.Models
{
    [Table("Seat")]
    public class Seat
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public Flight? Flight { get; set; }
    }
}
