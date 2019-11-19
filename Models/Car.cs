using System.Collections.Generic;

namespace ParkingLot.Models
{
    public class Car
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public string RegistrationNumber { get; protected set; }

        public long OwnerId { get; protected set; }

        public string VehicleBrand { get; protected set; }

        public string Color { get; protected set; }

        public virtual Owner Owner { get; protected set; }

        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

        protected Car()
        {

        }

        public Car(string registrationNumber, long ownerId, string vehicleBrand, string color)
        {
            RegistrationNumber = registrationNumber;
            OwnerId = ownerId;
            VehicleBrand = vehicleBrand;
            Color = color;
        }
    }
}
