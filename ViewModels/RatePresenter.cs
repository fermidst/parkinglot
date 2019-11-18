using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ParkingLot.Context;
using ParkingLot.Models;
using ParkingLot.ViewModels.MVVM;

namespace ParkingLot.ViewModels
{
    public class RatePresenter : Presenter
    {
        public ObservableCollection<Rate> Rates { get; set; }
        public ICommand ShowRatesCommand { get; } = new Command(_ =>
        {
            using var db = new AppDbContext();
            var rates = db.Rates.ToList();

        });
    }
}
