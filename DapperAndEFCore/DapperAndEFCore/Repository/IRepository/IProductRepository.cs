using DapperAndEFCore.Models;

namespace DapperAndEFCore.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        //any Product model specific database methods here
    }
}
