

namespace NetworkProviderDe.Domain.Models;

public class ProductTypeResult
{
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; } = string.Empty;
    public ProductTypeResult(int productTypeId, string productTypeName)
    {
        ProductTypeId = productTypeId;
        ProductTypeName = productTypeName;
    }
}
