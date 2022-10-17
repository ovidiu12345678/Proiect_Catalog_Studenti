using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Program
    {

        // Main Method
        public static void Main(String[] args)
        {
            try
            {
                Classbook classbook = new Classbook();

                string menu = "Alegeti optiunea:\n" +
                              "1.Afiseaza toti studentii\n" +
                              "2.Afiseaza un student dupa ID\n" +
                              "3.Adauga un student\n" +
                              "4.Sterge student\n" +
                              "5.Modifica date student\n" +
                              "6.Modificare adresa student\n" +
                              "7.Acorda nota unui student\n" +
                              "8.Afiseaza media generala a unui student\n" +
                              "9.Afisati media generala a unui student in functie de materie\n" +
                              "10.Afisati studentii in ordinea descrescatoare a mediilor\n" +
                              "Optiune=";

                while (true)
                {
                    Console.Write(menu);  //Afiseaza meniul
                    string option = Console.ReadLine();  //Citeste optiunea aleasa
                    switch (option) //In functie de optiune se intampla o alta actiune
                    {
                        case "1":
                            classbook.Students.ForEach(student => Console.WriteLine(student));
                            break;
                        case "2":
                            Console.Write("Introduceti ID-ul studentului pe care doriti sa-l afisati=");
                            UInt16 studentId = ClassbookHelper.readInt();
                            Console.WriteLine(classbook.getStudentById(studentId));
                            break;
                        case "3":
                            Student student = ClassbookHelper.readStudent();
                            classbook.addStudent(student);
                            break;
                        case "4":
                            Console.Write("Introduceti ID-ul studentului pe care doriti sa-l stergeti=");
                            studentId = ClassbookHelper.readInt();
                            classbook.removeStudent(studentId);
                            break;
                        case "5":
                            Console.Write("Introduceti ID-ul studentului ale carui date doriti sa le modificati=");
                            studentId = ClassbookHelper.readInt();
                            ClassbookHelper.modifyStudentInfo(classbook.getStudentById(studentId));
                            break;
                        case "6":
                            Console.Write("Introduceti ID-ul studentului a carui adresa dotiti sa o modificati=");
                            studentId = ClassbookHelper.readInt(); ;
                            classbook.getStudentById(studentId).modifyStudentAddress();
                            break;
                        case "7":
                            Console.Write("Introduceti ID-ul studentului caruia doriti sa-i adaugati o nota=");
                            studentId = ClassbookHelper.readInt();
                            classbook.getStudentById(studentId).addMark();
                            break;
                        case "8":
                            Console.Write("Introduceti ID-ul studentului caruia doriti sa-i calculati media=");
                            studentId = ClassbookHelper.readInt();
                            Console.WriteLine(String.Concat("Media studentului este : ", classbook.getStudentById(studentId).getStudentAverage()));
                            break;
                        case "9":
                            Console.Write("Introduceti ID-ul studentului caruia doriti sa-i calculati mediile in functie materie=");
                            studentId = ClassbookHelper.readInt();
                            classbook.getStudentById(studentId).getStudentAverageOnEachSubject().ToList().ForEach(kvp => Console.WriteLine(String.Concat(kvp.Key, " : ", kvp.Value)));
                            break;
                        case "10":
                            classbook.getStudentsOrderedByAverageDesc().ForEach(student => Console.WriteLine(student));
                            break;
                        default:
                            Console.WriteLine("\nOptiunea aleasa nu este valida\n");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
            
