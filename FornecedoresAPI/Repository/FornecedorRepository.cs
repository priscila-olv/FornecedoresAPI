using FornecedoresAPI.Context;
using FornecedoresAPI.Models;
using FornecedoresAPI.Pagination;

namespace FornecedoresAPI.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(FornecedoresAPIContext context) : base(context)
        {
        }

        public async Task <PagedList<Fornecedor>> GetFornecedores(FornecedoresParameters fornecedorParameters)
        {
            return await PagedList<Fornecedor>.ToPagedList(Get().OrderBy(on => on.Nome),
                                                fornecedorParameters.PageNumber,
                                                fornecedorParameters.PageSize);
        }
    }
}