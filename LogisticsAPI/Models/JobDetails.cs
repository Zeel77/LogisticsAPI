namespace LogisticsAPI.Models
{
    public class JobDetails
    {
        public int Id { get; set; }
        public string? JobId { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? VesselId { get; set; }
        public Vessel? Vessel { get; set; }
        public string? VesselName { get; set; }
        public string? CraftName { get; set; }
        public string? JobType { get; set; }
        public string? JobStatus { get; set; }
        public string? AdviceCode { get; set; }
        public DateTime? ServiceRequestTime { get; set; }
        public string? TugPickUpLocation { get; set; }
        public string? TugLetGoLocation { get; set; }
        public string? LocationFrom { get; set; }
        public string? LocationTo { get; set; }
        public string? PilotCode { get; set; }
        public string? Remarks { get; set; }

    }
}
