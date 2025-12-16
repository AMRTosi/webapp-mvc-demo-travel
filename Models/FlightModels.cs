using System.ComponentModel.DataAnnotations;

namespace TravelSearchApp.Models
{
    /// <summary>
    /// Modelo que representa un vuelo
    /// </summary>
    public class Flight
    {
        public string Id { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "EUR";
        public int AvailableSeats { get; set; }
        public TimeSpan Duration { get; set; }
        public bool HasStops { get; set; }
        public string AircraftType { get; set; } = string.Empty;
    }

    /// <summary>
    /// Modelo que representa un aeropuerto
    /// </summary>
    public class Airport
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string DisplayName => $"{Name} ({Code}) - {City}, {Country}";
    }

    /// <summary>
    /// Criterios de búsqueda de vuelos
    /// </summary>
    public class FlightSearchCriteria
    {
        [Required(ErrorMessage = "El origen es obligatorio")]
        [Display(Name = "Origen")]
        public string Origin { get; set; } = string.Empty;

        [Required(ErrorMessage = "El destino es obligatorio")]
        [Display(Name = "Destino")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de ida es obligatoria")]
        [Display(Name = "Fecha de ida")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; } = DateTime.Today;

        [Display(Name = "Fecha de vuelta")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Número de pasajeros")]
        [Range(1, 9, ErrorMessage = "El número de pasajeros debe estar entre 1 y 9")]
        public int Passengers { get; set; } = 1;

        [Display(Name = "Viaje de ida y vuelta")]
        public bool IsRoundTrip { get; set; } = true;

        /// <summary>
        /// Valida que el origen y destino sean diferentes
        /// </summary>
        public bool IsValidRoute => !string.IsNullOrEmpty(Origin) && 
                                   !string.IsNullOrEmpty(Destination) && 
                                   !Origin.Equals(Destination, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Valida que las fechas sean válidas
        /// </summary>
        public bool IsValidDates => DepartureDate >= DateTime.Today &&
                                   (!IsRoundTrip || !ReturnDate.HasValue || ReturnDate >= DepartureDate);
    }

    /// <summary>
    /// Resultado de búsqueda de vuelos
    /// </summary>
    public class FlightSearchResult
    {
        public IEnumerable<Flight> OutboundFlights { get; set; } = new List<Flight>();
        public IEnumerable<Flight> ReturnFlights { get; set; } = new List<Flight>();
        public FlightSearchCriteria SearchCriteria { get; set; } = new();
        public bool HasResults => OutboundFlights.Any();
        public int TotalResults => OutboundFlights.Count() + ReturnFlights.Count();
        public string SearchSummary { get; set; } = string.Empty;
    }
}
