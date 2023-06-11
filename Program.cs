using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Lab.BL;
using Week5Lab.DL;

namespace Week5Lab
{
    public class Program
    {
        public static List<Student> studentList = new List<Student>();
        public static List<DegreeProgram> programList = new List<DegreeProgram>();
        public static void Main(string[] args)
        {
            int option;
            do
            {
                option = DegreeProgram.Menu();

                Student.clearScreen();

                if (option == 1)

                {
                    if (programList.Count > 0)
                    {
                        Student s = DegreeProgram.takeInputForStudent();

                        DegreeProgram.addIntoStudentList(s);
                    }
                }
                else if (option == 2)

                {

                    DegreeProgram d = DegreeProgram.takeInputForDegree();

                    DegreeProgram.addIntoDegreeList(d);
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentsList = new List<Student>();
                    sortedStudentsList = Student.sortStudentsByMerit();
                    Student.giveAdmission(sortedStudentsList);
                    Student.printStudents();
                }
                else if (option == 4)
                {
                    Student.viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write(" Enter Degree Name: ");
                    degName = Console.ReadLine();
                    Student.viewStudentsInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write(" Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentPresent(name);
                    if (s != null)
                    {
                        DegreeProgram.viewSubjects(s);
                        registerSubjects(s);
                    }
                }
                else if (option == 7)
                {
                    calculateFeeForAll();
                }
                Student.clearScreen();
            }
            while (option != 8);
            Console.ReadKey();
        }

        static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        static void calculateFeeForAll()
        {
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.calculateFee() + " fees.");
                }
            }
        }
        static void registerSubjects(Student s)
        {
            Console.Write(" Enter how many subjects you want to register: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.Write(" Enter the Subject Code: ");
                string code = Console.ReadLine();
                bool flag = false;
                foreach (Subject sub in s.regDegree.subjects)
                {
                    if (code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        s.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine(" Enter Valid Course!");
                    x--;
                }
            }
        }
    }
}