using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class PersonalWagon : IWagons
    {
        private List<Door> doors;
        private List<Chair> sits;
        private int numberOfChairs;
        public List<Door> Doors { get => doors; set => doors = value; }
        public List<Chair> Sits { get => sits; set => sits = value; }
        public int NumberOfChairs { get => numberOfChairs; set => numberOfChairs = value; }

        public PersonalWagon(int NumberOfChairs)
        {
            this.numberOfChairs = NumberOfChairs;
            Sits = new List<Chair> { };
            for (int i = 1; i < NumberOfChairs; i++)
            {
                Sits.Add(new Chair(i, true));
            }
        }
        public void ConnectWagon(Train train)
        {
            if ((train.Locomotive.Engine.Type == "steam") && (train.Wagons.Count >= 5))
            {
                Console.WriteLine("over limit for steam engine - wagon disconnected");
            }
            else { train.Wagons.Add(this); Console.WriteLine("wagon connected"); }
        }
        public void DisconnectWagon(Train train)
        {
            if (train.Wagons.Contains(this))
            {
                train.Wagons.Remove(this);
                Console.WriteLine("wagon disconnected");
            }
            else { Console.WriteLine("the train does not have connected this wagon"); }

        }
        public override string ToString()
        {
            return $"Type of wagon: {this.GetType().Name}, number of seats: {NumberOfChairs}";
        }
    }
}
