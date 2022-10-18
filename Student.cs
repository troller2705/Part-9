using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_9_Classes
{
    class Student
    {
        private static Random generator = new Random();

        private string _firstName;
        private string _lastName;
        private string _email;
        private int _studentNumber;

        public Student(string firstName, string lastName)
        {
            _firstName = firstName.Trim();
            _lastName = lastName.Trim();
            _studentNumber = generator.Next(0, 1000) + 555000;
            GenerateEmail();
        }
        public string Email
        {
            get
            {
                return _email;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                GenerateEmail();
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                GenerateEmail();
            }
        }
        public int StudentNumber
        {
            get
            {
                return _studentNumber;
            }
        }
        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
        public void ResetStudentNumber()
        {
            _studentNumber = generator.Next(0, 1000) + 555000;
            GenerateEmail();
        }
        private void GenerateEmail()
        {
            string first, last;

            if (_firstName.Length <= 3)
                first = _firstName;
            else
                first = _firstName.Substring(0, 3);

            if (_lastName.Length <= 3)
                last = _lastName;
            else
                last = _lastName.Substring(0, 3);

            _email = first + last + (_studentNumber + "").Substring(3) + "@ICS4U.com";
        }
        public int CompareTo(Student that)
        {
            if (this.LastName.CompareTo(that.LastName) == 0)
                return this.FirstName.CompareTo(that.FirstName);

            return this.LastName.CompareTo(that.LastName);
        }
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
                return false;
            return this.FirstName == student.FirstName && this.LastName == student.LastName && this.StudentNumber == student.StudentNumber;
        }
        public override int GetHashCode()
        {
            return (_firstName + _lastName + _studentNumber).GetHashCode();
        }
    }
}
