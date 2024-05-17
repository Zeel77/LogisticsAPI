namespace LogisticsAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public string Email { get; set; } = null!;
        public string? MobileNo { get; set; }
        public string? Status { get; set; }
        public string? ShiftDetail { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
