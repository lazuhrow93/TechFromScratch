using MyClasses.Interfaces;

namespace MyClasses.Implementations
{
    public class DummyTwoService : IDummyService
    {
        private readonly IRandomGuidProvider _guidProvider;
        private int Refreshes { get; set; } = 0;
        
        public DummyTwoService(IRandomGuidProvider guidprovider)
        {
            _guidProvider = guidprovider;        
        }

        public void PrintStoredNumber()
        {
            Console.WriteLine(_guidProvider.RandomGuid);
        }

        public void Refresh()
        {
            _guidProvider.RandomGuid = Guid.NewGuid();
            ++Refreshes;

        }

        public void TotalRefreshes()
        {
            Console.WriteLine($"Refreshes: {Refreshes}");
        }
    }
}
