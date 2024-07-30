
namespace NetworkProviderDe.Domain.Models;

public class ProductResult
{
    public long ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public int TdcOtc { get; set; }
    public double ProductPrice { get; set; }
    public int Speed { get; set; }
    public int Mrc { get; set; }
    public bool IsUnlimited { get; set; }
    public bool IsDiscounted { get; set; }
    public bool IsPromoted { get; set; }
    public ProductTypeResult ProductType { get; set; } = new(0,string.Empty);
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
   
}
