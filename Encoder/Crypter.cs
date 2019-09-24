using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    class Crypter
    {
        static char[,] code1 =
        {
                { 'Q', 'A', 'Z', 'W', 'S' },
                { 'X', 'C', 'D', 'E', 'R' },
                { 'F', 'V', 'B', 'G', 'T' },
                { 'Y', 'H', 'N', 'M', 'U' },
                { 'I', 'K', 'L', 'O', 'P' }
        };
        static char[,] code2 =
        {
                { 'Q', 'W', 'E', 'R', 'T' },
                { 'A', 'S', 'D', 'F', 'Z' },
                { 'P', 'O', 'I', 'U', 'Y' },
                { 'L', 'K', 'H', 'M', 'N' },
                { 'X', 'C', 'V', 'B', 'G' }
        };
        static char[,] encode1 =
        {
                { 'P', 'L', 'M', 'K', 'O' },
                { 'I', 'N', 'U', 'H', 'B' },
                { 'Y', 'G', 'V', 'T', 'F' },
                { 'C', 'X', 'D', 'R', 'E' },
                { 'W', 'S', 'Q', 'A', 'Z' }
        };
        static char[,] encode2 =
        {
                { 'A', 'Q', 'B', 'L', 'Z' },
                { 'S', 'D', 'C', 'F', 'X' },
                { 'P', 'V', 'W', 'R', 'N' },
                { 'M', 'Y', 'T', 'E', 'G' },
                { 'I', 'U', 'O', 'K', 'H' }
        };
        
        public static string encode(string value)
        {
            int rows = code1.GetUpperBound(0) + 1;
            int columns = code1.Length / rows;
            var result = new List<char> { };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int c = 0;
                    if (value[c++] == code1[i, j])
                    {
                            for (int a = 0; a < rows; a++)
                            {
                                for (int b = 0; b < columns; b++)
                                {
                                    if (c < value.Length - 2)
                                    {
                                        if (value[c++] == code2[a, b])
                                        {
                                            result.Add(encode1[j, a]);
                                            result.Add(encode2[i, b]);
                                        }
                                    }

                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                    }
                }
            }
            string Result = new string(result.ToArray());
            return Result;
        }
    }
}
