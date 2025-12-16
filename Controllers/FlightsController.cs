using Microsoft.AspNetCore.Mvc;
using TravelSearchApp.Models;
using TravelSearchApp.Repositories.Interfaces;

namespace TravelSearchApp.Controllers
{
    /// <summary>
    /// Controlador para la búsqueda de vuelos
    /// </summary>
    public class FlightsController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(
            IFlightRepository flightRepository, 
            IAirportRepository airportRepository,
            ILogger<FlightsController> logger)
        {
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
            _logger = logger;
        }

        /// <summary>
        /// Muestra el formulario de búsqueda de vuelos
        /// </summary>
        [HttpGet]
        public IActionResult Search()
        {
            var model = new FlightSearchCriteria
            {
                DepartureDate = DateTime.Today.AddDays(1), // Por defecto mañana
                IsRoundTrip = true,
                Passengers = 1
            };

            return View(model);
        }

        /// <summary>
        /// Procesa la búsqueda de vuelos
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(FlightSearchCriteria searchCriteria)
        {
            _logger.LogInformation("Iniciando búsqueda de vuelos: {Origin} -> {Destination}, {Date}",
                searchCriteria.Origin, searchCriteria.Destination, searchCriteria.DepartureDate);

            // Validaciones adicionales del lado servidor
            if (!searchCriteria.IsValidRoute)
            {
                ModelState.AddModelError(string.Empty, "El origen y destino deben ser diferentes.");
            }

            if (!searchCriteria.IsValidDates)
            {
                ModelState.AddModelError("DepartureDate", "Las fechas no son válidas.");
            }

            if (searchCriteria.DepartureDate < DateTime.Today)
            {
                ModelState.AddModelError("DepartureDate", "La fecha de ida no puede ser anterior a hoy.");
            }

            if (searchCriteria.IsRoundTrip && searchCriteria.ReturnDate.HasValue && 
                searchCriteria.ReturnDate.Value < searchCriteria.DepartureDate)
            {
                ModelState.AddModelError("ReturnDate", "La fecha de vuelta no puede ser anterior a la fecha de ida.");
            }

            if (!ModelState.IsValid)
            {
                return View(searchCriteria);
            }

            try
            {
                // Buscar vuelos de ida
                var outboundFlights = await _flightRepository.SearchFlightsAsync(searchCriteria);
                var returnFlights = new List<Flight>();

                // Si es viaje de ida y vuelta, buscar vuelos de vuelta
                if (searchCriteria.IsRoundTrip && searchCriteria.ReturnDate.HasValue)
                {
                    var returnCriteria = new FlightSearchCriteria
                    {
                        Origin = searchCriteria.Destination,
                        Destination = searchCriteria.Origin,
                        DepartureDate = searchCriteria.ReturnDate.Value,
                        Passengers = searchCriteria.Passengers,
                        IsRoundTrip = false
                    };
                    returnFlights = (await _flightRepository.SearchFlightsAsync(returnCriteria)).ToList();
                }

                var searchResult = new FlightSearchResult
                {
                    OutboundFlights = outboundFlights,
                    ReturnFlights = returnFlights,
                    SearchCriteria = searchCriteria,
                    SearchSummary = CreateSearchSummary(searchCriteria, outboundFlights.Count(), returnFlights.Count())
                };

                _logger.LogInformation("Búsqueda completada. Vuelos de ida: {OutboundCount}, Vuelos de vuelta: {ReturnCount}",
                    outboundFlights.Count(), returnFlights.Count());

                return View("Results", searchResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante la búsqueda de vuelos");
                ModelState.AddModelError(string.Empty, "Ocurrió un error durante la búsqueda. Por favor, inténtelo de nuevo.");
                return View(searchCriteria);
            }
        }

        /// <summary>
        /// API endpoint para autocompletado de aeropuertos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAirports(string term)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(term) || term.Length < 2)
                {
                    return Json(new List<object>());
                }

                var airports = await _airportRepository.SearchAirportsAsync(term);
                var suggestions = airports.Take(10).Select(a => new
                {
                    value = a.Code,
                    label = a.DisplayName,
                    code = a.Code,
                    name = a.Name,
                    city = a.City,
                    country = a.Country
                });

                return Json(suggestions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo aeropuertos para autocompletado");
                return Json(new List<object>());
            }
        }

        /// <summary>
        /// Muestra los detalles de un vuelo específico
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            try
            {
                var flight = await _flightRepository.GetFlightByIdAsync(id);
                if (flight == null)
                {
                    return NotFound();
                }

                return View(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo detalles del vuelo: {FlightId}", id);
                return NotFound();
            }
        }

        /// <summary>
        /// Crea un resumen de la búsqueda realizada
        /// </summary>
        private string CreateSearchSummary(FlightSearchCriteria criteria, int outboundCount, int returnCount)
        {
            var summary = $"Búsqueda de {criteria.Origin} a {criteria.Destination} el {criteria.DepartureDate:dd/MM/yyyy}";
            
            if (criteria.IsRoundTrip && criteria.ReturnDate.HasValue)
            {
                summary += $" y vuelta el {criteria.ReturnDate:dd/MM/yyyy}";
            }
            
            summary += $" para {criteria.Passengers} pasajero{(criteria.Passengers > 1 ? "s" : "")}. ";
            
            var totalResults = outboundCount + returnCount;
            if (totalResults == 0)
            {
                summary += "No se encontraron vuelos.";
            }
            else
            {
                summary += $"Se encontraron {totalResults} vuelo{(totalResults > 1 ? "s" : "")}.";
            }

            return summary;
        }
    }
}
