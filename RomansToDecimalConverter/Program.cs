using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomansToDecimalConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter converter = new Converter();
            string st;
            Console.WriteLine("Enter number in Rome number system (<=3000).");
            Console.Write("With using 'I' 'V' 'X' 'L' 'C' 'D' 'M':");
            //st = "VI";
            st =Console.ReadLine();

            Console.WriteLine(converter.Output(st));
            Console.ReadKey();
        }
    }
}
