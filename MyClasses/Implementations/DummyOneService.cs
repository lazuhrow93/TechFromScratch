using DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Services.Implementations
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
