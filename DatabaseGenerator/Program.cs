using System;

namespace DatabaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            var myConnection = new DatabaseConnection();

            while (runProgram)
            {
                Console.WriteLine("Symulator SQL");
                Console.WriteLine("=============");

                try
                {
                    myConnection.ConnectToDatabase(true);

                    Console.WriteLine("Wybierz funkcję: ");
                    Console.WriteLine("1. Polecenie SELECT do bazy SQL");
                    Console.WriteLine("2. Wygeneruj rekordy do bazy SQL");
                    Console.WriteLine("3. Wyjdź z programu");
                    ConsoleKeyInfo input = Console.ReadKey();
                    Console.WriteLine("");

                    switch (input.KeyChar)
                    {
                        case '1':
                            var myTable = new DatabaseTable();
                            myTable.SelectQuery();
                            break;
                        case '2':
                            var myGenerator = new Generator();
                            myGenerator.Generate();
                            break;
                        case '3':
                            myConnection.DisconnectFromDatabase();
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Złe wprowadzenie.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                //Ask if run program again
                bool prompt = true;
                while (prompt)
                {
                    Console.Write("Czy chcesz uruchomić program ponownie? [T/N]");
                    ConsoleKeyInfo restartInput = Console.ReadKey();
                    Console.WriteLine();
                    switch (char.ToLower(restartInput.KeyChar))
                    {
                        case 't':
                            prompt = false;
                            runProgram = true;
                            Console.Clear();
                            break;
                        case 'n':
                            prompt = false;
                            runProgram = false;
                            break;
                        default:
                            prompt = true;
                            break;
                    }
                }
            }
            myConnection.DisconnectFromDatabase();
        }
    }
}
