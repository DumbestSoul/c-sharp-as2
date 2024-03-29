using System;

namespace Assignment2
{
    internal class Employee
    {
        public int employeeId;
        public string name;
        public string position;
        public double salary;
        public DateTime joinDate;
      

        public Employee(int id, string name_, string pos, double sal, DateTime jn)
        {
            employeeId = id;
            name = name_;
            position = pos;
            salary = sal;
            joinDate = jn;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[Id:{employeeId}, Name:{name}, Position:{position}, Salary:{salary}, Join Date:{joinDate}]");
        }
    }
}
