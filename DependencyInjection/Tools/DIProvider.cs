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
            var serviceInfo = new Service();
            _services.TryGetValue(type, out serviceInfo);
            if (serviceInfo is null) throw new Exception($"You haven't registered {type.Name}");

            var isInterface = type.IsInterface;
            var typeOfImplementation = (isInterface) ? serviceInfo.TypeOfImplementation : type;

            if(serviceInfo.Life == Life.Transient)
            {
                var basicCtor = serviceInfo.TypeOfImplementation.GetConstructors().First(); //how do we determine which one we want? First one for now

                var paramTypes = basicCtor.GetParameters();
                var paramInstances = paramTypes.Select(p => GetServiceInstance(p.GetType())); //eventually youll hit a ctor without params
                
                return Activator.CreateInstance(typeOfImplementation, paramInstances);

            }
            else //singleton
            {
                if (serviceInfo.Implementation is null) //singleton hasnt been implemented
                {
                    var basicCtor = serviceInfo.TypeOfImplementation.GetConstructors().First(); //how do we determine which one we want? First one for now

                    var paramTypes = basicCtor.GetParameters();
                    var paramInstances = paramTypes.Select(p => GetServiceInstance(p.ParameterType)).ToArray(); //eventually youll hit a ctor without params
                    _services[type].Implementation = Activator.CreateInstance(typeOfImplementation, paramInstances);
                    serviceInfo = _services[type];
                }
                return serviceInfo.Implementation;

            }
        }
    }
}