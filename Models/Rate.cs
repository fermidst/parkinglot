using System.Collections.Generic;

namespace ParkingLot.Models
{
    public class Rate
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public long Id { get; protected set; }

        public string Type { get; protected set; }

        public decimal Cost { get; protected set; }

        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

        protected Rate()
        {

        }

        public Rate(string type, decimal cost)
        {
            Type = type;
            Cost = cost;
        }
    }
}
