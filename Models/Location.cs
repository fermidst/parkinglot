using System.Collections.Generic;

namespace ParkingLot.Models
{
    public class Location
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public long Id { get; set; }

        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();
    }
}
