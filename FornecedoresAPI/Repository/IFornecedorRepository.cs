using FornecedoresAPI.Models;
using FornecedoresAPI.Pagination;

namespace FornecedoresAPI.Repository
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task <PagedList<Fornecedor>> GetFornecedores(FornecedoresParameters fornecedorParameters);
    }
}