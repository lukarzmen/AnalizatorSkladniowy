using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizatorSkladniowy
{
    class Program
    {
        static void Main(string[] args)
        {
            var ciag = "2+2.2;";
            AnalizatorSkladniowy analizatorSkladniowy = new AnalizatorSkladniowy(ciag);
            try
            {
                analizatorSkladniowy.Analizuj();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ciag niepoprawny");
            }
        }
    }
}
