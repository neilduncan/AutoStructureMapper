Basically, what this does is hook up AutoMapper and configure it so that it plays nicely with StructureMap.

Here's how to use it.

1. Add the registry to configure StructureMap 

        ObjectFactory.Initialize(x => { 
                //All your normal StructureMap config crap goes here.
                x.AddRegistry(new AutoStructureMapper.ConfigurationRegistry())
            });

2. Create some profiles... These are how you tell AutoMapper how to map from one object to another. 
These are automagically picked up and configured for you. All you need to do is have them in your project somewhere!

        public class FooBarProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<Foo, Bar>();
            }
        }

3. To use it, do something like this:

        var engine = ObjectFactory.GetInstance<IMappingEngine>(); //Or just add IMappingEngine as a dependency as you would normally
        var foo = new Foo { Title = "something" };
        var bar = engine.Map<Foo, Bar>(foo);
