using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    class Crypter
    {
        static readonly char[,] code1 =
        {
                { 'Q', 'A', 'Z', 'W', 'S' },
                { 'X', 'C', 'D', 'E', 'R' },
                { 'F', 'V', 'B', 'G', 'T' },
                { 'Y', 'H', 'N', 'M', 'U' },
                { 'I', 'K', 'L', 'O', 'P' }
        };
        static readonly char[,] code2 =
        {
                { 'Q', 'W', 'E', 'R', 'T' },
                { 'A', 'S', 'D', 'F', 'Z' },
                { 'P', 'O', 'I', 'U', 'Y' },
                { 'L', 'K', 'H', 'M', 'N' },
                { 'X', 'C', 'V', 'B', 'G' }
        };
        static readonly char[,] encode1 =
        {
                { 'P', 'L', 'M', 'K', 'O' },
                { 'I', 'N', 'U', 'H', 'B' },
                { 'Y', 'G', 'V', 'T', 'F' },
                { 'C', 'X', 'D', 'R', 'E' },
                { 'W', 'S', 'Q', 'A', 'Z' }
        };
        static readonly char[,] encode2 =
        {
                { 'A', 'Q', 'B', 'L', 'Z' },
                { 'S', 'D', 'C', 'F', 'X' },
                { 'P', 'V', 'W', 'R', 'N' },
                { 'M', 'Y', 'T', 'E', 'G' },
                { 'I', 'U', 'O', 'K', 'H' }
        };
        

        public static string decrypt(string value)
        {
            var result = new List<char> { };

            for (int i = 0; i < value.Length - 1; i++)
            {
                var a = CoordinatesOf(encode1, value[i]);
                i++;
                var b = CoordinatesOf(encode2, value[i]);

                result.Add(code1[a.Item1, b.Item2]);
                result.Add(code2[b.Item1,a.Item2]);
            }
            
            string Result = new string(result.ToArray());
            return Result;
        }

        public static string encrypt(string value)
        {
            var result = new List<char> { };

            for (int i = 0; i < value.Length - 1; i++)
            {
                var a = CoordinatesOf(code1, value[i]);
                i++;
                var b = CoordinatesOf(code2, value[i]);

                result.Add(encode1[a.Item1, b.Item2]);
                result.Add(encode2[b.Item1, a.Item2]);
            }

            string Result = new string(result.ToArray());
            return Result;
        }

        public static Tuple<int, int> CoordinatesOf(char[,] matrix, char value)
        {
            int w = 5; // width
            int h = w; // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}
