using System;

namespace ParkingLot.Models
{
    public class Ticket
    {
        public long Id { get; protected set; }

        public string RegistrationNumber { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public long LocationId { get; set; }

        public long RateId { get; set; }

        public virtual Car Car { get; protected set; }

        public virtual Location Location { get; protected set; }

        public virtual Rate Rate { get; protected set; }

        protected Ticket()
        {
        }

        public Ticket(string registrationNumber, long locationId, long rateId)
        {
            RegistrationNumber = registrationNumber;
            ArrivalDate = DateTime.Now;
            LocationId = locationId;
            RateId = rateId;
        }
    }
}
