using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Services.Interfaces
{
    public interface IDummyService
    {
        public void PrintStoredNumber();
        public void Refresh();
        public void TotalRefreshes();
    }
}
