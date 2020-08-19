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
            path2 = path + "/Names" + "/" + name + "/" + name + ".txt";
            // Delete the file if it exists.
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }

            //Create the file.
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                AddText(fs, name);
                AddText(fs, "\n——————————————————————————————\n");
                AddText(fs, "Date: " + DateTime.Today.Date);
                AddText(fs, "\nPay: " + CalculatePay(wage, hWorked).ToString());

                for (int i = 1; i < 120; i++)
                {
                    AddText(fs, Convert.ToChar(i).ToString());
                }
            }
            //Log Info
            Console.WriteLine("FileWrite Completed!");
            Console.ReadKey();
            Console.Clear();
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
