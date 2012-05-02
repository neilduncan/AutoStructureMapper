using System.Collections.Generic;
using AutoMapper;
using StructureMap;

namespace AutoStructureMapper
{
    internal class ProfileConfigurationStore : ConfigurationStore
    {
        public ProfileConfigurationStore(ITypeMapFactory typeMapFactory, IEnumerable<IObjectMapper> mappers)
            : base(typeMapFactory, mappers)
        {
            foreach (var profile in ObjectFactory.GetAllInstances<Profile>())
                AddProfile(profile);
        }
    }
}