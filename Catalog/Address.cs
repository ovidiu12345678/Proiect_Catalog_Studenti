using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Address
    {
        private string city;
        private string street;
        private int number;

        //Constructor cu parametrii
        public Address(string city, string street, int number)
        {
            this.city = city;
            this.street = street;
            this.number = number;
        }

        //getters and setters
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int Number { get => number; set => number = value; }

        //Am suprascris metoda ToString pe care o are fiecare obiect pentru a facilita afisarea unui obiect de tipul Address la consola intr-un mod organizat
        public override string ToString()
        {
            return String.Format("City : {0}\n\t  Street : {1}\n\t  Number : {2}", city, street, number);
        }
    }
}
