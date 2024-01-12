using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public class GooService
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}
