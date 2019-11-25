using Microsoft.EntityFrameworkCore;

namespace MyApiCore.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
