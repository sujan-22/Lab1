//I, Sujan Rokad, 000882948 certify that this material is my origianl work. No other person's work has been used without due acknowledgement.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Employee
    {
        // instance variables to store employee information
        private string name; // Employee name
        private int number; // Employee number
        private decimal rate; // Employee pay rate
        private double hours; // Employee hours

        // Constructor to initialize employee information
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        // GetGross method to calculate gross pay
        public decimal GetGross()
        {
            // Calculate gross pay with overtime
            if (hours > 40)
            {
                double regularHours = 40;
                double overtimeHours = hours - regularHours;
                return (decimal)((regularHours * (double)rate) + (overtimeHours * (double)rate * 1.5));
            }
            else
            {
                return (decimal)(hours * (double)rate);
            }
        }

        // GetHours method to retrieve the hours worked by the employee
        public double GetHours()
        {
            return hours;
        }

        // GetName method to retrieve the name of the employee
        public string GetName()
        {
            return name;
        }

        // GetNumber method to retrieve the employee number
        public int GetNumber()
        {
            return number;
        }

        // GetRate method to retrieve the pay rate of the employee
        public decimal GetRate()
        {
            return rate;
        }

        // SetHours method to update the hours worked by the employee
        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        // SetName method to update the name of the employee
        public void Setname(string name)
        {
            this.name = name;
        }

        // SetNumber method to update the employee number
        public void SetNumber(int number)
        {
            this.number = number;
        }

        // SetRate method to update the pay rate of the employee
        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }

        // ToString method to format the employee information as a string
        public override string ToString()
        {
            return $"{name,-21} {number,-(int)9.5} {rate,-(int)9.5:C} {hours,-8:F2} {GetGross(),-(int)9.5:C}";
        }
    }

}

