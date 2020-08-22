using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Payroll_App_Using_Partial_Classes.Partials
{
    class PartialFileIO
    {
        public string path2;
        public PartialFileIO(string path, string name, double wage, double hWorked)
        {
            //Redfine the path2 so the variable is to the savefile location
            path2 = path + "/Names" + "/" + name + "/" + name + ".txt";
            //Define path3 so the variable is set to the directory of the savefile [you'll see why soon]
            string path3 = path + "/Names" + "/" + name + "/";
            // Delete the file if it exists.
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }

            //Create the directory for the file
            //Note: If you Don't do this step it will not work properly.
            Directory.CreateDirectory(Path.GetDirectoryName(path3));

            //Create the file.
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                AddText(fs, name);
                AddText(fs, "\n——————————————————————————————\n");
                AddText(fs, "Date: " + DateTime.Today.Date);
                AddText(fs, "\nPay: " + CalculatePay(wage, hWorked).ToString());
            }
        }

        public double CalculatePay(double wage, double hWorked)
        {
            double value = wage * hWorked;
            return value;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
 }
