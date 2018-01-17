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

            var przykladowyCiag = "(1.2*3)+5-(23.4+3)^3; 8:13;";
            Console.WriteLine("Analizuje przykladowy ciag: " + przykladowyCiag);
            AnalizatorSkladniowy analizatorSkladniowy = new AnalizatorSkladniowy(przykladowyCiag);
            try
            {
                analizatorSkladniowy.Analizuj();
                Console.WriteLine("Ciąg poprawny");
            }
            catch(Exception e)
            {
                Console.WriteLine("Ciag niepoprawny");
            }

            Console.WriteLine();
            while(true)
            {
                Console.Write("Podaj ciag do analizy: ");
                var ciagDoAnalizy = Console.ReadLine().Trim() ;
                analizatorSkladniowy = new AnalizatorSkladniowy(ciagDoAnalizy);
                try
                {
                    analizatorSkladniowy.Analizuj();
                    Console.WriteLine("Ciąg poprawny");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ciag niepoprawny");
                }
                Console.ReadKey();
            }

        }
    }
}
