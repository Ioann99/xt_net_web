using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//здесь сразу задания 2.3 и 2.5
namespace _3.User
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            Console.WriteLine("Enter name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter surname");
            user.Surname = Console.ReadLine();
            Console.WriteLine("Enter middle name");
            user.MiddleName = Console.ReadLine();

            Console.WriteLine("Enter day of birth");
            user.Day = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter month of birth");
            user.Month = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter year of birth");
            user.Year = Convert.ToInt32(Console.ReadLine());

            user.GetInfo();

            Console.WriteLine("STARTING DAUGHTER CLASS EMPLOYEE");

            Employee emp = new Employee(user);
            Console.WriteLine("Enter work experience");
            emp.WorkExperience = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter work position"); ;
            emp.Position = Console.ReadLine();
            emp.GetInfo();

            Console.ReadKey();
        }
    }

    class User
    {
        public string Name, Surname, MiddleName;
        private int _dayOfBirth;
        private int _monthOfBirth;
        private int _yearOfBirth;
        public int Day
        {
            get => _dayOfBirth;
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Incorrect date");
                    int.TryParse(Console.ReadLine(), out value);
                }

                _dayOfBirth = value;
            }
        }

        public int Month
        {
            get => _monthOfBirth;
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Incorrect date");
                    int.TryParse(Console.ReadLine(), out value);
                }

                _monthOfBirth = value;
            }
        }

        public int Year
        {
            get => _yearOfBirth;
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Incorrect date");
                    int.TryParse(Console.ReadLine(), out value);
                }

                _yearOfBirth = value;
            }
        }

        virtual public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}" +
                              Environment.NewLine +
                              $"Surname: {Surname}" +
                              Environment.NewLine +
                              $"Middle name: {MiddleName}" +
                              Environment.NewLine +
                              $"Date of birth: {_dayOfBirth}.{Month}.{Year}" +
                              Environment.NewLine +
                              $"Age: {Age}");
        }

        public int Age { get { return (int)(DateTime.Now - new DateTime(this._yearOfBirth, this._monthOfBirth, this._dayOfBirth)).TotalDays / 365; } }
    }

    class Employee : User
    {
        private double _workExperience;
        private string _position;

        public Employee(User user)
        {
            this.Day = user.Day;
            this.Month = user.Month;
            this.Year = user.Year;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.MiddleName = user.MiddleName;
        }

        public double WorkExperience
        {
            get => _workExperience;
            set
            {
                while (value < 0)
                {
                    Console.WriteLine("Incorrect value. It nust be 0 or bigger");
                    double.TryParse(Console.ReadLine(), out value);
                }

                _workExperience = value;
            }
        }

        public string Position
        {
            get => _position;
            set
            {
                if (value != String.Empty)
                {
                    _position = value;
                }

            }
        }

        override public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}" +
                              Environment.NewLine +
                              $"Surname: {Surname}" +
                              Environment.NewLine +
                              $"Middle name: {MiddleName}" +
                              Environment.NewLine +
                              $"Date of birth: {Day}.{Month}.{Year}" +
                              Environment.NewLine +
                              $"Age: {Age}" + 
                              Environment.NewLine + 
                              $"Work experience: {WorkExperience}" + 
                              Environment.NewLine + 
                              $"Work position: {Position}");
        }
    }
}
