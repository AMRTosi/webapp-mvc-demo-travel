using TravelSearchApp.Models;
using TravelSearchApp.Repositories.Interfaces;
using TravelSearchApp.Services.Interfaces;

namespace TravelSearchApp.Repositories
{
    /// <summary>
    /// Implementación del repositorio de vuelos usando archivos JSON
    /// </summary>
    public class FlightRepository : IFlightRepository
    {
        private readonly IJsonDataService _jsonDataService;
        private readonly ILogger<FlightRepository> _logger;
        private List<Flight>? _cachedFlights;

        public FlightRepository(IJsonDataService jsonDataService, ILogger<FlightRepository> logger)
        {
            _jsonDataService = jsonDataService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los vuelos cargándolos desde el archivo JSON si es necesario
        /// </summary>
        private async Task<List<Flight>> GetFlightsCacheAsync()
        {
            if (_cachedFlights == null)
            {
                _logger.LogInformation("Cargando vuelos desde archivo JSON");
                var flights = await _jsonDataService.ReadJsonListAsync<Flight>("flights.json");
                _cachedFlights = flights.ToList();
                _logger.LogInformation("Vuelos cargados: {Count}", _cachedFlights.Count);
            }
            return _cachedFlights;
        }

        /// <summary>
        /// Busca vuelos basado en criterios específicos
        /// </summary>
        public async Task<IEnumerable<Flight>> SearchFlightsAsync(FlightSearchCriteria searchCriteria)
        {
            try
            {
                var allFlights = await GetFlightsCacheAsync();
                
                var filteredFlights = allFlights.Where(f =>
                    f.Origin.Equals(searchCriteria.Origin, StringComparison.OrdinalIgnoreCase) &&
                    f.Destination.Equals(searchCriteria.Destination, StringComparison.OrdinalIgnoreCase) &&
                    f.DepartureTime.Date == searchCriteria.DepartureDate.Date &&
                    f.AvailableSeats >= searchCriteria.Passengers
                ).OrderBy(f => f.DepartureTime);

                _logger.LogInformation("Búsqueda realizada: {Origin} -> {Destination}, {Date}. Resultados: {Count}",
                    searchCriteria.Origin, searchCriteria.Destination, searchCriteria.DepartureDate.ToShortDateString(), filteredFlights.Count());

                return filteredFlights;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error buscando vuelos");
                return new List<Flight>();
            }
        }

        /// <summary>
        /// Obtiene un vuelo por su ID
        /// </summary>
        public async Task<Flight?> GetFlightByIdAsync(string flightId)
        {
            try
            {
                var allFlights = await GetFlightsCacheAsync();
                return allFlights.FirstOrDefault(f => f.Id.Equals(flightId, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo vuelo por ID: {FlightId}", flightId);
                return null;
            }
        }

        /// <summary>
        /// Obtiene todos los vuelos disponibles
        /// </summary>
        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            try
            {
                return await GetFlightsCacheAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todos los vuelos");
                return new List<Flight>();
            }
        }
    }
}
