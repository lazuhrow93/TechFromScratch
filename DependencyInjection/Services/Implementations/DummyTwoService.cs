using DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Services.Implementations
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
