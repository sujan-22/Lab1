///I, Sujan Rokad, 000882948 certify that this material is my origianl work. No other person's work has been used without due acknowledgement.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{

    /// <summary>
    /// This program reads employee data from a CSV file, sorts it based on different criteria,
    /// and displays the sorted data in a table.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Employee array to store upto 100 employee data.
        /// </summary>
        private Employee[] employees = new Employee[100];

        /// <summary>
        /// variable to keep track of how many employee's data has been read from CSV file and stores it in an Employee array.
        /// </summary>
        private int employeeCount = 0;

        /// <summary>
        /// A method that is responsible for reading data from CSV file.
        /// </summary>
        /// <param name="filePath"></param>
        public void Read(string filePath)
        {
            try
            {
                using (StreamReader data = new StreamReader(filePath))
                {
                    string line;
                    while ((line = data.ReadLine()) != null)
                    {
                        // An array of string object that split each CSV file line with comma and stores it in employeeData array.
                        string[] employeeData = line.Split(',');

                        // If statement that checks if splitted data that stored in array has length of 4 and if it does then goes into if condition.
                        if (employeeData.Length == 4)
                        {
                            string name = employeeData[0].Trim(); // Extract the employee name from the first element of 'employeeData' array and stores it in 'name' variable
                            int number = int.Parse(employeeData[1].Trim()); // Parse the employee number from the second element of 'employeeData' array and store it as an integer
                            decimal rate = decimal.Parse(employeeData[2].Trim()); // Parse the employee pay rate from the third element of 'employeeData' array and store it as a decimal
                            double hours = double.Parse(employeeData[3].Trim()); // Parse the employee hours worked from the fourth element of 'employeeData' array and store it as a double

                            employees[employeeCount++] = new Employee(name, number, rate, hours); // Create a new Employee object with the parsed name, number, rate, and hours, then store it in the 'employees' array
                        }
                    }
                }
            }
            // catch block to handle an exception occurs during file reading or parsing
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file:");
                Console.WriteLine(e.Message); //display the specific error message
            }
        }

        /// <summary>
        /// SelectionSort algorithm for sorting employees by Employee Name (ascending)
        /// Reference to all SelecetionSort algorithms: https://code-maze.com/csharp-selection-sort/
        /// </summary>
        public void SelectionSortByName()
        {
            int n = employeeCount; // Initializes 'n' with the number of employees ('employeeCount') to be sorted

            // Outer loop that iterates through the array from the first element to the second-to-last element
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // Inner loop that iterates through the remaining unsorted employees starting from the next element of 'i'
                for (int j = i + 1; j < n; j++)
                {
                    // Compares employee names and updates 'minIndex' if a smaller name is found
                    if (string.Compare(employees[j].GetName(), employees[minIndex].GetName()) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Swap employees[i] and employees[minIndex]
                Employee temp = employees[i]; // Create a temporary variable 'temp' to hold the value of 'employees[i]'
                employees[i] = employees[minIndex]; // Assign the value of 'employees[minIndex]' (the smaller element) to 'employees[i]'
                employees[minIndex] = temp; // Assign the value of 'temp' (the original 'employees[i]') to 'employees[minIndex]'
            }
        }


        /// <summary>
        /// SelectionSort algorithm for sorting employees by Employee Number (ascending)
        /// </summary>
        public void SelectionSortByNumber()
        {
            int n = employeeCount; // Initializes 'n' with the number of employees ('employeeCount') to be sorted

            // Outer loop that iterates through the array from the first element to the second-to-last element
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // Inner loop that iterates through the remaining unsorted employees starting from the next element of 'i'
                for (int j = i + 1; j < n; j++)
                {

                    // Compare the employee numbers of two employees
                    // If the number of the current employee 'j' is less than the number of the employee at 'minIndex',
                    if (employees[j].GetNumber() < employees[minIndex].GetNumber())
                    {
                        // update 'minIndex' to point to the current employee 'j'
                        minIndex = j;
                    }
                }

                // Swap employees[i] and employees[minIndex]
                Employee temp = employees[i]; // Create a temporary variable 'temp' to hold the value of 'employees[i]'
                employees[i] = employees[minIndex]; // Assign the value of 'employees[minIndex]' (the smaller element) to 'employees[i]'
                employees[minIndex] = temp; // Assign the value of 'temp' (the original 'employees[i]') to 'employees[minIndex]'
            }
        }


        /// <summary>
        /// SelectionSort algorithm for sorting employees by Employee Pay Rate (descending)
        /// </summary>
        public void SelectionSortByRateDescending()
        {
            int n = employeeCount; // Initializes 'n' with the number of employees ('employeeCount') to be sorted

            // Outer loop that iterates through the array from the first element to the second-to-last element
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                // Inner loop that iterates through the remaining unsorted employees starting from the next element of 'i'
                for (int j = i + 1; j < n; j++)
                {

                    // Compare the pay rates of two employees
                    // If the pay rate of the current employee 'j' is greater than the pay rate of the employee at 'maxIndex',
                    if (employees[j].GetRate() > employees[maxIndex].GetRate())
                    {
                        maxIndex = j; // update 'maxIndex' to point to the current employee 'j'
                    }
                }

                // Swap employees[i] and employees[maxIndex]
                Employee temp = employees[i]; // Create a temporary variable 'temp' to hold the value of 'employees[i]'
                employees[i] = employees[maxIndex]; // Assign the value of 'employees[minIndex]' (the smaller element) to 'employees[i]'
                employees[maxIndex] = temp; // Assign the value of 'temp' (the original 'employees[i]') to 'employees[minIndex]'
            }
        }


        /// <summary>
        /// SelectionSort algorithm for sorting employees by Employee Hours (descending)
        /// </summary>
        public void SelectionSortByHoursDescending()
        {
            int n = employeeCount; // Initializes 'n' with the number of employees ('employeeCount') to be sorted

            // Outer loop that iterates through the array from the first element to the second-to-last element
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                // Inner loop that iterates through the remaining unsorted employees starting from the next element of 'i'
                for (int j = i + 1; j < n; j++)
                {

                    // Compare the hours of two employees
                    // If hour of the current employee 'j' is greater than hour of the employee at 'maxIndex',
                    if (employees[j].GetHours() > employees[maxIndex].GetHours())
                    {
                        maxIndex = j; // update 'maxIndex' to point to the current employee 'j'
                    }
                }

                // Swap employees[i] and employees[maxIndex]
                Employee temp = employees[i]; // Create a temporary variable 'temp' to hold the value of 'employees[i]'
                employees[i] = employees[maxIndex]; // Assign the value of 'employees[minIndex]' (the smaller element) to 'employees[i]'
                employees[maxIndex] = temp; // Assign the value of 'temp' (the original 'employees[i]') to 'employees[minIndex]'
            }
        }


        /// <summary>
        /// SelectionSort algorithm for sorting employees by Employee Gross Pay (descending)
        /// </summary>
        public void SelectionSortByGrossPayDescending()
        {
            int n = employeeCount; // Initializes 'n' with the number of employees ('employeeCount') to be sorted

            // Outer loop that iterates through the array from the first element to the second-to-last element
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;

                // Inner loop that iterates through the remaining unsorted employees starting from the next element of 'i'
                for (int j = i + 1; j < n; j++)
                {

                    // Compare the gross pay of two employees
                    // If the gross pay of the current employee 'j' is greater than the gross pay of the employee at 'maxIndex',
                    if (employees[j].GetGross() > employees[maxIndex].GetGross())
                    {
                        maxIndex = j; // update 'maxIndex' to point to the current employee 'j'
                    }
                }

                // Swap employees[i] and employees[maxIndex]
                Employee temp = employees[i]; // Create a temporary variable 'temp' to hold the value of 'employees[i]'
                employees[i] = employees[maxIndex]; // Assign the value of 'employees[minIndex]' (the smaller element) to 'employees[i]'
                employees[maxIndex] = temp; // Assign the value of 'temp' (the original 'employees[i]') to 'employees[minIndex]'
            }
        }

        /// <summary>
        /// Display the sorted employee data in a table
        /// </summary>
        public void DisplayTable()
        {
            // Display a horizontal line of '=' characters to separate the table visually
            Console.WriteLine(new string('=', 65));

            // Display the table header with column headers and formatting
            // Reference to below line: https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting
            Console.WriteLine($"| {"Name",-21} {"Number",-(int)9.5} {"Rate",-(int)9.5} {"Hours",-8} {"Gross Pay  | ",-(int)9.5}");

            // Display another horizontal line of '=' characters for clarity
            Console.WriteLine(new string('=', 65));

            // Loop through each employee in the sorted list
            for (int i = 0; i < employeeCount; i++)
            {
                // Display each employee's information in a row, including '|' alongside with first and last row
                Console.WriteLine($"| {employees[i]}  |");
            }

            // Display a final horizontal line of '=' characters to complete the table
            Console.WriteLine(new string('=', 65));
        }

        public static void Main(string[] args)
        {
            // Create an instance of the Program class
            Program lab = new Program();

            // Read employee data from the CSV file
            lab.Read("employees.txt");

            // Initialize a boolean variable to control program exit
            bool exit = false;

            // Display a menu to the user and handle their choice
            while (!exit)
            {
                // Define a formatted text menu with options
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

                // Display the menu to the user
                Console.Write(menu);

                // variable to store the user's choice
                int choice;

                // Attempt to read the user's choice from the console and convert into an integer
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    // Handle the user's choice based on the selected option
                    switch (choice)
                    {
                        // Sort employees by name in ascending order
                        case 1:
                            lab.SelectionSortByName();
                            lab.DisplayTable();
                            break;

                        // Sort employees by number in ascending order
                        case 2:
                            lab.SelectionSortByNumber();
                            lab.DisplayTable();
                            break;

                        // Sort employees by pay rate in descending order
                        case 3:
                            lab.SelectionSortByRateDescending();
                            lab.DisplayTable();
                            break;

                        // Sort employees by hours in descending order
                        case 4:
                            lab.SelectionSortByHoursDescending();
                            lab.DisplayTable();
                            break;

                        // Sort employees by gross pay in descending order
                        case 5:
                            lab.SelectionSortByGrossPayDescending();
                            lab.DisplayTable();
                            break;

                        // Set the 'exit' flag to true, exiting the program    
                        case 6:
                            exit = true;
                            Console.WriteLine("Ciao. "); // Goodbye message
                            Thread.Sleep(2000); // Waits for 2 seconds before exiting
                            break;

                        // Default case to display an error message for an invalid choice
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
