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

        public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();

        public ObservableCollection<Rate> Rates { get; } = new ObservableCollection<Rate>();
        
        public ObservableCollection<Owner> Owners { get; } = new ObservableCollection<Owner>();
        
        public ObservableCollection<Car> Cars { get; } = new ObservableCollection<Car>();

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

        public ICommand ShowLocationsCommand => new Command(_ =>
        {
            var locations = _context.Locations.ToList();
            Locations.Clear();
            foreach (var location in locations)
            {
                Locations.Add(location);
            }
        });

        public ICommand AddRateCommand => new Command(_ =>
        {
            var type = "test";
            var cost = 10101;
            _context.Rates.Add(new Rate(type, cost));
            _context.SaveChanges();
        });

        public ICommand ShowRatesCommand => new Command(_ =>
        {
            var rates = _context.Rates.ToList();
            Rates.Clear();
            foreach (var rate in rates)
            {
                Rates.Add(rate);
            }
        });

        public ICommand AddOwnerCommand => new Command(_ =>
        {
            var name = "testName";
            var phone = "testPhone";
            _context.Owners.Add(new Owner(name, phone));
            _context.SaveChanges();
        });

        public ICommand ShowOwnersCommand => new Command(_ =>
        {
            var owners = _context.Owners.ToList();
            Owners.Clear();
            foreach (var owner in owners)
            {
                Owners.Add(owner);
            }
        });

        public ICommand AddCarCommand => new Command(_ =>
        {
            var registrationNumber = "testNumber";
            var ownerId = 1;
            var vehicleBrand = "testBrand";
            var color = "testColor";
            _context.Cars.Add(new Car(registrationNumber, ownerId, vehicleBrand, color));
        });

        public ICommand ShowCarsCommand => new Command(_ =>
        {
            var cars = _context.Cars.ToList();
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        });

    }
}
