using System.Text.Json;
using TravelSearchApp.Services.Interfaces;

namespace TravelSearchApp.Services
{
    /// <summary>
    /// Servicio para lectura y deserialización de archivos JSON
    /// </summary>
    public class JsonDataService : IJsonDataService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<JsonDataService> _logger;

        public JsonDataService(IWebHostEnvironment environment, ILogger<JsonDataService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        /// <summary>
        /// Lee y deserializa datos desde un archivo JSON
        /// </summary>
        /// <typeparam name="T">Tipo de datos a deserializar</typeparam>
        /// <param name="filePath">Ruta del archivo JSON relativa a la carpeta Data</param>
        /// <returns>Datos deserializados</returns>
        public async Task<T?> ReadJsonDataAsync<T>(string filePath) where T : class
        {
            try
            {
                var fullPath = Path.Combine(_environment.ContentRootPath, "Data", filePath);
                
                if (!File.Exists(fullPath))
                {
                    _logger.LogWarning("Archivo JSON no encontrado: {FilePath}", fullPath);
                    return null;
                }

                var jsonContent = await File.ReadAllTextAsync(fullPath);
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result = JsonSerializer.Deserialize<T>(jsonContent, options);
                _logger.LogInformation("Archivo JSON leído exitosamente: {FilePath}", filePath);
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error leyendo archivo JSON: {FilePath}", filePath);
                return null;
            }
        }

        /// <summary>
        /// Lee y deserializa una lista desde un archivo JSON
        /// </summary>
        /// <typeparam name="T">Tipo de elementos en la lista</typeparam>
        /// <param name="filePath">Ruta del archivo JSON relativa a la carpeta Data</param>
        /// <returns>Lista de datos deserializados</returns>
        public async Task<IEnumerable<T>> ReadJsonListAsync<T>(string filePath) where T : class
        {
            try
            {
                var result = await ReadJsonDataAsync<List<T>>(filePath);
                return result ?? new List<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error leyendo lista JSON: {FilePath}", filePath);
                return new List<T>();
            }
        }
    }
}
