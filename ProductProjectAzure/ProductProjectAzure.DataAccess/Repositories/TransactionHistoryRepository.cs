using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProductProjectAzure.DataAccess.Common.Models;
using ProductProjectAzure.DataAccess.Common.Repositories;
using ProductProjectAzure.DataAccess.Context;
namespace ProductProjectAzure.DataAccess.Repositories
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private ProductProjectContext _context;

        public TransactionHistoryRepository(ProductProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactionsByProductId(int productId)
        {
            var history = await _context.TransactionHistories.ToListAsync();
            return history.Where(x => x.ProductID == productId);
        }
    }
}
