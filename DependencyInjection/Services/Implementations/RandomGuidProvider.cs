using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services.Implementations
{
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}