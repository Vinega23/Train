using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{

    class Engine
    {
        private string type;
        public string Type { get => type; set => type = value; }
        public Engine(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return $"{Type} ";
        }
    }
}
//Lokomotiva může být diesel, elektrická, parní (ta je omezeného výkonu,
//utáhne jen 5 vagonů, což vyřešíme v jiné třídě).
