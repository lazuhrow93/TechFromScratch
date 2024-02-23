using MyClasses.Interfaces;

namespace MyClasses.Implementations
{
    public class DummyOneService : IDummyService
    {
        public int Randomized { get; set; } = 0;
        private Guid Guid { get; set; } = Guid.NewGuid();

        public DummyOneService() { }

        public void PrintStoredNumber()
        {
            Console.WriteLine(Guid);
        }

        public void TotalRefreshes()
        {
            Console.WriteLine($"Random : {Randomized}");
        }

        public void Refresh()
        {
            Guid = Guid.NewGuid();
            ++Randomized;
        }
    }
}
