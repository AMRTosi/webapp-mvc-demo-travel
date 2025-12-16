using TravelSearchApp.Models;
using TravelSearchApp.Repositories.Interfaces;
using TravelSearchApp.Services.Interfaces;

namespace TravelSearchApp.Repositories
{
    /// <summary>
    /// Implementación del repositorio de aeropuertos usando archivos JSON
    /// </summary>
    public class AirportRepository : IAirportRepository
    {
        private readonly IJsonDataService _jsonDataService;
        private readonly ILogger<AirportRepository> _logger;
        private List<Airport>? _cachedAirports;

        public AirportRepository(IJsonDataService jsonDataService, ILogger<AirportRepository> logger)
        {
            _jsonDataService = jsonDataService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los aeropuertos cargándolos desde el archivo JSON si es necesario
        /// </summary>
        private async Task<List<Airport>> GetAirportsCacheAsync()
        {
            if (_cachedAirports == null)
            {
                _logger.LogInformation("Cargando aeropuertos desde archivo JSON");
                var airports = await _jsonDataService.ReadJsonListAsync<Airport>("airports.json");
                _cachedAirports = airports.ToList();
                _logger.LogInformation("Aeropuertos cargados: {Count}", _cachedAirports.Count);
            }
            return _cachedAirports;
        }

        /// <summary>
        /// Obtiene todos los aeropuertos
        /// </summary>
        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            try
            {
                return await GetAirportsCacheAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todos los aeropuertos");
                return new List<Airport>();
            }
        }

        /// <summary>
        /// Busca aeropuertos por término de búsqueda
        /// </summary>
        public async Task<IEnumerable<Airport>> SearchAirportsAsync(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return new List<Airport>();
                }

                var allAirports = await GetAirportsCacheAsync();
                var searchTermLower = searchTerm.ToLowerInvariant();
                
                var matchingAirports = allAirports.Where(a =>
                    a.Code.ToLowerInvariant().Contains(searchTermLower) ||
                    a.Name.ToLowerInvariant().Contains(searchTermLower) ||
                    a.City.ToLowerInvariant().Contains(searchTermLower) ||
                    a.Country.ToLowerInvariant().Contains(searchTermLower)
                ).OrderBy(a => a.Code);

                _logger.LogInformation("Búsqueda de aeropuertos: '{SearchTerm}'. Resultados: {Count}",
                    searchTerm, matchingAirports.Count());

                return matchingAirports;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error buscando aeropuertos con término: {SearchTerm}", searchTerm);
                return new List<Airport>();
            }
        }

        /// <summary>
        /// Obtiene un aeropuerto por su código
        /// </summary>
        public async Task<Airport?> GetAirportByCodeAsync(string airportCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(airportCode))
                {
                    return null;
                }

                var allAirports = await GetAirportsCacheAsync();
                return allAirports.FirstOrDefault(a => 
                    a.Code.Equals(airportCode, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo aeropuerto por código: {AirportCode}", airportCode);
                return null;
            }
        }
    }
}
