using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Hopper : IWagons
    {
        private double loadingCapacity;
        public double LoadingCapacity { get => loadingCapacity; set => loadingCapacity = value; }
        public Hopper(double tonnage)
        {
            loadingCapacity = tonnage;
        }
        public override string ToString()
        {
            return $"type of wagon: {this.GetType().Name}, loading capacity: {LoadingCapacity}";
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
    }
}
