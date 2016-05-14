using ModelExample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrainAcademyMVVMAntonPluzhnikov.ViewModels
{
    public class AirportViewModel : INotifyPropertyChanged
    {
        IAirportModel _airportModel;

        //public int MyProperty {
        //    get {return (int)GetValue() }
        //    set { }
        //}


        ObservableCollection<Flight> _flights = new ObservableCollection<Flight>();
        private int _flightNumbers;

        public ObservableCollection<Flight> Flights => _flights;

        public int FlightNumbers {
            get {
                return _flightNumbers;
            }
            set {
                _flightNumbers = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(FlightNumbers)));

            }
        }

        public AirportViewModel() {
            _airportModel = AirportModel.Create();
        }

        public Task PopulateFlightsAsync(SynchronizationContext syncContext) {
            return Task.Run(() => _airportModel.flights.ToList())
                .ContinueWith(task =>
                {
                    syncContext.Post(state =>
                    {
                        _flights.Clear();
                        task.Result.ForEach(_flights.Add);
                        FlightNumbers = _flights.Count;
                    }, null
                );
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e) {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
}
