namespace LogisticsAPI.Models
{
    public class Vessel
    {
        public int Id { get; set; }
        public string? VesselId { get; set; }

        public string VesselName { get; set; } = null!;

        public string Callsign { get; set; } = null!;

        public decimal? GrossTonnage { get; set; }

        public decimal? LengthOverall { get; set; }

        public decimal? Beam { get; set; }

        public decimal? Height { get; set; }

        public decimal? Draft { get; set; }
    }
}
