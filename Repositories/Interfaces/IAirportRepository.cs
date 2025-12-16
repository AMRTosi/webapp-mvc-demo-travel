using TravelSearchApp.Models;

namespace TravelSearchApp.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de repositorio de aeropuertos
    /// </summary>
    public interface IAirportRepository
    {
        /// <summary>
        /// Obtiene todos los aeropuertos
        /// </summary>
        /// <returns>Lista de aeropuertos</returns>
        Task<IEnumerable<Airport>> GetAllAirportsAsync();

        /// <summary>
        /// Busca aeropuertos por término de búsqueda
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda</param>
        /// <returns>Lista de aeropuertos que coinciden</returns>
        Task<IEnumerable<Airport>> SearchAirportsAsync(string searchTerm);

        /// <summary>
        /// Obtiene un aeropuerto por su código
        /// </summary>
        /// <param name="airportCode">Código del aeropuerto</param>
        /// <returns>Aeropuerto encontrado o null</returns>
        Task<Airport?> GetAirportByCodeAsync(string airportCode);
    }
}
