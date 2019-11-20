using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ParkingLot.Context;
using ParkingLot.Models;
using ParkingLot.ViewModels.MVVM;

namespace ParkingLot.ViewModels
{
    public class UserPanelPresenter : Presenter
    {
        private readonly AppDbContext _context = new AppDbContext();
        private long _userId;
        private string _registrationNumber = string.Empty;
        private long _locationId;
        private long _rateId;
        private decimal _price;
        private Ticket _selectedTicket = null!;

        public ObservableCollection<Ticket> Tickets { get; } = new ObservableCollection<Ticket>();

        public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();

        public ObservableCollection<Rate> Rates { get; } = new ObservableCollection<Rate>();

        public long UserId
        {
            get => _userId;
            set => Update(ref _userId, value);
        }

        public string RegistrationNumber
        {
            get => _registrationNumber;
            set => Update(ref _registrationNumber, value);
        }

        public long LocationId
        {
            get => _locationId;
            set => Update(ref _locationId, value);
        }

        public long RateId
        {
            get => _rateId;
            set => Update(ref _rateId, value);
        }

        public decimal Price
        {
            get => _price;
            set => Update(ref _price, value);
        }

        public Ticket SelectedTicket
        {
            get => _selectedTicket;
            set => Update(ref _selectedTicket, value);
        }

        public ICommand AddTicketCommand => new Command(_ =>
        {
            _context.Tickets.Add(new Ticket(RegistrationNumber, LocationId, RateId));
            _context.SaveChanges();
        });

        public ICommand PayTicketCommand => new Command(_ =>
        {
            //var tickets = _context.Tickets.Where(t => t.RegistrationNumber == RegistrationNumber && t.DepartureDate == default);
            //Tickets.Clear();
            //foreach (var ticket in tickets)
            //{
            //    Tickets.Add(ticket);
            //}
            SelectedTicket.DepartureDate = DateTime.Now;
            Price = (decimal) (SelectedTicket.DepartureDate - SelectedTicket.ArrivalDate).TotalHours * SelectedTicket.Rate.Cost;
            _context.Tickets.Update(SelectedTicket);
            _context.SaveChanges();
        });

        public ICommand ShowUserTicketHistory => new Command(_ =>
        {
            var tickets = _context.Tickets.Where(t => t.RegistrationNumber == RegistrationNumber);
            Tickets.Clear();
            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        });

        public ICommand ShowLocationsCommand => new Command(_ =>
        {
            var locations = _context.Locations.Where(l => l.Tickets.All(ticket => ticket.DepartureDate != default));
            Locations.Clear();
            foreach (var location in locations)
            {
                Locations.Add(location);
            }
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
    }
}
