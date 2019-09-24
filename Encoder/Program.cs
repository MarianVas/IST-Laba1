using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            Console.WriteLine(Crypter.encode(value));
            Console.ReadKey();
        }
    }
}
