using HuizeHop.Api.Library.Database.BaseClasses;
using HuizeHop.Api.Library.Database.Entities;

namespace HuizeHop.Api.Library.Database.Repositories;

/// <summary>
/// Repository for the <see cref="Account"/> entity
/// </summary>
/// <param name="dbContext">The database context</param>
public class AccountRepository(HuizeHopDbContext dbContext) : BaseRepository<Account>(dbContext)
{
    
}