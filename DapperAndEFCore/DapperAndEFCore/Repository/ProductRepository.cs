using DapperAndEFCore.Models;
using DapperAndEFCore.Repository.IRepository;
using MySqlConnector;

namespace DapperAndEFCore.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MySqlConnection _connection;
        public ProductRepository(MySqlConnection db) : base(db)
        {
            _connection = db;
        }

        //any Product model specific database methods here

    }
}
