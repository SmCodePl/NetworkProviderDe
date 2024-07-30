using System.ComponentModel.DataAnnotations;

namespace NetworkProviderDe.Domain.Entities;

public class ProductType
{
    [Key]
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
