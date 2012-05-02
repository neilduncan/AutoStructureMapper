using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using StructureMap.Configuration.DSL;

namespace AutoStructureMapper
{
    public class ConfigurationRegistry : Registry
    {
        public ConfigurationRegistry()
        {
            For<ConfigurationStore>().Singleton().Use<ProfileConfigurationStore>()
            .Ctor<IEnumerable<IObjectMapper>>().Is(MapperRegistry.AllMappers());

            For<IConfigurationProvider>()
                .Use(ctx => ctx.GetInstance<ConfigurationStore>());

            For<IConfiguration>()
                .Use(ctx => ctx.GetInstance<ConfigurationStore>());

            For<ITypeMapFactory>()
                .Use<TypeMapFactory>();

            For<IMappingEngine>()
                .Use<MappingEngine>();

            Scan(scanner =>
                     {
                         scanner.AssembliesFromApplicationBaseDirectory();
                         scanner.AddAllTypesOf<Profile>();
                     });
        }
    }
}
