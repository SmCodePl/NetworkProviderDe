using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;  
using NetworkProviderDe.Domain.Entities;
using NetworkProviderDe.Domain.Models;

namespace NetworkProviderDe.Domain.Services;

public class FiberNetService
{
    private NetProviderContext _context;
    private IMemoryCache _cache;
    public FiberNetService(NetProviderContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }
    public async Task<List<FiberNetPlan>> GetAllNetPlansAsync()
    {
        var cacheKey = $"FiberNetPlan";
        
        // Try get Item from cache. otherwise get from database
        if(!_cache.TryGetValue(cacheKey, out List<FiberNetPlan>? cachedPlans))
        {
            // The item is not in the cache, so we get the result from the database.
            cachedPlans = await _context.Set<FiberNetPlan>().ToListAsync();
            // Set the item in the cache with a relative expiration time of 5 minutes.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(cacheKey, cachedPlans, cacheEntryOptions);
        }
        return cachedPlans ?? new(); 
    }
    public async Task<List<FiberNetResult>> FindByPostalCodeAsync(string postalCode)
    {
        var cacheKey = $"FiberNetResult-{postalCode}";
        // Try get Item from cache
        if (!_cache.TryGetValue(cacheKey, out List<FiberNetResult>? cachedResults))
        {
            // The item is not in the cache, so we get the result from the database.
            cachedResults =  await (from area in _context.Set<NetArea>()
                                   join p in _context.Set<NetAreaFiberPlan>() on area.AreaId equals p.Area.AreaId
                                   join net in _context.Set<FiberNetPlan>() on p.PlanId equals net.PlanId
                                   where area.PostalCode == postalCode
                                   select (new FiberNetResult
                                   {
                                       CountryCode = area.CountryCode,
                                       PostalCode = area.PostalCode,
                                       PlaceName = area.PlaceName,
                                       AdminName = area.AdminName,
                                       AdminCode = area.AdminCode,
                                       AdminCode2 = area.AdminCode2,
                                       AdminCode3 = area.AdminCode3,
                                       Latitude = area.Latitude,
                                       Longitude = area.Longitude,
                                       PlanId = net.PlanId,
                                       ProviderName = net.ProviderName,
                                       PlanName = net.PlanName,
                                       PlanDescription = net.PlanDescription,
                                       PlanPrice = (net.PlanPrice + area.Accuracy),
                                       PlanSpeed = net.PlanSpeed,
                                       IsUnlimited = net.IsUnlimited,
                                       IsDiscounted = net.IsDiscounted,
                                       IsPromoted = net.IsPromoted


                                   }))
                                   .TagWithCallSite()
                                   .ToListAsync();

            // Set the item in the cache with a relative expiration time of 5 minutes.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(cacheKey, cachedResults, cacheEntryOptions);
        }

        return cachedResults ?? new();
    }

}
