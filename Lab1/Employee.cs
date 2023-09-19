using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Employee
    {
        // Private fields to store employee information
        private string name;
        private int number;
        private decimal rate;
        private double hours;

        // Constructor to initialize employee information
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        // Getter methods
        public decimal GetGross()
        {
            // Calculate gross pay with overtime
            if (hours > 40)
            {
                double regularHours = 40;
                double overtimeHours = hours - 40;
                return (decimal)((regularHours * (double)rate) + (overtimeHours * (double)rate * 1.5));
            }
            else
            {
                return (decimal)(hours * (double)rate);
            }
        }

        public double GetHours()
        {
            return hours;
        }

        public string GetName()
        {
            return name;
        }

        public int GetNumber()
        {
            return number;
        }

        public decimal GetRate()
        {
            return rate;
        }

        // Setter methods
        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }

        // ToString method to format employee information
        public override string ToString()
        {
            return $"{name,-20} {number,-10} {rate,-10:C} {hours,-10:F2} {GetGross(),-10:C}";
        }
    }

}

