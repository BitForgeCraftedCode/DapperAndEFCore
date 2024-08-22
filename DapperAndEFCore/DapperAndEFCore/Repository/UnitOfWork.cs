using DapperAndEFCore.Repository.IRepository;
using MySqlConnector;
//https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/
namespace DapperAndEFCore.Repository
{
    //goal is to use UnitOfWork to share the _connection
    //this passes down one connection throught the entire inheritance chain
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlConnection _connection;

        public IProductRepository Product { get; private set; }
        //other repositories here

        public UnitOfWork(MySqlConnection db)
        {
            _connection = db;
            Product = new ProductRepository(_connection);
            //other repositories here
        }
    }
}
