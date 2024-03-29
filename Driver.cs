using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Driver
    {
        List<Employee> empList;
        private string[] name = new string[] { "Rajat", "Rakesh", "Manas", "Asutosh", "Salony", "Prajyot" };
        private string[] pos = new string[] { "JSD", "JSD", "BA", "SDE", "BA", "SDE" };
        private double[] sal = new double[] { 30000, 30000, 40000, 45000, 40000, 45000 };
        
        /***********************************************************
         * CONSTRUCTOR
         **********************************************************/
        public Driver()
        {
            empList = new List<Employee>();
            Random rnd = new Random();
            // adds 6 entries into employee list
            for(int i = 0; i < 6; i++)
            {
                // this 3 lines create a random date from 2010-2024 following calendar rule
                int year = 2010 + (rnd.Next(15));
                int mon = rnd.Next(1, 13);
                int date = mon == 2 ? (year % 4 == 0 ? rnd.Next(1, 30) : rnd.Next(1, 29)) : rnd.Next(1, 32);

                DateTime dt = new DateTime(year, mon, date);
                Employee emp = new Employee(i + 1, name[i], pos[i], sal[i], dt);
                empList.Add(emp);
            }
        }
        /***********************************************************
         * MAIN DRIVER PROGRAM CODE
         **********************************************************/
        public void Run()
        {
            try
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("1. Read all Employee Data");
                    Console.WriteLine("2. Read the data of employee with 2nd highest salary");
                    Console.WriteLine("3. Add an employee");
                    Console.WriteLine("4. Read data of employee under a certain period of data");
                    Console.WriteLine("5. Update employee data");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter your choice:");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 0:
                            running = false;
                            break;
                        case 1:
                            ReadData();
                            break;
                        case 2:
                            ReadSecondHighest();
                            break;
                        case 3:
                            AddEmployee();
                            break;
                        case 4:
                            ReadRangeData();
                            break;
                        case 5:
                            UpdateData();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice...");
                            break;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        /************************************************************
         * PROGRAM THAT READS DATA OF ALL EMPLOYEES
         ***********************************************************/
        void ReadData()
        {
            if(empList.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }
            Console.WriteLine("Reading Data of all employees...");
            foreach(Employee employee in empList)
            {
                employee.DisplayInfo();
            }
        }

        /****************************************************************
         * PROGRAM THAT READS DATA OF EMPLOYEES HAVING 2nd HIGHEST SALARY
         ***************************************************************/
        void ReadSecondHighest()
        {
            List<Employee> temp = new List<Employee>(empList);
            temp.Sort((a, b) => b.salary.CompareTo(a.salary));  // sorts the object list in descending order
            for(int i = 1; i < temp.Count; i++)
            {
                if (temp[i].salary == temp[i - 1].salary) continue;
                else
                {
                    Console.Write($"Employee with the second highest salary is -> ");
                    temp[i].DisplayInfo();
                    break;
                }
            }

        }
        /**************************************************************
         * ADDS A NEW EMPLOYEE TO THE EMPLOYEE LIST
         *************************************************************/
        void AddEmployee()
        {
            try
            {
                int id;
                string name, position;
                double salary;
                DateTime dt;

                Console.Write("Enter the ID of the employee: ");
                id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the name of the Employee: ");
                name = Console.ReadLine();
                Console.Write("Enter the position of the employee: ");
                position = Console.ReadLine();
                Console.Write("Enter Salary: ");
                salary = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Joining Date: ");
                dt = Convert.ToDateTime(Console.ReadLine());

                Employee emp = new Employee(id, name, position, salary, dt);
                empList.Add(emp);
                Console.WriteLine("Addition to the List Completed.\n");

            }catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        /****************************************************************
         * PRINTS EMPLOYEE THOSE WHO HAVE JOINED BETWEEN TWO GIVEN DATES
         ***************************************************************/
        void ReadRangeData()
        {
            try
            {
                int d1, d2, y1, y2, m1, m2;

                // Creates the first date
                Console.WriteLine("Give the specification of starting date...");
                Console.Write("Enter the date: ");
                d1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the month: ");
                m1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the year: ");
                y1 = Convert.ToInt32(Console.ReadLine());

                // Creates the second date
                Console.WriteLine("Give the specification of ending date...");
                Console.Write("Enter the date: ");
                d2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the month: ");
                m2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the year: ");
                y2 = Convert.ToInt32(Console.ReadLine());

                DateTime dt1 = new DateTime(y1, m1, d1);
                DateTime dt2 = new DateTime(y2, m2, d2);

                Console.WriteLine($"\nEmployees joined between {dt1} and {dt2}");
                foreach (Employee e in empList)
                {
                    if (e.joinDate >= dt1 && e.joinDate <= dt2)
                    {
                        Console.WriteLine($"Employee name : {e.name}, Joining Date: {e.joinDate}");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            
        }

        /**************************************************
         * UPDATES THE DATA OF AN EMPLOYEE
         *************************************************/
        void UpdateData()
        {
            try
            {
                Console.WriteLine("Whose salary you want to update?");
                for (int i = 0; i < empList.Count; i++)
                {
                    Console.WriteLine($"[{i}->{empList[i].name}, Salary: {empList[i].salary}]");
                }
                Console.Write("Enter a choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                if (ch < 0 || ch > empList.Count - 1)
                {
                    Console.WriteLine("Invalid choice Number");
                    return;
                }

                Console.Write("Enter updated salary : ");
                double newsal = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter new position: ");
                string newpos = Console.ReadLine();

                empList[ch].salary = newsal;
                empList[ch].position = newpos;

                Console.WriteLine("\n Update list is...");
                ReadData();
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
