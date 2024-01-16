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
            
            var serviceInfo = _services[typeof(T)];
            var isInterface = typeof(T).IsInterface;
            var typeOfImplementation = (isInterface) ? serviceInfo.TypeOfImplementation : typeof(T);

            switch (serviceInfo.Life)
            {
                case Life.Transient:
                    return (T)Activator.CreateInstance(typeOfImplementation);
                case Life.Singleton:
                    return (T)serviceInfo.Implementation;
                default:
                    throw new Exception($"IDK, something happened");
            }
        }
    }
}