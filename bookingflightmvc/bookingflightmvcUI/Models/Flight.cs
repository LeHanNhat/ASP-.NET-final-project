using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bookingflightmvcUI.Models

{
    [Table("Flight")]
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? FlightName { get; set; }
        


        //public string departureAirportId { get; set; }
        [Required]
        public int AirportId { get; set; }
        public Airport Airport { get; set; }
        public DateTime departureTime { get; set; }

        
        public DateTime arrivalTime { get; set; }

        
        public string AircraftType { get; set; }
        

        
        public int ticketPrice { get; set; }
        public string duration {  get; set; }
        public int numberOfStops { get; set; }

        public string seatClass { get; set; }

        public string baggageRegulations { get; set; }

        public string ancillaryServices { get; set; }

        [NotMapped]
        public string AirportName { get; set; }
        [NotMapped]
        public int Seat { get; set; }
    }
}
