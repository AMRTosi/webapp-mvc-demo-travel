using TravelSearchApp.Models;

namespace TravelSearchApp.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de repositorio de vuelos
    /// </summary>
    public interface IFlightRepository
    {
        /// <summary>
        /// Busca vuelos basado en criterios específicos
        /// </summary>
        /// <param name="searchCriteria">Criterios de búsqueda</param>
        /// <returns>Lista de vuelos encontrados</returns>
        Task<IEnumerable<Flight>> SearchFlightsAsync(FlightSearchCriteria searchCriteria);

        /// <summary>
        /// Obtiene un vuelo por su ID
        /// </summary>
        /// <param name="flightId">ID del vuelo</param>
        /// <returns>Vuelo encontrado o null</returns>
        Task<Flight?> GetFlightByIdAsync(string flightId);

        /// <summary>
        /// Obtiene todos los vuelos disponibles
        /// </summary>
        /// <returns>Lista de todos los vuelos</returns>
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
    }
}
