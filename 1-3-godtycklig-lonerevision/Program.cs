using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_godtycklig_lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            //ange antal löner som ska matas in samt anropa metoden ReadInt.
            while (true)
            {
                int numberSalaries;

                numberSalaries = ReadInt("Ange antal löner att mata in: ");
                while (numberSalaries < 2)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste ange minst två löner för att kunna göra en beräkning! ");
                    Console.ResetColor();
                    numberSalaries = ReadInt("Ange antal löner att mata in: ");
                }
                
                Console.WriteLine();
                ProcessSalaries(numberSalaries);

                //Initiera ESC-knappen
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck valfri tangent för ny beräkning - ESC avslutar.");
                Console.ResetColor();
                Console.WriteLine();
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }                
            }
                        
         
        }

        static int ReadInt(string prompt)
        {
            //Fångar upp fel inläsning av antal löner.
            while (true)
            {
                Console.Write(prompt);
                string wrongFormat = Console.ReadLine();

                try
                {
                    return int.Parse(wrongFormat);
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! '{0}' kan inte tolkas som ett heltal!", wrongFormat);
                    Console.ResetColor();
                } 
            }
        }

        static void ProcessSalaries(int count)
        {
            //Skapa array
            int[] salary = new int[count];
            for (int i = 0; i < count; i++)
			{
                while (true)
                {
                    try
                    {
                        Console.Write("Ange lön nummer {0}: ", (i + 1));
                        salary[i] = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel format! ");
                        Console.ResetColor();
                        
                    }                    
                }
            }

            int[] copySalary = new int[count];
            Array.Copy(salary, copySalary, count);

            //Sortera lönerna.
            Array.Sort(salary);
           
            //Räkna och skriva ut lönerna.
            int spread = salary.Max() - salary.Min();
            int median = 0;
            int avarage = (int)salary.Average();

            if (count % 2 != 0)
            {
                median = salary[count / 2];
            }
            else
            {
                median = (salary[(count - 1) / 2] + salary[(count + 1) / 2]) / 2;
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Medianlön:       {0:c0}",median);
            Console.WriteLine("Medellön:        {0:c0}",avarage);
            Console.WriteLine("Lönespridning:   {0:c0}",spread);
            Console.WriteLine("------------------------");
            //Skriva ut lönerna i inmatat ordning
            for (int i = 0; i < copySalary.Length; i++)
            {
                Console.Write("{0,6}",copySalary[i]);
                if ((i % 3) == 2)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

    }
}
