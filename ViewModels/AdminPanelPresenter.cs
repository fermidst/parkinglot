using ParkingLot.Context;
using ParkingLot.Models;
using ParkingLot.ViewModels.MVVM;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ParkingLot.ViewModels
{
    public class AdminPanelPresenter : Presenter
    {
        private readonly AppDbContext _context = new AppDbContext();
        private string _rateType = string.Empty;
        private decimal _rateCost;
        private string _ownerName = null!;
        private string _ownerPhone = null!;
        private string _carRegistrationNumber = null!;
        private long _carOwnerId;
        private string _carVehicleBrand = null!;
        private string _carColor = null!;

        public ObservableCollection<Ticket> Tickets { get; } = new ObservableCollection<Ticket>();

        public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();

        public ObservableCollection<Rate> Rates { get; } = new ObservableCollection<Rate>();
        
        public ObservableCollection<Owner> Owners { get; } = new ObservableCollection<Owner>();
        
        public ObservableCollection<Car> Cars { get; } = new ObservableCollection<Car>();

        public string RateType
        {
            get => _rateType;
            set => Update(ref _rateType, value);
        }

        public decimal RateCost
        {
            get => _rateCost;
            set => Update(ref _rateCost, value);
        }

        public string OwnerName
        {
            get => _ownerName;
            set => Update(ref _ownerName, value);
        }

        public string OwnerPhone
        {
            get => _ownerPhone;
            set => Update(ref _ownerPhone, value);
        }

        public string CarRegistrationNumber
        {
            get => _carRegistrationNumber;
            set => Update(ref _carRegistrationNumber, value);
        }

        public long CarOwnerId
        {
            get => _carOwnerId;
            set => Update(ref _carOwnerId, value);
        }

        public string CarVehicleBrand
        {
            get => _carVehicleBrand;
            set => Update(ref _carVehicleBrand, value);
        }

        public string CarColor
        {
            get => _carColor;
            set => Update(ref _carColor, value);
        }

        public ICommand AddLocationCommand => new Command(_ =>
        {
            _context.Locations.Add(new Location());
            _context.SaveChanges();
            ShowLocationsCommand.Execute(_);
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
            _context.Rates.Add(new Rate(RateType, RateCost));
            _context.SaveChanges();
            ShowRatesCommand.Execute(_);
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
            ExecuteIgnoringExceptions(() =>
            {
                _context.Owners.Add(new Owner(OwnerName, OwnerPhone));
                _context.SaveChanges();
            });
            ShowOwnersCommand.Execute(_);
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
            ExecuteIgnoringExceptions(() =>
            {
                _context.Cars.Add(new Car(CarRegistrationNumber, CarOwnerId, CarVehicleBrand, CarColor));
                _context.SaveChanges();
            });
            ShowCarsCommand.Execute(_);
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

        public ICommand ShowTicketsCommand => new Command(_ =>
        {
            var tickets = _context.Tickets.ToList();
            Tickets.Clear();
            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        });

        public ICommand ShowAllCommand => new Command(_ =>
        {
            ShowLocationsCommand.Execute(_);
            ShowRatesCommand.Execute(_);
            ShowOwnersCommand.Execute(_);
            ShowCarsCommand.Execute(_);
            ShowTicketsCommand.Execute(_);
        });

        private static void ExecuteIgnoringExceptions(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
