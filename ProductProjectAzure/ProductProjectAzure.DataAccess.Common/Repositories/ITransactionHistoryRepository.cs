using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductProjectAzure.DataAccess.Common.Models;

namespace ProductProjectAzure.DataAccess.Common.Repositories
{
    public interface ITransactionHistoryRepository
    {
        Task<IEnumerable<TransactionHistory>> GetTransactionsByProductId(int productId);
    }
}
