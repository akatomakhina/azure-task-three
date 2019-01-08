
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductProjectAzure.Logic.Common.Models;

namespace ProductProjectAzure.Logic.Common.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task RemoveProductAsync(int productId);
    }
}
