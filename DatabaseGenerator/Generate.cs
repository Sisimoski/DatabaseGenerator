using System;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseGenerator
{
    public class Generate : DatabaseHandler
    {
        public Generate()
        {
        }

        public void Fill()
        {

            Console.WriteLine("Dostępne tabele: ");

            int index = 0;
            foreach(string item in DatabaseTable.TableList)
            {
                index++;
                Console.WriteLine($"#{index}: {item}");
            }
            Console.Write("Wybierz tabelę do której chcesz wykonać INSERT: ");
            index = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wprowadź ilość wierszy do INSERT: ");
        }
    }
}
