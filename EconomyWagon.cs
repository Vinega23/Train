using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class EconomyWagon : PersonalWagon, IWagons
    {
        public EconomyWagon(int numberOfChairs)
            : base(numberOfChairs)
        {
            NumberOfChairs = numberOfChairs;
        }
        public override string ToString()
        {
            return $"Type of wagon: {this.GetType().Name}, number of seats: {NumberOfChairs}";
        }


    }
}
