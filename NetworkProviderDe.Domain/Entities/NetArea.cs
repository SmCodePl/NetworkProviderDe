

using System.ComponentModel.DataAnnotations;

namespace NetworkProviderDe.Domain.Entities;

public class NetArea
{
    [Key]
    public long AreaId { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string PlaceName { get; set; } = string.Empty;
    public string AdminName { get; set; } = string.Empty;
    public string AdminCode { get; set; } = string.Empty;
    public int AdminCode2 { get; set; } 
    public int AdminCode3 { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int Accuracy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
