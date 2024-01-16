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
        private Guid Guid { get; set; } = Guid.NewGuid();
        private Guid Guid2 { get; set; } = Guid.NewGuid();

        public void PrintStoredNumber()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void TotalRefreshes()
        {
            throw new NotImplementedException();
        }
    }
}
