namespace TravelSearchApp.Services.Interfaces
{
    /// <summary>
    /// Interfaz para servicios de lectura de datos JSON
    /// </summary>
    public interface IJsonDataService
    {
        /// <summary>
        /// Lee y deserializa datos desde un archivo JSON
        /// </summary>
        /// <typeparam name="T">Tipo de datos a deserializar</typeparam>
        /// <param name="filePath">Ruta del archivo JSON</param>
        /// <returns>Datos deserializados</returns>
        Task<T?> ReadJsonDataAsync<T>(string filePath) where T : class;

        /// <summary>
        /// Lee y deserializa una lista desde un archivo JSON
        /// </summary>
        /// <typeparam name="T">Tipo de elementos en la lista</typeparam>
        /// <param name="filePath">Ruta del archivo JSON</param>
        /// <returns>Lista de datos deserializados</returns>
        Task<IEnumerable<T>> ReadJsonListAsync<T>(string filePath) where T : class;
    }
}
