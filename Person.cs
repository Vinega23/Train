using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Person
    {
        private string firstName;
        private string lastName;
        public string FirstName { get => firstName; set => firstName = value; }
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public override string ToString()
        {
            return $" {firstName} {lastName} ";

        }
    }
}
