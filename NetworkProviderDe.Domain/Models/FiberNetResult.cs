
namespace NetworkProviderDe.Domain.Models
{
    public class FiberNetResult
    {
        public string CountryCode { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string PlaceName { get; set; } = string.Empty;
        public string AdminName { get; set; } = string.Empty;
        public string AdminCode { get; set; } = string.Empty;
        public int AdminCode2 { get; set; }
        public int AdminCode3 { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }        
        public long PlanId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string PlanName { get; set; } = string.Empty;
        public string PlanDescription { get; set; } = string.Empty;
        public double PlanPrice { get; set; }
        public int PlanSpeed { get; set; }
        public bool IsUnlimited { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsPromoted { get; set; }
    }
}
