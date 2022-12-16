using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class BusinessWagon : PersonalWagon, IWagons
    {
        private Person steward;
        public Person Steward { get => steward; set => steward = value; }
        public BusinessWagon(Person steward, int numberOfChairs)
            : base(numberOfChairs)
        {
            this.steward = steward;
            NumberOfChairs = numberOfChairs;
        }
        public override string ToString()
        {
            return $"Type of wagon: {this.GetType().Name}, number of seats: {NumberOfChairs}, steward: {steward}";

        }
    }
}
