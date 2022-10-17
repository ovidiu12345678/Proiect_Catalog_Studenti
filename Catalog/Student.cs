using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Student
    {
        //Folosit pentru generarea de ID-uri consecutive pentru studenti
        private static UInt16 idGenerator = 1;

        private UInt16 id=0;
        private string firstName;
        private string lastName;
        private UInt16 age;
        private Address address;  //adresa studentului
        private List<Mark> marks; //lista de note a studentului

        //Constructor cu parametrii
        public Student(string firstName, string lastName, UInt16 age, Address address, List<Mark> marks)
        {
            this.id = idGenerator++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.marks = marks;
        }

        //gettere si settere
        public UInt16 Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public UInt16 Age { get => age; set => age = value; }
        public Address Address { get => address; set => address = value; }
        public List<Mark> Marks { get => marks; set => marks = value; }

        //Am suprascris metoda ToString pe care o are fiecare obiect pentru a facilita afisarea unui obiect de tipul Student la consola intr-un mod organizat
        public override string ToString()
        {
            String studentAsString=String.Format("Id : {0}\nFirstName : {1}\nLastName : {2}\nAge : {3}\nAddress : {4}\nMarks : ",
                id, firstName, lastName, Age, address);

            marks.ForEach((mark) => studentAsString = String.Concat(studentAsString,mark));

            return String.Concat(studentAsString,"\n");
        }

        //Adauga nota studentului
        public void addMark()
        {
            Console.WriteLine("Introduceti nota:");
            Mark mark = ClassbookHelper.readMark(); //Citeste de la tastatura nota pe care dorim sa o adugam
            this.marks.Add(mark);
        }

        //Modifica adresa studentului
        public void modifyStudentAddress()
        {
            Console.WriteLine("Introduceti noua adresa");
            Address address = ClassbookHelper.readAddress(); //Citeste de la tastatura noua adresa
            this.address = address;
        }

        //Calculeaza media studentului
        public float getStudentAverage()
        {
            int marksSum = 0; //suma notelor studentului
            this.Marks.ForEach(mark => marksSum += mark.Value);  //Aduna notele studentului
            //evita impartirea la 0
            if (this.Marks.Count > 0)
                return (float)marksSum / this.Marks.Count; //Suma supra nr de note
            else return 0;
        }

        public Dictionary<Course, float> getStudentAverageOnEachSubject()
        {
            Dictionary<Course, float> averages = new Dictionary<Course, float>();  //Mediile studentului grupate pe materii
            Dictionary<Course, int> marksNr = new Dictionary<Course, int>();   //Numarul de note ale studentului grupate pe materii

            this.Marks.ForEach(mark =>  //Parcurgem notele studentului
            {
                if (!averages.ContainsKey(mark.Course))  //Cheia nu se afla in dictionar -> o aduagam
                    averages.Add(mark.Course, 0); 
                averages[mark.Course] += mark.Value;   //Adunam notele la materie resectiva

                if (!marksNr.ContainsKey(mark.Course))  //Cheia nu se afla in dictionar -> o aduagam
                    marksNr.Add(mark.Course, 0);
                marksNr[mark.Course]++;                 //Adunam numarul de note la materia respectiva

                foreach (var key in averages.Keys)  //Parcurgem dictionarul cu suma notelor unui student grupate pe materii
                {
                    if (marksNr[key] > 0)
                        averages[key] = (float)averages[key] / marksNr[key];  //suma supra nr de note la materia respectiva
                }
            });
            return averages;
        }
    }
}
