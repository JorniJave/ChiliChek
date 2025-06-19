namespace ChiliChek.Models
{
    public class Threat
    {
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public DateTime Timestamp { get; set; }
        public string? SteamId { get; set; }
    }
}