using System;
using System.Collections.Generic;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            string nl;
            Func<string, string, string> concatFirstAndLastName = (Nome, Cognome) => nl = $"{Nome} {Cognome}";
            var nome = concatFirstAndLastName("Mario", "Rossi");
            Console.WriteLine(nome);

            //es 2
            Func<int, int, int, int> getMaximum = (a, b, c) =>
            {
                int max = a;
                if (b > max) 
                {
                    max = b; 
                } else if (c > max)
                {
                    max = c; 
                };
                return max;
            };

            getMaximum(1, 2, 3);



        //es3
            DateTime date1 = new DateTime(2019, 02, 02);
            DateTime date2 = new DateTime(2020, 01, 01);
            Action<DateTime, DateTime> printMin = (date1, date2) =>
            {
                if (date1 < date2)
                {
                    Console.WriteLine(date1);
                }
                else
                {
                    Console.WriteLine(date2);
                }
            };

            printMin(date1, date2);
        }
    }
}
