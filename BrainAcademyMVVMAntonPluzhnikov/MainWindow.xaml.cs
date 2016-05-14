using BrainAcademyMVVMAntonPluzhnikov.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrainAcademyMVVMAntonPluzhnikov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SynchronizationContext _syncContext = SynchronizationContext.Current;

        bool _populatingInProgress = false;

        public static RoutedCommand PopulateCommand = new RoutedCommand();

        public MainWindow() {
            InitializeComponent();
        }


        /*private void PopulateButtonClick(object sender, RoutedEventArgs e) {
            var resource = FindResource(nameof(AirportViewModel)) as AirportViewModel;
            if (resource != null)
            {
                resource.PopulateFlightsAsync(_syncContext);
            }

        }*/

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            _populatingInProgress = true;
            var resource = FindResource(nameof(AirportViewModel)) as AirportViewModel;
            if (resource != null)
            {
                resource.PopulateFlightsAsync(_syncContext)
                    .ContinueWith(t => _populatingInProgress = false);
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !_populatingInProgress;
        }
    }
}
