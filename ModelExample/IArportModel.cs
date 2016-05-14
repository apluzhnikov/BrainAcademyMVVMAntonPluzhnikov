using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExample
{
    public interface IAirportModel
    {
        IEnumerable<Flight> flights { get; }
        void Remove(IEnumerable<Flight> flights);
    }
}
