using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Train
    {
        private Locomotive locomotive;
        private List<IWagons> wagons;
        public Locomotive Locomotive { get => locomotive; set => locomotive = value; }
        public List<IWagons> Wagons { get => wagons; set => wagons = value; }

        public Train()
        {
            this.locomotive = new Locomotive(new Person("", ""), new Engine(""));
            List<IWagons> wagons = new List<IWagons>();
        }
        public Train(Locomotive locomotive)
        {
            this.Wagons = new List<IWagons>();
            this.locomotive = locomotive;
        }
        public Train(Locomotive locomotive, List<IWagons> Wagons)
        {
            this.Wagons = new List<IWagons>();
            this.Locomotive = locomotive;
        }
        public void ConnectWagon(IWagons wagon)
        {
            if ((Locomotive.Engine.Type == "steam") && (Wagons.Count >= 5))
            {
                Console.WriteLine("over limit for steam engine - wagon disconnected");
            }
            else { wagon.ConnectWagon(this); ; Console.WriteLine("wagon connected"); }
        }
        public void DisconnectWagon(IWagons wagon)
        {

            if (Wagons.Contains(wagon))
            {
                wagon.DisconnectWagon(this);
                Console.WriteLine("wagon disconnected");
            }
            else { Console.WriteLine("the train does not have connected this wagon"); }

        }
        public void ReserveChair(int wagonNumber, int seatNumber)
        {

            if (wagonNumber - 1 < Convert.ToInt32(Wagons.Count))
            {
                if ((Wagons[wagonNumber - 1] is PersonalWagon))
                {

                    PersonalWagon wagon = (PersonalWagon)Wagons[wagonNumber - 1];
                    if (wagon.NumberOfChairs >= seatNumber)
                    {
                        if (!(wagon.Sits[seatNumber - 1].Reserved))
                        {
                            wagon.Sits[seatNumber - 1].Reserved = true;
                        }
                        else Console.WriteLine("Reservation error: Seat is reserved!");
                    }
                    else Console.WriteLine("Reservation error: wagon seat capacity exceeded!");
                }
                else { Console.WriteLine("Reservation error: this is not a personal wagon!"); }
            }
            else Console.WriteLine("Reservation error: wagon does not exist!");
        }
        public void ListReservedChairs()
        {
            Console.WriteLine("Reservations");
            for (int i = 0; i < Wagons.Count; i++)
            {
                Console.WriteLine($"{Wagons[i].GetType().Name}");
                if (Wagons[i] is PersonalWagon)
                {
                    PersonalWagon wagon = (PersonalWagon)Wagons[i];
                    for (int j = 0; j < wagon.Sits.Count; j++)
                    {
                        Console.WriteLine($"{wagon.Sits[j].Number} Reserved {wagon.Sits[j].Reserved}");
                    }
                }
            }
        }
        public override string ToString()
        {
            string s = $"{this.GetType().Name}\n{Locomotive.ToString()}";

            for (int i = 0; i < Wagons.Count; i++)
            {
                s += $"{Wagons[i].ToString()}\n";
            }
            return s;
        }
        public static void Main(string[] args)
        {
            BusinessWagon b1 = new BusinessWagon(new Person("Lenka", "Kozakova"), 15);
            NightWagon n1 = new NightWagon(20, 30);
            Hopper h1 = new Hopper(200);
            EconomyWagon e1 = new EconomyWagon(20);
            EconomyWagon e2 = new EconomyWagon(30);
            EconomyWagon e3 = new EconomyWagon(25);
            Locomotive l1 = new Locomotive(new Person("Karel", "Novak"), new Engine("diesel"));
            Train t1 = new Train(l1, new List<IWagons>());
            b1.ConnectWagon(t1);
            n1.ConnectWagon(t1);
            e1.ConnectWagon(t1);
            e2.ConnectWagon(t1);
            h1.ConnectWagon(t1);
            Console.WriteLine(t1.ToString());
            Hopper h2 = new Hopper(300);
            h2.ConnectWagon(t1);
            Console.WriteLine(t1.ToString());
            Locomotive l2 = new Locomotive(new Person("Josef", "Koza"), new Engine("steam"));
            Train t2 = new Train(l2, new List<IWagons>());
            b1.ConnectWagon(t2);
            n1.ConnectWagon(t2);
            h1.ConnectWagon(t2);
            h2.ConnectWagon(t2);
            e1.ConnectWagon(t2);
            t2.ConnectWagon(e2);

            Console.WriteLine(t2.ToString());
            t2.DisconnectWagon(e3);

            Console.WriteLine(t1.ToString());
            t1.ReserveChair(1, 12);
            t1.ReserveChair(2, 15);
            t1.ReserveChair(3, 22);
            t1.ReserveChair(5, 31);

            t1.ListReservedChairs();


        }
    }
}
