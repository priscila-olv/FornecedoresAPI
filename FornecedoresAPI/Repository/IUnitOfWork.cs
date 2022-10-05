namespace FornecedoresAPI.Repository
{
    public interface IUnitOfWork
    {
        IFornecedorRepository FornecedorRepository { get; }
        Task Commit();
    }
}
