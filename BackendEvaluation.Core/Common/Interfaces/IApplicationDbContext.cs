using BackendEvaluation.Domain.Models.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace BackendEvaluation.Core.Common.Interfaces;
public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    DbSet<TModel> Set<TModel>() where TModel : class;
    public DbSet<Item> Items { get; set; }
}

