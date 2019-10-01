using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    class Program
    {
        static void Main()
        {
            bool temp = true;
            string value = null;
            
            while (temp)
            {
                ConsoleKeyInfo input;

                Console.Clear();
                Console.WriteLine("If you want to encrypt your message that press 1, if decrypt - press 2, other to close:");
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        value = MenuGetValue();
                        Console.WriteLine("Result is: \n" + Crypter.encrypt(value));
                        break;
                    case ConsoleKey.D2:
                        value = MenuGetValue();
                        Console.WriteLine("Result is: \n" + Crypter.decrypt(value));
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            }
        }

        static string MenuGetValue()
        {
            string value;

            Console.Clear();
            Console.WriteLine("Enter your word:");
            value = Console.ReadLine();
            return value;
        }
    }
}
