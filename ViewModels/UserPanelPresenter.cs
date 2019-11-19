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
        private string _userId = string.Empty;
        private string _registrationNumber = string.Empty;
        private long _locationId;
        private long _rateId;

        public ObservableCollection<Ticket> Tickets { get; } = new ObservableCollection<Ticket>();

        public string UserId
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

        public ICommand AddTicketCommand => new Command(_ =>
        {
            _context.Tickets.Add(new Ticket(RegistrationNumber, LocationId, RateId));
            _context.SaveChanges();
        });

        public ICommand PayTicketCommand => new Command(_ =>
        {
            var tickets = _context.Tickets.Where(t => t.RegistrationNumber == RegistrationNumber && t.DepartureDate == default);
            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        });
    }
}
