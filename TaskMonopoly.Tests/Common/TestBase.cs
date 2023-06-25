using AutoMapper;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Application.Common.Mapping;
using TaskMonopoly.Persistence;

namespace TaskMonopoly.Tests.Common
{
    public abstract class TestBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;
        protected IMapper Mapper;

        protected TestBase()
        {
            Context = ApplicationDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }
}
