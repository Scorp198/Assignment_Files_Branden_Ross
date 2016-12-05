using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAssignment
{
    class Employee
    {
        // private module variables
        private string employeeName;
        private int employeeNumber;
        private int hoursWorked;
        private double weeklyPay;

        // constants 
        const int WorkingLimit = 40;
        const double rate = 10.50;


        private Employee ()
        {

        }

        private Employee(string employeeName, int employeeNumber, int hoursWorked, double weeklyPay)
        {
            this.EmployeeName = employeeName;
            this.EmployeeNumber = employeeNumber;
            this.HoursWorked = hoursWorked;
            this.WeeklyPay = weeklyPay;
        }

        // get and sets for employee name
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                this.employeeName = value;
            }
        } // end of get and set for employee  number

        public int EmployeeNumber
        {
            get
            {
                return employeeNumber;
            }
            set
            {
                this.employeeNumber = value;
            }
        }// end of get and set for employee Number

        // get and set for hours worked
        public int HoursWorked
        {
            get
            {
                return hoursWorked;
            }
            set
            {
                if(hoursWorked>40)
                {
                    throw new ArgumentException("An employee can not work more than 40 hours a week!");
                }
                this.hoursWorked = value;
            }
        }// end of get and sets for hours worked

        // start of get and set for weeklypay
        public double WeeklyPay
        {
            get
            {
                return weeklyPay;
            }
            set
            {
                this.weeklyPay = value;
            }
        }// end of get and set for weekly pay

        public double calculatePay()
        {
            double pay;
            pay = rate * hoursWorked;
            return pay;
        }

        public string GetDisplayText()
        {
            // string c = Code; //using the get
            return EmployeeName + ", " + EmployeeNumber + ", " + HoursWorked.ToString()+", "+ WeeklyPay.ToString("c");
        }
    }


    
}
