namespace DependencyInjection.Tools
{
    public class DIProvider
    {
        private Dictionary<Type, Service> _services;

        public DIProvider()
        {
            _services = new();
        }

        public DIProvider(Dictionary<Type, Service> services)
        {
            _services = services;
        }

        public T? GetService<T>()
        {
            return (T)GetServiceInstance(typeof(T));

        }

        private object? GetServiceInstance(Type type)
        {
            _services.TryGetValue(type, out var serviceInfo);
            if (serviceInfo is null) throw new Exception($"You haven't registered {type.Name}");

            var isInterface = type.IsInterface;
            var typeOfImplementation = (isInterface) ? serviceInfo.TypeOfImplementation : type;

            var isSingleton = (serviceInfo.Life == Life.Singleton);
            if (isSingleton && serviceInfo.Implementation is not null)
                return serviceInfo.Implementation;

            var basicCtor = serviceInfo.TypeOfImplementation.GetConstructors().First(); //how do we determine which one we want? First one for now
            var paramTypes = basicCtor.GetParameters();
            var paramInstances = paramTypes.Select(p => GetServiceInstance(p.ParameterType)); //eventually youll hit a ctor without params

            var instance = Activator.CreateInstance(typeOfImplementation, paramInstances);
            if(isSingleton) serviceInfo.Implementation = instance;

            return instance;
        }
    }
}