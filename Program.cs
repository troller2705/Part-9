using System.Collections.Generic;
using System.Xml.Linq;

namespace Part_9_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menu;
            bool done = false;
            List<Student> students = new List<Student>();
            students.Add(new Student("Robert", "Ross"));
            students.Add(new Student("Tyran", "Colt"));
            students.Add(new Student("Ivan", "Ingo"));

            while (!done)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Display all students");
                Console.WriteLine("2) Info on specified student");
                Console.WriteLine("3) Add student");
                Console.WriteLine("4) Remove student");
                Console.WriteLine("5) Search for student");
                Console.WriteLine("6) Edit student info");
                Console.WriteLine("7) Sort students (Doesn't work)");
                Console.WriteLine("X) Exit");
                Console.Write("Enter a selection to run it: ");
                menu = Console.ReadLine()!.ToLower();

                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        DisplayStudents(students);
                        break;
                    case "2":
                        Console.Clear();
                        StudentInfo(students);
                        break;
                    case "3":
                        Console.Clear();
                        AddStudent(students);
                        break;
                    case "4":
                        Console.Clear();
                        RemoveStudent(students);
                        break;
                    case "5":
                        Console.Clear();
                        SearchForStudent(students);
                        break;
                    case "6":
                        Console.Clear();
                        EditStudent(students);
                        break;
                    case "7":
                        Console.Clear();
                        try
                        {
                            students.Sort();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Sort failed with exception {e}");
                        }
                        break;
                    case "x":
                        done = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static void DisplayStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
        public static void StudentInfo(List<Student> students)
        {
            string fName, lName;

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.Write("Please enter student's first name: ");
            fName = Console.ReadLine()!;
            Console.Write("Please enter student's last name: ");
            lName = Console.ReadLine()!;
            foreach (Student student in students)
            {
                if (student.FirstName.Contains(fName))
                {
                    if (student.LastName.Contains(lName))
                    {
                        Console.WriteLine(student.FirstName + ", " + student.LastName + ", " + student.StudentNumber + ", " + student.Email);
                    }
                }
            }
        }
        public static void AddStudent(List<Student> students)
        {
            string first;
            string last;

            Console.Write("Enter new student's first name: ");
            first = Console.ReadLine()!;
            Console.Write("Enter new student's last name: ");
            last = Console.ReadLine()!;
            students.Add(new Student(first, last));
        }
        public static void RemoveStudent(List<Student> students)
        {
            string remove;
            int sNum;

            foreach (Student student in students)
            {
                Console.WriteLine(student + ", " + student.StudentNumber);
            }

            Console.Write("Enter student name or student number to remove: ");
            remove = Console.ReadLine()!;

            if (remove != null)
            {
                if (remove.Contains("555"))
                {
                    int.TryParse(remove, out sNum);

                    foreach (Student student in students)
                    {
                        if (student.StudentNumber.Equals(sNum))
                        {
                            students.Remove(student);
                        }
                    }
                }
                else
                {
                    foreach (Student student in students)
                    {
                        if (remove.Contains(student.FirstName) && remove.Contains(student.LastName))
                        {
                            students.Remove(student);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Input can't be null");
            }
        }
        public static void SearchForStudent(List<Student> students)
        {
            string menu, fName, lName;
            int sNum;

            foreach (Student student in students)
            {
                Console.WriteLine(student + ", " + student.StudentNumber);
            }

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1) First name");
            Console.WriteLine("2) Last name");
            Console.WriteLine("3) Student Number");
            Console.Write("Enter a selection to search by: ");
            menu = Console.ReadLine()!.ToLower();

            switch (menu)
            {
                case "1":
                    Console.Write("Enter student's first name: ");
                    fName = Console.ReadLine()!;
                    foreach (Student student in students)
                    {
                        if (student.FirstName.Contains(fName))
                        {
                            Console.WriteLine(student.FirstName + ", " + student.LastName + ", " + student.StudentNumber + ", " + student.Email);
                        }
                    }
                    break;
                case "2":
                    Console.Write("Enter student's last name: ");
                    lName = Console.ReadLine()!;
                    foreach (Student student in students)
                    {
                        if (student.LastName.Contains(lName))
                        {
                            Console.WriteLine(student.FirstName + ", " + student.LastName + ", " + student.StudentNumber + ", " + student.Email);
                        }
                    }
                    break;
                case "3":
                    Console.Write("Enter student number: ");
                    int.TryParse(Console.ReadLine()!, out sNum);
                    foreach (Student student in students)
                    {
                        if (student.StudentNumber.ToString().Contains(sNum.ToString()))
                        {
                            Console.WriteLine(student.FirstName + ", " + student.LastName + ", " + student.StudentNumber + ", " + student.Email);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public static void EditStudent(List<Student> students)
        {
            string menu, fName, lName;
            int index;

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.Write("Please enter student's first name: ");
            fName = Console.ReadLine()!;
            Console.Write("Please enter student's last name: ");
            lName = Console.ReadLine()!;
            foreach (Student student in students)
            {
                if (student.FirstName.Contains(fName))
                {
                    if (student.LastName.Contains(lName))
                    {
                        index = students.IndexOf(student);

                        Console.WriteLine("Menu Options:");
                        Console.WriteLine("1) Change first name");
                        Console.WriteLine("2) Change last name");
                        Console.WriteLine("3) Reset student number");
                        Console.Write("Enter a selection to run it: ");
                        menu = Console.ReadLine()!.ToLower();

                        switch (menu)
                        {
                            case "1":
                                Console.Write("Enter new first name: ");
                                students[index].FirstName = Console.ReadLine()!;
                                break;
                            case "2":
                                Console.Write("Enter new last name: ");
                                students[index].LastName = Console.ReadLine()!;
                                break;
                            case "3":
                                students[index].ResetStudentNumber();
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }
                    }
                }
            }
        }
    }
}