using AutoMapper;
using AutoStructureMapper.Tests.Profiles;
using NUnit.Framework;
using StructureMap;

namespace AutoStructureMapper.Tests
{
    [TestFixture]
    public class RegistryTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new ConfigurationRegistry()));
        }

        [Test]
        public void StructureMap_Contains_MappingEngine()
        {
            var engine = ObjectFactory.GetInstance<IMappingEngine>();

            Assert.IsNotNull(engine);
        }

        [Test]
        public void StructureMap_Contains_FooBarProfile()
        {
            var profiles = ObjectFactory.GetAllInstances<Profile>();

            Assert.AreEqual(1, profiles.Count);
            Assert.IsInstanceOf<FooBarProfile>(profiles[0]);
        }

        [Test]
        public void MappingEngine_Is_Configured()
        {
            var engine = ObjectFactory.GetInstance<IMappingEngine>();

            var foo = new Foo { Title = "something" };
            var bar = engine.Map<Foo, Bar>(foo);

            StringAssert.AreEqualIgnoringCase(foo.Title, bar.Title);
        }
    }
}
