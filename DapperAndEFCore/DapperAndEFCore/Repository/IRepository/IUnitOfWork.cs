namespace DapperAndEFCore.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Product {  get; }
        //other repositories here
    }
}
