using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ParkingLot.Context;
using ParkingLot.Models;
using ParkingLot.ViewModels.MVVM;

namespace ParkingLot.ViewModels
{
    public class TicketsPresenter : Presenter
    {
        public ObservableCollection<Ticket> History { get; } = new ObservableCollection<Ticket>();

        public ICommand ShowTicketsCommand => new Command(_ =>
        {
            using var db = new AppDbContext();
            var tickets = db.Tickets.ToList();
            foreach (var ticket in tickets)
            {
                History.Add(ticket);
            }
        });

        public ICommand AddTicketCommand => new Command(_ =>
        {
            using var db = new AppDbContext();
            db.Tickets.Add(new Ticket("A111AA", DateTime.Today.AddDays(1), 3, 1));
            db.SaveChanges();
            ShowTicketsCommand.Execute(_);
        });
    }
}
