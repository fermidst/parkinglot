using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ParkingLot.Context;
using ParkingLot.Models;
using ParkingLot.ViewModels.MVVM;

namespace ParkingLot.ViewModels
{
    public class AdminPanelPresenter : Presenter
    {
        private readonly AppDbContext _context = new AppDbContext();
        private string _inputField = string.Empty;

        public ObservableCollection<Ticket> Tickets { get; } = new ObservableCollection<Ticket>();

        public string InputField
        {
            get => _inputField;
            set => Update(ref _inputField, value);
        }

        public ICommand ShowTicketsCommand => new Command(_ =>
        {
            var tickets = _context.Tickets.ToList();
            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        });

        public ICommand AddLocationCommand => new Command(_ =>
        {
            _context.Locations.Add(new Location());
            _context.SaveChanges();
        });

        public ICommand AddRateCommand => new Command(_ =>
        {
            var type = "test";
            var cost = 10101;
            _context.Rates.Add(new Rate(type, cost));
            _context.SaveChanges();
        });

        public ICommand AddOwnerCommand => new Command(_ =>
        {
            var name = "testName";
            var phone = "testPhone";
            _context.Owners.Add(new Owner(name, phone));
            _context.SaveChanges();
        });

        public ICommand AddCarCommand => new Command(_ =>
        {
            var registrationNumber = "testNumber";
            var ownerId = 1;
            var vehicleBrand = "testBrand";
            var color = "testColor";
            _context.Cars.Add(new Car(registrationNumber, ownerId, vehicleBrand, color));
        });

    }
}
