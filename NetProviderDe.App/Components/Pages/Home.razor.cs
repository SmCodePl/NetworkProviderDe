using Blazorise.LoadingIndicator;
using Microsoft.AspNetCore.Components;

using System.Text.Json;

namespace NetProviderDe.App.Components.Pages;

public partial class Home
{
    [Parameter]
    public string PostalCode { get; set; } = string.Empty;
    [Parameter]
    public bool ShowPlans { get; set; } = false;
    public LoadingIndicator loadingIndicator = new();
    public FiberNetResult? FiberNetResults { get; set; }
    private HttpClient _http = new HttpClient();
    
    protected async Task OnButtonFindPostalCode()
    {
       await loadingIndicator.Show();
        Uri uri = new Uri($"https://sm-code.eu/FiberNetPlan/FiberNetPlansByArea?postalCode={PostalCode}");

        var request = new HttpRequestMessage(HttpMethod.Get,uri);
        var response = await _http.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                var netResults = JsonSerializer.Deserialize<List<FiberNetResult>>(result);
                if (netResults != null)
                {
                    FiberNetResults = netResults.FirstOrDefault();
                    ShowPlans = true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            ShowPlans = false;
        }
       await loadingIndicator.Hide();
    }
  
    public class ProductResult
    {
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public string productDescription { get; set; } = string.Empty;
        public int tdcOtc { get; set; }
        public int productPrice { get; set; }
        public int speed { get; set; }
        public int mrc { get; set; }
        public bool isUnlimited { get; set; }
        public bool isDiscounted { get; set; }
        public bool isPromoted { get; set; }
        public ProductType productType { get; set; } = new();
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class FiberNetResult
    {
        public int areaId { get; set; }
        public string countryCode { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
        public string placeName { get; set; } = string.Empty;
        public string adminName { get; set; } = string.Empty;
        public string adminCode { get; set; } = string.Empty;
        public int adminCode2 { get; set; }
        public int adminCode3 { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public List<ProductResult> productResult { get; set; } = new();
    }

    public class ProductType
    {
        public int productTypeId { get; set; }
        public string productTypeName { get; set; } = string.Empty;
    }

}
