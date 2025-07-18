using HuizeHop.Api.Library.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HuizeHop.Api.Library.Database;

public static class ModelBuilderExtensions
{
    public static void ConfigureBaseEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>();
    }
}