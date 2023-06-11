using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Lab.DL;

namespace Week5Lab.BL
{
    public class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects;
        public int seats;

        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }


        public int calculateCreditHours()
        {
            int count = 0;

            for (int x = 0; x < subjects.Count; x++)

            {

                count = count + subjects[x].creditHours;

            }
            return count;
        }
        public bool AddSubject(Subject s)

        {
            int creditHours = calculateCreditHours();

            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isSubjectExisted(Subject sub)
        {
            foreach (Subject s in subjects)
            {
                if (s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }
        public static void addIntoDegreeList(DegreeProgram d)
        {
            Program.programList.Add(d);
        }
        public static DegreeProgram takeInputForDegree()
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.Write(" Enter Degree Name: ");
            degreeName = Console.ReadLine();
            Console.Write(" Enter Degree Duration: ");
            degreeDuration = float.Parse(Console.ReadLine());
            Console.Write(" Enter Seats For Degree: ");
            seats = int.Parse(Console.ReadLine());

            DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);
            Console.Write(" Enter How many Subjecs to Enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                degProg.AddSubject(takeInputForSubject());
            }
            return degProg;
        }
        public static Subject takeInputForSubject()
        {
            string code;
            string type;
            int creditHours;
            int subjectFees;
            Console.Write(" Enter Subject Code: ");
            code = Console.ReadLine();
            Console.Write(" Enter Subject Type: ");
            type = Console.ReadLine();
            Console.Write(" Enter Subject Credit Hours: ");
            creditHours = int.Parse(Console.ReadLine());
            Console.Write(" Enter Subject Fee: ");
            subjectFees = int.Parse(Console.ReadLine());
            Subject sub = new Subject(code, type, creditHours, subjectFees);
            return sub;
        }
        public static void addIntoStudentList(Student s)
        {
            Program.studentList.Add(s);
        }
        public static Student takeInputForStudent()
        {
            string name;
            int age;
            double fscMarks;
            double ecatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write(" Enter Student Name: ");
            name = Console.ReadLine();
            Console.Write(" Enter Student's Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write(" Enter Student's FSC Marks: ");
            fscMarks = double.Parse(Console.ReadLine());
            Console.Write(" Enter Student's Ecat Marks: ");
            ecatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("    AVAILABLE DEGREE PROGRAMS: ");
            viewDegreePrograms();

            Console.Write("Enter how many preferences to Enter: ");

            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                Console.WriteLine("Enter Degree Program Name");
                string degName = Console.ReadLine();

                bool flag = false;

                foreach (DegreeProgram dp in Program.programList)
                {

                    if (degName == dp.degreeName && !(preferences.Contains(dp)))

                    {
                        preferences.Add(dp);

                        flag = true;
                    }
                }

                if (flag == false)

                {
                    Console.WriteLine("Enter Valid Degree Program Name!");
                    x--;
                }
            }

            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);

            return s;
        }

        public static void viewDegreePrograms()

        {

            foreach (DegreeProgram dp in Program.programList)

            {

                Console.WriteLine(dp.degreeName);

            }

        }

        public static void header()

        {
            Console.WriteLine("*******************");

            Console.WriteLine("*         UAMS        *");

            Console.WriteLine("*******************");
        }

        public static void viewSubjects(Student s)

        {

            if (s.regDegree != null)

            {

                Console.WriteLine("Sub Code\tSub Type");

                foreach (Subject sub in s.regDegree.subjects)

                {

                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }

        public static int Menu()

        {
            header();

            int option;

            Console.WriteLine("1. Add Student");

            Console.WriteLine("2. Add Degree Program");

            Console.WriteLine("3. Generate Merit");

            Console.WriteLine("4. View Registered Students");

            Console.WriteLine("5. View Students of a Specific Program");

            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");

            Console.WriteLine("8. Exit");



            Console.Write("Enter Option: ");

            option = int.Parse(Console.ReadLine());

            return option;
        }
    }
}