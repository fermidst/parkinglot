using System.Collections.Generic;

namespace ParkingLot.Models
{
    public class Owner
    {
        private readonly List<Car> _cars = new List<Car>();

        public long Id { get; protected set; }

        public string Name { get; protected set; }

        public string Phone { get; protected set; }

        public virtual IReadOnlyCollection<Car> Cars => _cars.AsReadOnly();

        protected Owner()
        {

        }
    }
}
