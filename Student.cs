using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Lab.BL;

namespace Week5Lab.DL
{
    public class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<BL.DegreeProgram> preferences;
        public List<Subject> regSubject;
        public DegreeProgram regDegree;

        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubject = new List<Subject>();
        }
        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach(Student s in Program.studentList)
            {
                s.calculateMerit();
            }
            sortedStudentList = sortedStudentList.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }

        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45) + ((ecatMarks / 400) * 0.55)) * 100;
        }

        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExisted(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }

        }
        public int getCreditHours()
        {
            int count = 0;
            foreach(Subject sub in regSubject)
            {
                count = count + sub.creditHours;
            }
            return count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if(regDegree != null)
            {
                foreach(Subject sub in regSubject)
                {
                    fee = fee + sub.subjectFees;
                }
            }
            return fee;
        }
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach(Student s in sortedStudentList)
            {
                foreach(DegreeProgram d in s.preferences)
                {
                    if(d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        public static void printStudents()
        {
            foreach(Student s in Program.studentList)
            {
                if(s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has got admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission!");
                }
            }
        }
        public static void clearScreen()
        {
            Console.WriteLine(" Press any key to Continue!");
            Console.ReadKey();
            Console.Clear();
        }
        public static void viewStudentsInDegree(string degName)
        {
            Console.WriteLine(" Name\tFSC\tEcat\tAge");
            foreach(Student s in Program.studentList)
            {
                if(s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }
        public static void viewRegisteredStudents()
        {
            Console.WriteLine(" Name\tFSC\tEcat\tAge");
            foreach (Student s in Program.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
    }
}