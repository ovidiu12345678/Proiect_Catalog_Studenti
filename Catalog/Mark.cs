using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Mark
    {
        private readonly UInt16 value; //valoarea notei
        private readonly DateTime dateTime; //data si ora la care a fost acordata
        private readonly Course course;   //materia

        //Constructor cu parametrii
        public Mark(UInt16 value, DateTime dateTime,Course course)
        {
            this.value = value;
            this.dateTime = dateTime;
            this.course = course;
        }

        //doar getters(nu avem nevoie de setters pentru ca nu e nevoie sa modificam nota niciodata)
        public UInt16 Value { get => value; }
        public DateTime DateTime { get => dateTime; }
        public Course Course { get => course; }

        //Am suprascris metoda ToString pe care o are fiecare obiect pentru a facilita afisarea unui obiect de tipul Mark la consola intr-un mod organizat
        public override String ToString()
        {
            return String.Format("Value : {0}, DateTime : {1}, Course : {2}\n\t", value, dateTime, course);
        }
    }
}
