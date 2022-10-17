using Catalog;
using System.Data;
using System.Runtime.CompilerServices;

class Classbook
{
    //Initializeaza lista de studenti
    List<Student> students = ClassbookHelper.getStartupStudentsList();

    //Adauga un studnet in lista
    public void addStudent(Student student) { students.Add(student); }

    //Stergem un student
    public void removeStudent(UInt16 studentId) {
        if (students.Find(student => student.Id == studentId) != null)  //Verificam ca studentul exista
            students.Remove(getStudentById(studentId));                 //Daca exista il stergem
        else throw new Exception("Studentul cu ID-ul dat nu exista");  //Daca nu exista aruncam exceptie
    }

    //Cautam un student dupa ID
    public Student getStudentById(UInt16 studentId)
    {
        Student student=students.Find(student => student.Id == studentId);
        if (student == null) throw new Exception("Studentul cu ID-ul dat nu exista");  //Daca studentul nu exista
        return student;  //Daca studentul exista il returnam
    }

    //Lista studentilor ordonati dupa medie descrescator
    public List<Student> getStudentsOrderedByAverageDesc()
    {
        return students.OrderByDescending(student => student.getStudentAverage()).ToList();
    }
    
    //getter and setter pentru lista de studenti
    public List<Student> Students { get => students; set => students = value; }
}