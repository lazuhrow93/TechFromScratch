using System.Data.Common;

namespace DependencyInjection.Services
{
    public class FooService
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();

        public FooService()
        {
            
        }
    }
}