
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace bookingflightmvcUI.Repository
{
    public class HomeRepository
        
    {
        //private readonly ApplicationDbContext _dbContext;
        //public HomeRepository(ApplicationDbContext _db)
        //{
        //        this._dbContext = _db;
        //}
        //public async Task<IEnumerable<Flight>> DisplayFlights(string sTerm = "", int categoryId = 0)
        //{
        //    sTerm = sTerm.Trim();
        //    var flights = (from flight in _dbContext.Flights
        //                   join airport in _dbContext.Airports
        //                   on flight.AirportId equals airport.Id
        //                   select new Flight
        //                   {
        //                       Id = flight.Id,
        //                       Image = flight.Image,
        //                       AirportId = airport.Id,
        //                       departureTime =flight.departureTime,
        //                       arrivalTime =flight.arrivalTime,
        //                       AircraftType=flight.AircraftType,
        //                       ticketPrice=flight.ticketPrice,
        //                       duration=flight.duration,
        //                       numberOfStops=flight.numberOfStops,  
        //                       seatClass=flight.seatClass,
        //                       ancillaryServices=flight.ancillaryServices,
        //                       baggageRegulations   =flight.baggageRegulations,
        //                   }).ToListAsync();
        //}
    }
}
