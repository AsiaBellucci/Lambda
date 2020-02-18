using System;
using System.Collections.Generic;
using System.Linq;

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

            #region ESERCIZI LINQ
            List<Apple> apples = new List<Apple> {
            new Apple { Color = "Red", Weight = 180, Variety = "Stark Delicious", Origin = "Italy"},
            new Apple { Color = "Green", Weight = 195, Variety = "Granny Smith", Origin = "Spain" },
            new Apple { Color = "Red", Weight = 190, Variety = "Stark Delicious", Origin = "France" },
            new Apple { Color = "Green", Weight = 185, Variety = "Granny Smith", Origin = "Italy" },
            new Apple { Color ="Yellow", Weight = 190, Variety = "Golden Delicious", Origin = "Spain"},
            new Apple { Color ="Yellow", Weight = 175, Variety = "Golden Delicious", Origin = "France"},
            new Apple { Color ="Red", Weight = 190, Variety = "Stark Delicious", Origin = "Italy" }
            };

            Console.WriteLine("-------------------------------------------------------------");
            //1 mela che pesa meno
            double min = apples.Select(apple => apple.Weight).Min();
            Console.WriteLine($"La mela che pesa meno è: {min}");


            //2 di che colore è la mela che pesa 190 grammi?
            IEnumerable<string> mela = apples.Where(apple => apple.Weight == 190).Select(apple => apple.Color);
            Console.WriteLine($"prima mela: {mela.First()}");

            //3tot mele rosse
            int numRosse = apples.Where(apple => apple.Color == "Red").Count();
            Console.WriteLine($"Tot mele rosse: {numRosse}");
            

            //4tot peso mele verdi
            int weightGreen = apples.Where(apple => apple.Color == "Green").Select(apple => apple.Weight).Sum();
            Console.WriteLine($"Tot peso delle mele verdi: {weightGreen}");
            Console.WriteLine("-------------------------------------------------------------");
            #endregion

            #region CODICE SLIDE E MIO
            //tot peso delle mele rosse-------------------------------------------------------------------------------------------------------------------------------------mio da slide
            int weightOfRedApples = apples.Where(apple => apple.Color == "Red").Select(apple => apple.Weight).Sum();
            Console.WriteLine($"Tot peso delle mele verdi: {weightOfRedApples}");
            Console.WriteLine("////////////////////////////////////////////////////////");

            //Seleziono solo le mele rosse e ne ottengo il peso, notare che ritorno una lista di int-------------------------------------------------------------------------mio da slide
            IEnumerable<int> weightsOfRedApples = apples.Where(apple => apple.Color == "Red").Select(apple => apple.Weight);
            foreach (int value in weightsOfRedApples)
            {
                Console.WriteLine($"Peso mela rossa: {value}");
            }

            double average = weightsOfRedApples.Average();
            Console.WriteLine($"Media peso mele rosse: {average}");
            Console.WriteLine("////////////////////////////////////////////////////////");

            //Ottengo solo le mele rosse
            IEnumerable<Apple> takeRedApples = apples.Where(apple => apple.Color == "Red");
            Console.WriteLine(takeRedApples);

            //di che colore sono le mele che pesa 190 grammi?-------------------------------------------------------------------------------------------------------mio
            IEnumerable<string> mela190 = apples.Where(apple => apple.Weight == 190).Select(apple => apple.Color);
            Display(mela190);

            static void Display(IEnumerable<string> argument)
            {
                foreach (string value in argument)
                {
                    Console.WriteLine($"mela che pesa 190 grammi è   {value}");
                }
                Console.WriteLine("////////////////////////////////////////////////////////");
            }

            //Media peso mele italiane
            double AvgWeightIta = apples.Where(apple => apple.Origin == "Italy").Select(apple => apple.Weight).Average();
            Console.WriteLine($"Peso medio mele italiane: {AvgWeightIta}");

            //Peso mele italia ordinate
            IEnumerable<int> PesoMeleIta = apples.Where(apple=>apple.Origin=="Italy").OrderBy(apple => apple.Origin).Select(apple => apple.Weight);
            foreach(int a in PesoMeleIta)
            {
                Console.WriteLine($"Mela italia: {a}");

            }

            //Quante------- mele per paese
            IEnumerable<IGrouping<string, Apple>> groups = apples.GroupBy(apple => apple.Origin);
            

            foreach (IGrouping<string, Apple> OriginGroup in groups)
            {
                Console.WriteLine("Origin Group: {0}", OriginGroup.Key);  //Each group has a key 

                foreach (Apple s in OriginGroup)  //Each group has a inner collection  
                    Console.WriteLine("Peso Mele: {0}", s.Weight);
            }
                #endregion



                #region ESERCIZI CASA
                Console.WriteLine("*******************Esercizi casa*******************************");
            ////es4 formattazione
            //Action<string, string> PrintFormat = (s1, s2) =>
            //{
            //    string s = "Prova {0},{1}.";
            //    string msg = string.Format(s, s1, s2);
            //    Console.WriteLine(msg);

            //};
            //string primo=  "Posto0"; 
            //string secondo= "Posto1";
            //PrintFormat(primo, secondo);

            ////es5 SWAP n.5
            ////Action<int, int> PrintSwap = (num1, num2) =>
            ////{
            ////    Console.WriteLine($"Primo numero: {num2}");
            ////    Console.WriteLine($"Seconndo numero: {num1}");
            ////};
            ////Console.WriteLine("Inserisci primo numero: ");
            ////string Primo = Console.ReadLine();
            ////int n1 = Convert.ToInt32(Primo);
            ////Console.WriteLine("Inserisci secondo numero: ");
            ////string Secondo = Console.ReadLine();
            ////int n2 = Convert.ToInt32(Secondo);
            ////PrintSwap(n1, n2);

            ////es6 Positivo negativo n.18

            //Console.WriteLine("Inserisci primo numero: ");
            //int num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Inserisci secondo numero: ");
            //int num2 = Convert.ToInt32(Console.ReadLine());
            //if (num1 < 0 && num2 < 0)
            //    Console.WriteLine("Negativo");
            //else if (num1 > 0 && num2 > 0)
            //    Console.WriteLine("Positivo");

            ////es7 media n.9
            //Console.WriteLine("Inserisci primo numero: ");
            //int m1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Inserisci secondo numero: ");
            //int m2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Inserisci primo numero: ");
            //int m3 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Inserisci secondo numero: ");
            //int m4 = Convert.ToInt32(Console.ReadLine());
            //List<int> lista = new List<int>();
            #endregion


        }
    }
}
