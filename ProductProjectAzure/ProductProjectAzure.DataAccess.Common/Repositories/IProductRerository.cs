using System.Collections.Generic;
using System.Threading.Tasks;
using ProductProjectAzure.DataAccess.Common.Models;

namespace ProductProjectAzure.DataAccess.Common.Repositories
{
    public interface IProductRerository
    {
        Task<DbProduct> AddProductAsync(DbProduct product);

        Task<DbProduct> DeleteProductAsync(DbProduct product);

        Task<DbProduct> UpdateProductAsync(DbProduct product);

        Task<DbProduct> GetProductByIdAsync(int id);

        Task<IEnumerable<DbProduct>> GetAllProductsAsync();
    }
}
