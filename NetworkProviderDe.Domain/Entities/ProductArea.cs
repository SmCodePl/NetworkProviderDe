
using System.ComponentModel.DataAnnotations;

namespace NetworkProviderDe.Domain.Entities;

public class ProductArea
{
    [Key]
    public long ProductAreaId { get; set; }
    public NetArea Area { get; set; } = new();
    public Product Product { get; set; } = new();
}
