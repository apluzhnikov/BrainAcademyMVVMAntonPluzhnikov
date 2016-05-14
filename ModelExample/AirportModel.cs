using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelExample
{
    public class AirportModel : IAirportModel
    {

        public static IAirportModel Create() => new AirportModel();

        List<Flight> _flights;

        public IEnumerable<Flight> flights { get { Thread.Sleep(2000); return _flights; } }

        private AirportModel() {
            _flights = new List<Flight>
            {
                new Flight {ID=1, City="London", Number="1111", Type=true },
                new Flight {ID=2, City="Kiev", Number="2222", Type=false },
                new Flight {ID=3, City="Berlin", Number="3333", Type=true },
                new Flight {ID=4, City="New York", Number="4444", Type=false }
            };
        }

        public void Remove(IEnumerable<Flight> flights) {
            _flights = _flights.Where(arg => !flights.Contains(arg)).ToList();
        }

        public void Remove(Flight flight) {
            _flights = _flights.Where(arg=>arg.ID != flight.ID).ToList();
        }
    }

}
