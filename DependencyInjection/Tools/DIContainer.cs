using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Tools
{
    public class DIContainer
    {
        public Dictionary<Type, Service> _services = new();

        public DIProvider DIProvider { get; set; }

        public DIContainer()
        {
            _services = new();
            DIProvider = new DIProvider(_services);
        }

        public DIProvider GetProvider()
        {
            return DIProvider;
        }

        public void RegisterSingleton<T>(T Implementation)
        {
            if (typeof(T).IsInterface) throw new Exception($"You need to provide an implementation type for the interface {typeof(T).Name}. Use RegisterSingleton<TInteface, TImplementation> instead.");

            var success = _services.TryAdd(typeof(T), new Service()
            {
                TypeOfImplementation = typeof(T),
                Implementation = null,
                Life = Life.Singleton
            });

            if (success == false) throw new Exception($"The {typeof(T).Name} is already registered as Singleton");
        }

        public void RegisterSingleton<T>()
        {
            if (typeof(T).IsInterface) throw new Exception($"You need to provide an implementation type for the interface {typeof(T).Name}. Use RegisterSingleton<TInteface, TImplementation> instead.");

            var success = _services.TryAdd(typeof(T), new Service()
            {
                TypeOfImplementation = typeof(T),
                Implementation = null,
                Life = Life.Singleton
            });

            if (success == false) throw new Exception($"The {typeof(T).Name} is already registered as Singleton");
        }

        public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface 
        {
            _services[typeof(TInterface)] = new Service()
            {
                TypeOfInterface = typeof(TInterface),
                TypeOfImplementation = typeof(TImplementation),
                Implementation = null,
                Life = Life.Singleton
            };
        }

        public void RegisterTransient<T>()
        {
            var success = _services.TryAdd(typeof(T), new Service()
            {
                TypeOfImplementation = typeof(T),
                Implementation = null, //at the time of call
                Life = Life.Transient
            });

            if (success == false) throw new Exception($"{typeof(T).Name} is already registered as Transient.");
        }

        public void RegisterTransient<TInterface, TImplementation>()
        {
            if (typeof(TImplementation).GetInterfaces().Contains(typeof(TInterface)) == false)
                throw new Exception($"{typeof(TImplementation).Name} does not implement {typeof(TInterface).Name}");

            _services[typeof(TInterface)] = new Service()
            {
                TypeOfInterface = typeof(TInterface),
                TypeOfImplementation = typeof(TImplementation),
                Implementation = null,
                Life = Life.Transient
            };
        }
    }
}
