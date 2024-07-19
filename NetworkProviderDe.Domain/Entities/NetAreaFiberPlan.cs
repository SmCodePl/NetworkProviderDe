
using System.ComponentModel.DataAnnotations;

namespace NetworkProviderDe.Domain.Entities;

public class NetAreaFiberPlan
{
    [Key]
    public long AreaFiberPlanId { get; set; }
    public NetArea Area { get; set; } = new();
    public long PlanId { get; set; }
}
