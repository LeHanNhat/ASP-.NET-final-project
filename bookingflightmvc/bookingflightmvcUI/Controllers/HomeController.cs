using bookingflightmvcUI.Models;
using bookingflightmvcUI.Repository;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;

namespace bookingflightmvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }


        public async Task<IEnumerable<Airport>> Airport()
        {
            return await _context.Airports.ToListAsync();
        }
        public async Task<IEnumerable<Flight>> GetBooks(string sTerm = "", int airportId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Flight> books = await (from book in _context.Flights
                                               join genre in _context.Airports
                                               on book.AirportId equals genre.Id

                                               where string.IsNullOrWhiteSpace(sTerm) || (book != null && book.FlightName.ToLower().StartsWith(sTerm))
                                               select new Flight
                                               {
                                                   Id = book.Id,
                                                   Image = book.Image,
                                                   AirportId = book.AirportId,
                                                   FlightName = book.FlightName,
                                                   departureTime = book.departureTime,
                                                   arrivalTime = book.arrivalTime,
                                                   AircraftType = book.AircraftType,
                                                   ticketPrice = book.ticketPrice,
                                                   duration = book.duration,
                                                   numberOfStops = book.numberOfStops,
                                                   seatClass = book.seatClass,
                                                   
                                                   baggageRegulations = book.baggageRegulations,
                                                   ancillaryServices = book.ancillaryServices,

                                               }
                         ).ToListAsync();
            if (airportId > 0)
            {

                books = books.Where(a => a.AirportId == airportId).ToList();
            }

            return books;

        }
        public async Task<IActionResult> Index(string sTerm = "", int airportId = 0)
        {

            IEnumerable<Flight> books = await GetBooks(sTerm, airportId);

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
