//I, Sujan Rokad, 000882948 certify that this material is my origianl work. No other person's work has been used without due acknowledgement.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{

    public class Program
    {
        // Employee array to store upto 100 employee data.
        private Employee[] employees = new Employee[100];

        //variable to keep track of how many employee's data has been read from CSV file and stores it in an Employee array.
        private int employeeCount = 0;

        //A method that is responsible for reading data from CSV file.
        public void Read(string filePath)
        {
            try
            {
                using (StreamReader data = new StreamReader(filePath))
                {
                    string line;
                    while ((line = data.ReadLine()) != null)
                    {
                        //An array of string object that split each CSV file line with comma and stores it in employeeData array.
                        string[] employeeData = line.Split(',');
                        
                        //If statement that checks if splitted data that stored in array has length of 4 and if it does then goes into if condition.
                        if (employeeData.Length == 4)
                        {
                            string name = employeeData[0].Trim();
                            int number = int.Parse(employeeData[1].Trim());
                            decimal rate = decimal.Parse(employeeData[2].Trim());
                            double hours = double.Parse(employeeData[3].Trim());

                            employees[employeeCount++] = new Employee(name, number, rate, hours);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file:");
                Console.WriteLine(e.Message);
            }
        }

        public void SelectionSortByName()
        {
            int n = employeeCount;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (string.Compare(employees[j].GetName(), employees[minIndex].GetName()) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Swap employees[i] and employees[minIndex]
                Employee temp = employees[i];
                employees[i] = employees[minIndex];
                employees[minIndex] = temp;
            }
        }


        // QuickSort algorithm for sorting employees by Employee Number (ascending)
        public void SelectionSortByNumber()
        {
            int n = employeeCount;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (employees[j].GetNumber() < employees[minIndex].GetNumber())
                    {
                        minIndex = j;
                    }
                }

                // Swap employees[i] and employees[minIndex]
                Employee temp = employees[i];
                employees[i] = employees[minIndex];
                employees[minIndex] = temp;
            }
        }


        // QuickSort algorithm for sorting employees by Employee Pay Rate (descending)
        public void SelectionSortByRateDescending()
        {
            int n = employeeCount;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (employees[j].GetRate() > employees[maxIndex].GetRate())
                    {
                        maxIndex = j;
                    }
                }

                // Swap employees[i] and employees[maxIndex]
                Employee temp = employees[i];
                employees[i] = employees[maxIndex];
                employees[maxIndex] = temp;
            }
        }


        // QuickSort algorithm for sorting employees by Employee Hours (descending)
        public void SelectionSortByHoursDescending()
        {
            int n = employeeCount;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (employees[j].GetHours() > employees[maxIndex].GetHours())
                    {
                        maxIndex = j;
                    }
                }

                // Swap employees[i] and employees[maxIndex]
                Employee temp = employees[i];
                employees[i] = employees[maxIndex];
                employees[maxIndex] = temp;
            }
        }


        // QuickSort algorithm for sorting employees by Employee Gross Pay (descending)
        public void SelectionSortByGrossPayDescending()
        {
            int n = employeeCount;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (employees[j].GetGross() > employees[maxIndex].GetGross())
                    {
                        maxIndex = j;
                    }
                }

                // Swap employees[i] and employees[maxIndex]
                Employee temp = employees[i];
                employees[i] = employees[maxIndex];
                employees[maxIndex] = temp;
            }
        }


        private void Swap(int i, int j)
        {
            Employee temp = employees[i];
            employees[i] = employees[j];
            employees[j] = temp;
        }

        // Display the sorted employee data in a table
        public void DisplayTable()
        {
            Console.WriteLine(new string('=', 65));
            Console.WriteLine($"  {"Name",-21} {"Number",-(int)9.5} {"Rate",-(int)9.5} {"Hours",-8} {"Gross Pay",-(int)9.5}");
            Console.WriteLine(new string('=', 65));

            for (int i = 0; i < employeeCount; i++)
            {
                Console.WriteLine($"| {employees[i]}  |");
            }
            Console.WriteLine(new string('=', 65));
        }

        public static void Main(string[] args)
        {
            Program lab = new Program();

            // Read employee data from the CSV file
            lab.Read("employees.txt");

            bool exit = false;

            while (!exit)
            {
                string menu =
$@"
------------------------------------------|
Choose any from below options             |
------------------------------------------|
1) Sort by Employee Name (ascending)      |
2) Sort by Employee Number (ascending)    |  
3) Sort by Employee Pay Rate (descending) |
4) Sort by Employee Hours (descending)    |
5) Sort by Employee Gross Pay (descending)|
6) Exit                                   |
------------------------------------------|
Enter your choice: ";                       
                Console.Write(menu);
                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            lab.SelectionSortByName();
                            //lab.QuickSortByName(0, lab.employeeCount - 1);
                            lab.DisplayTable();
                            break;
                        case 2:
                            lab.SelectionSortByNumber();
                            lab.DisplayTable();
                            break;

                        case 3:
                            lab.SelectionSortByRateDescending();
                            lab.DisplayTable();
                            break;

                        case 4:
                            lab.SelectionSortByHoursDescending();
                            lab.DisplayTable();
                            break;

                        case 5:
                            lab.SelectionSortByGrossPayDescending();
                            lab.DisplayTable();
                            break;
                        case 6:
                            exit = true;
                            Console.WriteLine("Ciao. ");
                            Thread.Sleep(2000);
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }
    }

}
