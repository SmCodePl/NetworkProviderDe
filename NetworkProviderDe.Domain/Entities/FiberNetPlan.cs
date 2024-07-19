using System.ComponentModel.DataAnnotations;

namespace NetworkProviderDe.Domain.Entities;

public class FiberNetPlan
{
    [Key]
    public long PlanId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string PlanName { get; set; } = string.Empty;
    public string PlanDescription { get; set; } = string.Empty;
    public double PlanPrice { get; set; }
    public int PlanSpeed { get; set; }
    public bool IsUnlimited { get; set; }
    public bool IsDiscounted { get; set; }
    public bool IsPromoted { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
