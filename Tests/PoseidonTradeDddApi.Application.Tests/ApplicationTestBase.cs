using AutoMapper;
using PoseidonTradeDddApi.Application.Common.Mappings;
using PoseidonTradeDddApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Tests
{
    public class ApplicationTestBase
    {
        protected readonly ApplicationDbContext dbContext;
        protected readonly IMapper mapper;

        public ApplicationTestBase()
        {
            dbContext = ApplicationDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }
    }
}
