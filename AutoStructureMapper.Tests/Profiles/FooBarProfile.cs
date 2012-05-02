using AutoMapper;

namespace AutoStructureMapper.Tests.Profiles
{
    public class FooBarProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Foo, Bar>();
        }
    }
}