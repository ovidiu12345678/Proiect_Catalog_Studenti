using Catalog;
using System.Runtime.CompilerServices;

internal static class ClassbookHelper
{
    public static List<Student> getStartupStudentsList()
    {
        //Creaza o lista initiala de studenti pentru teste
        List<Student> students = new List<Student>()
        {

            new Student("firstName1", "lastName1", 1, new Address("City1", "Street1", 1), new List<Mark>() { new Mark(1, DateTime.Now, Course.Math), 
                                                                                                             new Mark(2, DateTime.Now, Course.Biology),
                                                                                                             new Mark(5, DateTime.Now, Course.Biology)}),
            new Student("firstName2", "lastName2", 2, new Address("City2", "Street2", 2), new List<Mark>() { new Mark(1, DateTime.Now, Course.Physics) }),
            new Student("firstName3", "lastName3", 3, new Address("City3", "Street3", 3), new List<Mark>() { new Mark(3, DateTime.Now, Course.Biology) }),
            new Student("firstName4", "lastName4", 4, new Address("City4", "Street4", 4), new List<Mark>() { new Mark(4, DateTime.Now, Course.Physics) }),
            new Student("firstName5", "lastName5", 5, new Address("City5", "Street5", 5), new List<Mark>() { new Mark(5, DateTime.Now, Course.Math) })

        };

        return students;
    }

    //Citeste de la tastatura campurile necesare pentru a crea un obiect de tipul Addres
    public static Address readAddress()
    {
        Console.Write("Oras=");
        string city = Console.ReadLine();

        Console.Write("Strada=");
        string street = Console.ReadLine();

        Console.Write("Numar=");
        int number = readInt();

        return new Address(city, street, number);
    }

    //Citeste de la tastatura campurile necesare pentru a crea un obiect de tipul Mark
    public static Mark readMark()
    {
        Console.Write("Valoare=");
        UInt16 value = readInt();

        Console.Write("Data si ora acordarii(MM/DD/YYYY HH:MM:SS)=");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());

        Console.Write("Curs=");
        Course course = (Course)Enum.Parse(typeof(Course), Console.ReadLine(), true);

        return new Mark(value, dateTime, course);
    }

    //Citeste de la tastatura o serie de obiecte de tipul Mark
    public static List<Mark> readMarks()
    {
        Console.Write("Introduceti numarul de note pe care doriti sa-l introduceti in catalog=");
        UInt16 marksNo = readInt();
        List<Mark> marks = new List<Mark>();
        while (marksNo>0)
        {
            marks.Add(readMark());
            marksNo--;
        }

        return marks;
    }

    //Citeste de la tastatura campurile necesare pentru a crea un obiect de tipul Student(apeleaza si readAddress si readMarks)
    public static Student readStudent()
    {
        Console.Write("Prenume=");
        string firstName = Console.ReadLine();

        Console.Write("Nume=");
        string lastName = Console.ReadLine();

        Console.Write("Varsta=");
        UInt16 age = readInt();

        Address address = readAddress();
        List<Mark> marks = readMarks();

        return new Student(firstName, lastName, age, address, marks);
    }

    //Citeste de la tastatura un string si incearca sa-l converteasca la int -> Arunca exceptie daca esueaza
    public static UInt16 readInt()
    {
        UInt16 id;
        bool success = UInt16.TryParse(Console.ReadLine(), out id);

        if (success)
            return id;
        else
        {
            throw new Exception("ID-ul introdus trebuie sa fie un numar");
        }
    }

    //Modifica datele studentului
    public static void modifyStudentInfo(Student student)
    {
        Console.Write("Alegeti ce doriti sa modificati:\n" +
                  "1.Nume\n" +
                  "2.Prenume\n" +
                  "3.Varsta\n" +
                  "Optiune=");  //Meniu
        string studentInfoToModify = Console.ReadLine();
        switch (studentInfoToModify)
        {
            case "1":
                Console.Write("Intoroduceti noul nume al studentului=");
                student.LastName = Console.ReadLine();  //Citeste noul nume al studentului
                break;
            case "2":
                Console.Write("Intoroduceti noul prenume al studentului=");
                student.FirstName = Console.ReadLine(); //Citeste noul prenume al studentului
                break;
            case "3":
                Console.Write("Intoroduceti noul nume al studentului=");
                student.Age = ClassbookHelper.readInt(); //Citeste noua varsta al studentului
                break;
            default:
                Console.WriteLine("Optiunea aleasa nu este valida\n");
                break;
        }
    }
}