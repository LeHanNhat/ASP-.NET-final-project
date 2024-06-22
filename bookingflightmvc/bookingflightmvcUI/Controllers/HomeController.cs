using bookingflightmvcUI.Models;
using bookingflightmvcUI.Repository;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private void PeopleDropDownList(object selectedPerson = null)
        {
            var AirportQuery = from d in _context.Airports select d;
            ViewBag.AirportId = new SelectList(AirportQuery.AsNoTracking(), "Id", "AirportName", AirportQuery);
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber,int airportId =0)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            PeopleDropDownList();
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            
            var flights = from s in _context.Flights.Include(_ => _.Airport) select s;
            if (airportId > 0 )
            {
                flights = flights.Where(a => a.AirportId == airportId);
            } 
            
               
            
            
            if (!String.IsNullOrEmpty(searchString))
            {
                flights = flights.Where(s => s.FlightName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    flights = flights.OrderByDescending(s => s.FlightName);
                    break;
                case "Date":
                    flights = flights.OrderBy(s => s.departureTime);
                    break;
                case "date_desc":
                    flights = flights.OrderByDescending(s => s.arrivalTime);
                    break;
                default:
                    flights = flights.OrderBy(s => s.FlightName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Flight>.CreateAsync(flights.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Airport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
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
