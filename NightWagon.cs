using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class NightWagon : PersonalWagon, IWagons
    {
        private Bed[] beds;
        private int numberOfBeds;
        public Bed[] Beds { get => beds; set => beds = value; }
        public int NumberOfBeds { get => numberOfBeds; set => numberOfBeds = value; }
        public NightWagon(int numberOfBeds, int numberOfChairs)
            : base(numberOfChairs)
        {

            this.numberOfBeds = numberOfBeds;
            NumberOfChairs = numberOfChairs;
        }
        public override string ToString()
        {
            return $"Type of wagon: {this.GetType().Name}, number of seats: {NumberOfChairs}, number of beds: {NumberOfBeds}";
        }

    }
}
