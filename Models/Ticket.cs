using System;

namespace ParkingLot.Models
{
    public class Ticket
    {
        public long Id { get; protected set; }

        public string RegistrationNumber { get; protected set; }

        public DateTime ArrivalDate { get; protected set; }

        public DateTime DepartureDate { get; protected set; }

        public long LocationId { get; protected set; }

        public long RateId { get; protected set; }

        public virtual Car Car { get; protected set; }

        public virtual Location Location { get; protected set; }

        public virtual Rate Rate { get; protected set; }

        protected Ticket()
        {

        }

        public Ticket(string registrationNumber, DateTime departureDate, long locationId, long rateId)
        {
            RegistrationNumber = registrationNumber;
            ArrivalDate = DateTime.Now;
            DepartureDate = departureDate;
            LocationId = locationId;
            RateId = rateId;
        }
    }
}
