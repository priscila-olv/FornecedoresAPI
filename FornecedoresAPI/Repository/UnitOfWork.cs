using FornecedoresAPI.Context;

namespace FornecedoresAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private FornecedorRepository _fornecedorRepository;
        public FornecedoresAPIContext _context;

        public UnitOfWork(FornecedoresAPIContext context)
        {
            _context = context;
        }

        public IFornecedorRepository FornecedorRepository
        {
            get
            {
                return _fornecedorRepository = _fornecedorRepository ??
                    new FornecedorRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Disponse()
        {
            _context.Dispose();
        }
    }
}
