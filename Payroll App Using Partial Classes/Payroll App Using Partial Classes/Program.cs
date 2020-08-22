using System;
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
            //If your file is in a namespace folder [<namespace>.<folder>] do <folder>.<ClassName> like so...
            Partials.PartialStaff partialStaff = new Partials.PartialStaff("John"); // Just the basic class instance with a parameter for the name
            //Define Variables from the class
            //Define the fields
            string name = partialStaff.nameOfStaff;
            //Define the properties
            double hWorked = partialStaff.hWorked = 45;
            double wage = partialStaff.wage = 13.88;
            //Output the class info in the Console
            Console.WriteLine("{0} worked {1} hours for {2} an hour!", name, hWorked, wage);
            //Pause and wait for input
            Console.ReadKey();
            // Clear the screen
            Console.Clear();
            //Create the File from the info listed [it is formatted like this because I put the FileStream Code in the Constructor [For who knows what reason (but hey, it makes it easier to understand!)]
            Partials.PartialFileIO partialFile = new Partials.PartialFileIO("C:", name, wage, hWorked);
            // If it worked properly [which it does] it will output when the file is created.
            Console.WriteLine("File Created!");
            // Wait for a keypress
            Console.ReadKey();
            // Clear the screen
            Console.Clear();
            // Ask how many Employees the user has
            Console.WriteLine("How many employees do you have?");
            // Read for input, put it into an array, and convert it to an Int32 [default interger bit size]
            object[] readData = new object[25600];
            readData[0] = Console.ReadLine();
            // Clear the Screen
            Console.Clear();
            // Create an array of names, hours worked, and wages for each person and init it with the amount of employees.
            string[] names = new string[Convert.ToInt32(readData[0])];
            double[] hsWorked = new double[Convert.ToInt32(readData[0])];
            double[] wages = new double[Convert.ToInt32(readData[0])];
            //Set the base values assigned by default [John]
            names[0] = name;
            hsWorked[0] = hWorked;
            wages[0] = wage;
            int count = 0;
            // Make the questions loop until the end of the array.
            while (names.Length <= Convert.ToInt32(readData[0]))
            {
                // Notify the user of something important!
                Console.WriteLine("THIS WILL LOOP UNTIL ALL EMPLOYEES ARE ACCOUNTED FOR!");
                // Pause and wait for a keypress
                Console.ReadKey();
                // Clear the screen
                Console.Clear();
                // Ask the questions and Read the Input
                Console.WriteLine("What is the employee's name?");
                readData[1] = Console.ReadLine();
                Console.WriteLine("What is {0} wage?", readData[1]);
                double wageContent = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("How many hours did {0} work?", readData[1]);
                double hoursContent = Convert.ToDouble(Console.ReadLine());
                // Clear the Screen
                Console.Clear();
                // Output what they typed
                Console.WriteLine("Name: {0}; Wage: {1}; Hours Worked: {2};", readData[1], wageContent, hoursContent);
                // Wait for a keypress
                Console.ReadKey();
                // Increment the count
                count++;
                Console.WriteLine(count);
                Console.ReadKey();
                // Set the arrays to the correct value using the count.
                names[count] = readData[1].ToString();
                wages[count] = wageContent;
                hsWorked[count] = hoursContent;
                //Clear the screen before restarting the loop
                Console.Clear();
                // Loop through all the entries in the arrays
                for (int i = 0; i < names.Length; i++)
                {
                    // Output all the data to the Console
                    Console.WriteLine(names[i]);
                    Console.WriteLine(wages[i]);
                    Console.WriteLine(hsWorked[i]);
                    // Create a new staff with the information
                    Partials.PartialStaff staff = new Partials.PartialStaff(names[i]);
                    // Although this is pretty much unesscessary I find it good habit to fill out information [even if it makes it a fraction of a second slower] so it does not return null [if it returns anything].
                    staff.hWorked = hsWorked[i];
                    staff.wage = wages[i];
                    // Create a new instance of PartialFileIO in order to save the file(s) in the save place.
                    Partials.PartialFileIO fileIO = new Partials.PartialFileIO("C:", names[i], wages[i], hsWorked[i]);
                    // Make sure the user knows where to look for the save file [and that it was saved]
                    Console.WriteLine("Employee Data Saved To: C:/Names/" + names[i].ToString() + "/" + names[i].ToString() + ".txt");
                    // Make a new line befrore ending with this index
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Press any key to continue");
                Console.WriteLine("Press 'q' to quit");
                string ynq = Console.ReadLine();
                if (ynq == "q" || ynq == "Q")
                    break;
                Console.Clear();
            }

        }
    }
}
