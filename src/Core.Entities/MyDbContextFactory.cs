using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=EfCoreUnitTest_Test;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new MyDbContext(builder.Options);
        }
    }
}
