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
        // Employee array to store employee data
        private Employee[] employees = new Employee[100];
        private int employeeCount = 0;

        // Read employee data from CSV file
        public void Read(string filePath)
        {
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader data = new StreamReader(file))
                {
                    string line;
                    while ((line = data.ReadLine()) != null)
                    {
                        string[] employeeData = line.Split(',');
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
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        // Implement QuickSort algorithm for sorting employees by name
        private void QuickSortByName(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionByName(left, right);
                QuickSortByName(left, pivotIndex - 1);
                QuickSortByName(pivotIndex + 1, right);
            }
        }

        private int PartitionByName(int left, int right)
        {
            string pivot = employees[right].GetName();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (string.Compare(employees[j].GetName(), pivot) < 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, right);
            return i + 1;
        }

        // QuickSort algorithm for sorting employees by Employee Number (ascending)
        public void QuickSortByNumber(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionByNumber(left, right);
                QuickSortByNumber(left, pivotIndex - 1);
                QuickSortByNumber(pivotIndex + 1, right);
            }
        }

        private int PartitionByNumber(int left, int right)
        {
            int pivot = employees[right].GetNumber();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (employees[j].GetNumber() < pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, right);
            return i + 1;
        }

        // QuickSort algorithm for sorting employees by Employee Pay Rate (descending)
        public void QuickSortByRateDescending(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionByRateDescending(left, right);
                QuickSortByRateDescending(left, pivotIndex - 1);
                QuickSortByRateDescending(pivotIndex + 1, right);
            }
        }

        private int PartitionByRateDescending(int left, int right)
        {
            decimal pivot = employees[right].GetRate();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (employees[j].GetRate() > pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, right);
            return i + 1;
        }

        // QuickSort algorithm for sorting employees by Employee Hours (descending)
        public void QuickSortByHoursDescending(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionByHoursDescending(left, right);
                QuickSortByHoursDescending(left, pivotIndex - 1);
                QuickSortByHoursDescending(pivotIndex + 1, right);
            }
        }

        private int PartitionByHoursDescending(int left, int right)
        {
            double pivot = employees[right].GetHours();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (employees[j].GetHours() > pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, right);
            return i + 1;
        }

        // QuickSort algorithm for sorting employees by Employee Gross Pay (descending)
        public void QuickSortByGrossPayDescending(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionByGrossPayDescending(left, right);
                QuickSortByGrossPayDescending(left, pivotIndex - 1);
                QuickSortByGrossPayDescending(pivotIndex + 1, right);
            }
        }

        private int PartitionByGrossPayDescending(int left, int right)
        {
            decimal pivot = employees[right].GetGross();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (employees[j].GetGross() > pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, right);
            return i + 1;
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
            Console.WriteLine($"{"Name|",-20} {"Number|",-10} {"Rate|",-10} {"Hours|",-10} {"Gross Pay|",-10}");
            Console.WriteLine(new string('=', 65));

            for (int i = 0; i < employeeCount; i++)
            {
                Console.WriteLine($"|{employees[i]}|");
            }
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
Please select any
------------------------------------------
1. Sort by Employee Name (ascending)
2. Sort by Employee Number (ascending)
3. Sort by Employee Pay Rate (descending)
4. Sort by Employee Hours (descending)
5. Sort by Employee Gross Pay (descending)
6. Exit
Enter your choice: ";
                Console.WriteLine(menu);
                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            lab.QuickSortByName(0, lab.employeeCount - 1);
                            lab.DisplayTable();
                            break;
                        case 2:
                            lab.QuickSortByNumber(0, lab.employeeCount - 1);
                            lab.DisplayTable();
                            break;

                        case 3:
                            lab.QuickSortByRateDescending(0, lab.employeeCount - 1);
                            lab.DisplayTable();
                            break;

                        case 4:
                            lab.QuickSortByHoursDescending(0, lab.employeeCount - 1);
                            lab.DisplayTable();
                            break;

                        case 5:
                            lab.QuickSortByGrossPayDescending(0, lab.employeeCount - 1);
                            lab.DisplayTable();
                            break;

                        // Implement other sorting options here

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
