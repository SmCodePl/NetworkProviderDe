using Microsoft.EntityFrameworkCore;

namespace NetworkProviderDe.SharedKernel.Configuration;
public interface IModelConfiguration
{
    void ConfigureModel(ModelBuilder modelBuilder);
}
