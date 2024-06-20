using System.ComponentModel.DataAnnotations;

namespace bookingflightmvcUI.Models
{
    public class Airport
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string AirportName { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
