using AutoMapper;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;

namespace Application.Test.Common;

public abstract class InMemoryDbContextFixture : IDisposable
{
    public readonly SqlServerContext GetDatabase;
    public readonly IMapper GetMapper;

    protected InMemoryDbContextFixture()
    {
        var dbContextOptions = new DbContextOptionsBuilder<SqlServerContext>()
            .UseInMemoryDatabase(databaseName: "InMemory")
            .Options;
        GetMapper = A.Fake<IMapper>();
        GetDatabase = new SqlServerContext(dbContextOptions);
    }


    public void Dispose()
    {
        GetDatabase.Dispose();
    }
    
   
}
