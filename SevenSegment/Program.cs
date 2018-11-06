using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSegment
{
    class Program
    {
        static void Main(string[] args)
        {
            var loop = true;

            do
            {
                Console.WriteLine("Please enter a number:");
                var input = Console.ReadLine();

                if (IsOnlyNumbers(input))
                {
                    string sevenSegRow1 = "";
                    string sevenSegRow2 = "";
                    string sevenSegRow3 = "";

                    foreach (var number in input)
                    {
                        switch (number)
                        {
                            case '0':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += "| |";
                                sevenSegRow3 += "|_|";
                                break;
                            case '1':
                                sevenSegRow1 += "   ";
                                sevenSegRow2 += " | ";
                                sevenSegRow3 += " | ";
                                break;
                            case '2':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += " _|";
                                sevenSegRow3 += "|_ ";
                                break;
                            case '3':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += " _|";
                                sevenSegRow3 += " _|";
                                break;
                            case '4':
                                sevenSegRow1 += "   ";
                                sevenSegRow2 += "|_|";
                                sevenSegRow3 += "  |";
                                break;
                            case '5':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += "|_ ";
                                sevenSegRow3 += " _|";
                                break;
                            case '6':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += "|_ ";
                                sevenSegRow3 += "|_|";
                                break;
                            case '7':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += "  |";
                                sevenSegRow3 += "  |";
                                break;
                            case '8':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += "|_|";
                                sevenSegRow3 += "|_|";
                                break;
                            case '9':
                                sevenSegRow1 += " _ ";
                                sevenSegRow2 += "|_|";
                                sevenSegRow3 += " _|";
                                break;
                        }
                    }

                    Console.WriteLine(sevenSegRow1);
                    Console.WriteLine(sevenSegRow2);
                    Console.WriteLine(sevenSegRow3);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Error: Non-number characters entered.");
                }

            } while (loop);
        }

        static bool IsOnlyNumbers(string testString)
        {
            return testString.All(c => c >= '0' && c <= '9');
        }
    }
}
