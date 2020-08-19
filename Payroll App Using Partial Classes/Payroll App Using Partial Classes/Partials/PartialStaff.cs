using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_App_Using_Partial_Classes.Partials
{
    // Make sure this is a public partial class and not a normal class!
    // And make sure to keep the 'Partial' [without the ticks] in the class name (you only need to do this if you're not using visual studio community)
    public partial class PartialStaff
    {
        // Fields
        public static int index;
        private int count = index;
        public string nameOfStaff;

        // Properties
        public double wage { get; set; }
        public double hWorked { get; set; }

        // Constructor
        public PartialStaff (string name)
        {
            nameOfStaff = name;
        }
    }
}
