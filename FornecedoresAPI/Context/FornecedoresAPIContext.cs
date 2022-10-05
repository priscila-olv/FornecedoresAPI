using FornecedoresAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FornecedoresAPI.Context
{
    public class FornecedoresAPIContext : IdentityDbContext
    {
        public FornecedoresAPIContext(DbContextOptions<FornecedoresAPIContext> options) 
            : base(options)
        {
        }
        public FornecedoresAPIContext()
        {
        }
        public DbSet<Fornecedor>? Fornecedores { get; set; }
    }
}
