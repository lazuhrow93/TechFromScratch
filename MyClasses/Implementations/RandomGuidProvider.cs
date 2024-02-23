using MyClasses.Interfaces;

namespace MyClasses.Implementations
{
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}