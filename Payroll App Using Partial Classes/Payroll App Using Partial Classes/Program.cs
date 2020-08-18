﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_App_Using_Partial_Classes
{
    // The ONLY class that can output stuff to cmd is this class
    class Program
    {
        // Auto-Generated Method used for initialization.
        static void Main(string[] args)
        {
            // First make sure that the Partial Classes are in the same PROJECT [NOT Solution] folder.
            //To create a new class...
            //Go Right-Click on the Project—>add—>New Item—>Class
            //Name It whatever you want.
            // Instantiate the partial classes.
            PartialStaff partialStaff = new PartialStaff("John"); // Just the basic class instance with a parameter for the name
            //Define Variables from the class
            //Define the fields
            string name = partialStaff.nameOfStaff;
            //Define the properties
            double hWorked = partialStaff.hWorked = 45;
            double wage = partialStaff.wage = 13.88;
            Console.WriteLine("{0} worked {1} hours for {2} an hour!", name, hWorked, wage);
            Console.ReadLine();
        }
    }
}