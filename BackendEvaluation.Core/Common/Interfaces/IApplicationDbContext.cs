using BackendEvaluation.Domain.Models.Item;
using Microsoft.EntityFrameworkCore;
namespace BackendEvaluation.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TModel> Set<TModel>() where TModel : class;

        public DbSet<Product> Products { get; set; }
    }
}
