namespace DependencyInjection.Tools
{
    public class DIProvider
    {
        private Dictionary<Type, Service> _services;

        public DIProvider()
        {
            _services = new();
        }

        public void RegisterSingleton<T>(T Implementation)
        {
            if (Implementation is null) throw new Exception($"The {typeof(T).Name} is not implemented");

            var success = _services.TryAdd(typeof(T), new Service()
            {
                Type = typeof(T),
                Implementation = Implementation,
                Life = Life.Singleton
            });

            if(success == false) throw new Exception($"The {typeof(T).Name} is already registered as Singleton");
        }

        public void RegisterSingleton<T>()
        {
            //tech dont have to init, we could init when its first called for improved performance
            var implementation = Activator.CreateInstance<T>(); 
            if (implementation == null) throw new Exception($"{typeof(T).Name} needs a constructor");

            var success = _services.TryAdd(typeof(T), new Service()
            {
                Type = typeof(T),
                Implementation = implementation,
                Life = Life.Singleton
            });

            if (success == false) throw new Exception($"The {typeof(T).Name} is already registered as Singleton");
        }

        public void RegisterTransient<T>()
        {
            var success = _services.TryAdd(typeof(T), new Service()
            {
                Type = typeof(T),
                Implementation = null, //at the time of call
                Life = Life.Transient
            });

            if (success == false) throw new Exception($"{typeof(T).Name} is already registered as Transient.");
        }

        public T? GetService<T>()
        {
            var service = _services[typeof(T)];
            switch (service.Life)
            {
                case Life.Transient:
                    return Activator.CreateInstance<T>();
                case Life.Singleton:
                    return (T)service.Implementation;
                default:
                    throw new Exception($"IDK, something happened");
            }
        }

        public void RegisterSingleton<TInterface, TImplementation>()
        {
            if(typeof(TImplementation).GetInterfaces().Contains(typeof(TInterface)) == false)
                throw new Exception($"{typeof(TImplementation).Name} does not implement {typeof(TInterface).Name}");
        }
    }
}