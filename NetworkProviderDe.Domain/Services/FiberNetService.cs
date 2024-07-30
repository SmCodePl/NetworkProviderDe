using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;  
using NetworkProviderDe.Domain.Entities;
using NetworkProviderDe.Domain.Models;
using System.Text.RegularExpressions;

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
    public async Task<List<ProductResult>> GetAllProductsAsync()
    {
        var cacheKey = $"Product";
        
        // Try get Item from cache. otherwise get from database
        if(!_cache.TryGetValue(cacheKey, out List<ProductResult>? cachedProd))
        {
            // The item is not in the cache, so we get the result from the database.
            cachedProd = await _context.Set<Product>()
                .Include(s=>s.ProductType)
                .Select(x=> new ProductResult
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductType = new(x.ProductType.ProductTypeId,x.ProductType.ProductTypeName ?? ""),
                    ProductDescription = x.ProductDescription,
                    TdcOtc = x.TdcOtc,
                    ProductPrice = x.ProductPrice,
                    Speed = x.Speed,
                    Mrc = x.Mrc,
                    IsUnlimited = x.IsUnlimited,
                    IsDiscounted = x.IsDiscounted,
                    IsPromoted = x.IsPromoted,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToListAsync();
            
            // Set the item in the cache with a relative expiration time of 5 minutes.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(cacheKey, cachedProd, cacheEntryOptions);
        }
        return cachedProd ?? new(); 
    }
    /// <summary>
    /// Get ProductBy name Async
    /// </summary>
    /// <param name="name"></param>
    /// <returns>
    /// List<Product>
    /// </returns>
    public async Task<List<Product>>GetProductByNameAsync(string name)
    {
        return await _context.Set<Product>().Where(f => f.ProductName.Contains(name)).ToListAsync();
    }

    // Add New Product
    public async Task<Product> AddProductAsync(ProductResult product)
    {
        var prodType = _context.Set<ProductType>().Where(f => f.ProductTypeId == product.ProductType.ProductTypeId).FirstOrDefault();

        if (prodType == null)
            return new Product();

        var prod = new Product
        {
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            ProductPrice = product.ProductPrice,
            TdcOtc = product.TdcOtc,
            Mrc = product.Mrc,
            Speed = product.Speed,
            IsUnlimited = product.IsUnlimited,
            IsDiscounted = product.IsDiscounted,
            IsPromoted = product.IsPromoted,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            ProductType = prodType
        };
        await _context.Set<Product>().AddAsync(prod);
        await _context.SaveChangesAsync();
        return prod;
    }

    // Update Product
    public async Task<bool> UpdateProductAsync(ProductResult product)
    {
        var prod = await _context.Set<Product>()
            .Include(s=>s.ProductType)
            .Where(x=> x.ProductId == product.ProductId).FirstOrDefaultAsync();

        if (prod == null)
            return false;

        prod.ProductName = product.ProductName;
        prod.ProductDescription = product.ProductDescription;
        prod.ProductPrice = product.ProductPrice;
        prod.TdcOtc = product.TdcOtc;
        prod.Mrc = product.Mrc;
        prod.Speed = product.Speed;
        prod.IsUnlimited = product.IsUnlimited;
        prod.IsDiscounted = product.IsDiscounted;
        prod.IsPromoted = product.IsPromoted;
        prod.UpdatedAt = DateTime.Now;
        
        _context.Update(prod);
        
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<FiberNetResult>> FindByPostalCodeAsync(string postalCode)
    {
        var cacheKey = $"FiberNetResult-{postalCode}";
       
        // Try get Item from cache
        if (!_cache.TryGetValue(cacheKey, out List<FiberNetResult>? cachedResults))
        {

            cachedResults = await (from area in _context.Set<NetArea>()
                                   
                                   where area.PostalCode == postalCode
                                   select (new FiberNetResult
                                   {
                                       AreaId = area.AreaId,
                                       CountryCode = area.CountryCode,
                                       PostalCode = area.PostalCode,
                                       PlaceName = area.PlaceName,
                                       AdminName = area.AdminName,
                                       AdminCode = area.AdminCode,
                                       AdminCode2 = area.AdminCode2,
                                       AdminCode3 = area.AdminCode3,
                                       Latitude = area.Latitude,
                                       Longitude = area.Longitude,
                                       ProductResult = (
                                            _context.Set<ProductArea>()
                                                  .Include(s => s.Product)
                                                                .ThenInclude(s => s.ProductType)
                                                                .Where(f => f.Area.AreaId == area.AreaId)
                                                                .Select(x => new ProductResult
                                                                {
                                                                    ProductId = x.Product.ProductId,
                                                                    ProductName = x.Product.ProductName,
                                                                    ProductType = new(x.Product.ProductType.ProductTypeId, x.Product.ProductType.ProductTypeName ?? ""),
                                                                    ProductDescription = x.Product.ProductDescription,
                                                                    TdcOtc = x.Product.TdcOtc,
                                                                    ProductPrice = x.Product.ProductPrice,
                                                                    Speed = x.Product.Speed,
                                                                    Mrc = x.Product.Mrc,
                                                                    IsUnlimited = x.Product.IsUnlimited,
                                                                    IsDiscounted = x.Product.IsDiscounted,
                                                                    IsPromoted = x.Product.IsPromoted,
                                                                    CreatedAt = x.Product.CreatedAt,
                                                                    UpdatedAt = x.Product.UpdatedAt
                                                                }
                                                     ).ToList<ProductResult>())

                                   }))
                               .TagWithCallSite()
                               .ToListAsync();
            //cachedResults = await (from area in _context.Set<NetArea>()
            //                       join p in _context.Set<ProductArea>() on area.AreaId equals p.Area.AreaId
            //                       join net in _context.Set<Product>() on p.Product.ProductId equals net.ProductId
            //                       join t in _context.Set<ProductType>() on net.ProductType.ProductTypeId equals t.ProductTypeId
            //                       where area.PostalCode == postalCode
            //                       select (new FiberNetResult
            //                       {
            //                           AreaId = area.AreaId,
            //                           CountryCode = area.CountryCode,
            //                           PostalCode = area.PostalCode,
            //                           PlaceName = area.PlaceName,
            //                           AdminName = area.AdminName,
            //                           AdminCode = area.AdminCode,
            //                           AdminCode2 = area.AdminCode2,
            //                           AdminCode3 = area.AdminCode3,
            //                           Latitude = area.Latitude,
            //                           Longitude = area.Longitude,
            //                           ProductResult = new ProductResult
            //                           {
            //                               ProductId = net.ProductId,
            //                               ProductName = net.ProductName,
            //                               ProductType = new(t.ProductTypeId, t.ProductTypeName ?? ""),
            //                               ProductDescription = net.ProductDescription,
            //                               TdcOtc = net.TdcOtc,
            //                               ProductPrice = net.ProductPrice,
            //                               Speed = net.Speed,
            //                               Mrc = net.Mrc,
            //                               IsUnlimited = net.IsUnlimited,
            //                               IsDiscounted = net.IsDiscounted,
            //                               IsPromoted = net.IsPromoted,
            //                               CreatedAt = net.CreatedAt,
            //                               UpdatedAt = net.UpdatedAt
            //                           }

            //                       }))
            //           .TagWithCallSite()
            //           .ToListAsync();

            // Set the item in the cache with a relative expiration time of 5 minutes.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(cacheKey, cachedResults, cacheEntryOptions);
        }

        return cachedResults ?? new();
    }

    private List<ProductResult> GetProductResultForArea(long areaId)
    {
           var result = _context.Set<ProductArea>()
            .Include(s => s.Product)
            .ThenInclude(s => s.ProductType)
            .Where(f => f.Area.AreaId == areaId)
            .Select(x => new ProductResult
            {
                ProductId = x.Product.ProductId,
                ProductName = x.Product.ProductName,
                ProductType = new(x.Product.ProductType.ProductTypeId, x.Product.ProductType.ProductTypeName ?? ""),
                ProductDescription = x.Product.ProductDescription,
                TdcOtc = x.Product.TdcOtc,
                ProductPrice = x.Product.ProductPrice,
                Speed = x.Product.Speed,
                Mrc = x.Product.Mrc,
                IsUnlimited = x.Product.IsUnlimited,
                IsDiscounted = x.Product.IsDiscounted,
                IsPromoted = x.Product.IsPromoted,
                CreatedAt = x.Product.CreatedAt,
                UpdatedAt = x.Product.UpdatedAt
            }).ToList<ProductResult>();

        return result;
    }

}
