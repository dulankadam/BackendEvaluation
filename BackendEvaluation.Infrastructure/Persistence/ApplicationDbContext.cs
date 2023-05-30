using Audit.EntityFramework;
using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Domain.Models.Base;
using BackendEvaluation.Domain.Models.Item;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace BackendEvaluation.Infrastructure.Persistence;
public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private static readonly DbContextHelper _helper = new DbContextHelper();
    private readonly IAuditDbContext _auditContext;

    public ApplicationDbContext(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _auditContext = new DefaultAuditContext(this);
        _helper.SetConfig(_auditContext);
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
        : base(options)
    {
        _currentUserService = currentUserService;
        _auditContext = new DefaultAuditContext(this);
        _helper.SetConfig(_auditContext);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        string user = GetUser();

        foreach (var entry in ChangeTracker.Entries<ModelBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    if (String.IsNullOrWhiteSpace(entry.Entity.CreatedUser))
                    {
                        entry.Entity.CreatedUser = user;
                    }
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = DateTime.Now;
                    if (String.IsNullOrWhiteSpace(entry.Entity.UpdatedUser))
                    {
                        entry.Entity.UpdatedUser = user;
                    }
                    break;
            }
        }

        return await _helper.SaveChangesAsync(_auditContext, () => base.SaveChangesAsync(cancellationToken));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Item> Items { get; set; }



    private string GetUser()
    {
        string user;
        if (string.IsNullOrEmpty(_currentUserService.IdentifierNumber) || string.IsNullOrEmpty(_currentUserService.UserName))
        {
            user = "Annonymous User";
        }
        else
        {
            user = _currentUserService.IdentifierNumber;
        }

        return user;
    }

    public virtual IQueryable<TEntity> RunSql<TEntity>(string sql, params object[] parameters) where TEntity : class
    {
        return this.Set<TEntity>().FromSqlRaw(sql, parameters);
    }


}
