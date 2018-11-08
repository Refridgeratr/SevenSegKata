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
                Console.WriteLine("Please enter some numbers:");
                var inputNumber = Console.ReadLine();

                Console.WriteLine("Number height:");
                var inputHeightValid = int.TryParse(Console.ReadLine(), out var inputHeight);

                Console.WriteLine("Number width:");
                var inputWidthValid = int.TryParse(Console.ReadLine(), out var inputWidth);

                if (IsOnlyNumbers(inputNumber) && inputNumber != null && inputHeightValid && inputWidthValid)
                {
                    //char[,] sevenSegDisplay;
                    var sevenSegStrings = new List<string>();

                    foreach (var number in inputNumber)
                    {
                        var numberStrings = GetBigNumberStrings(number, inputHeight, inputWidth);

                        if (sevenSegStrings.Count == 0) // initialize string container, but only once
                        {
                            for (var i = 0; i < numberStrings.Count; i++)
                            {
                                sevenSegStrings.Add("");
                            }
                        }

                        for (var i = 0; i < numberStrings.Count ; i++) // append number pieces to each string
                        {
                            sevenSegStrings[i] += numberStrings[i];
                        }
                    }

                    foreach (var numberString in sevenSegStrings) // print out all the numbers!
                    {
                        Console.WriteLine(numberString);
                    }

                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Error: Non-number characters entered.");
                }

            } while (loop);
        }

        public static bool IsOnlyNumbers(string testString)
        {
            return testString.All(c => c >= '0' && c <= '9');
        }

        public static List<string> GetNumberStrings(char number)
        {
            var row1 = "";
            var row2 = "";
            var row3 = "";

            switch (number)
            {
                case '0':
                    row1 += " _ ";
                    row2 += "| |";
                    row3 += "|_|";
                    break;
                case '1':
                    row1 += "   ";
                    row2 += " | ";
                    row3 += " | ";
                    break;
                case '2':
                    row1 += " _ ";
                    row2 += " _|";
                    row3 += "|_ ";
                    break;
                case '3':
                    row1 += " _ ";
                    row2 += " _|";
                    row3 += " _|";
                    break;
                case '4':
                    row1 += "   ";
                    row2 += "|_|";
                    row3 += "  |";
                    break;
                case '5':
                    row1 += " _ ";
                    row2 += "|_ ";
                    row3 += " _|";
                    break;
                case '6':
                    row1 += " _ ";
                    row2 += "|_ ";
                    row3 += "|_|";
                    break;
                case '7':
                    row1 += " _ ";
                    row2 += "  |";
                    row3 += "  |";
                    break;
                case '8':
                    row1 += " _ ";
                    row2 += "|_|";
                    row3 += "|_|";
                    break;
                case '9':
                    row1 += " _ ";
                    row2 += "|_|";
                    row3 += " _|";
                    break;
            }

            return new List<string> { row1, row2, row3 };
        }

        public static List<string> GetBigNumberStrings(char number, int height, int width)
        {
            var numberStrings = new List<string>();
            var numberCode = GetNumberCode(number);

            var topLine = " ";
            for (var i = 0; i < width; i++) // construct top horizontal segment
            {
                if (numberCode[0, 1] != 0)
                {
                    topLine += "_";
                }
                else
                {
                    topLine += " ";
                }               
            }

            topLine += " ";
            numberStrings.Add(topLine);

            for (var i = 0; i < height; i++) // construct top vertical segments
            {
                var upperMiddleLine = "";

                if (numberCode[1, 0] != 0)
                {
                    upperMiddleLine += "|";
                }
                else
                {
                    upperMiddleLine += " ";
                }

                for (var j = 0; j < width; j++)
                {
                    upperMiddleLine += " ";
                }

                if (numberCode[1, 2] != 0)
                {
                    upperMiddleLine += "|";
                }
                else
                {
                    upperMiddleLine += " ";
                }

                numberStrings.Add(upperMiddleLine);
            }

            var middleLine = " ";
            for (var i = 0; i < width; i++) // construct middle horizontal segment
            {
                if (numberCode[1, 1] != 0)
                {
                    middleLine += "_";
                }
                else
                {
                    middleLine += " ";
                }               
            }

            middleLine += " ";
            numberStrings.Add(middleLine);

            for (var i = 0; i < height; i++) // construct bottom vertical segments
            {
                var lowerMiddleLine = "";

                if (numberCode[2, 0] != 0)
                {
                    lowerMiddleLine += "|";
                }
                else
                {
                    lowerMiddleLine += " ";
                }

                for (var j = 0; j < width; j++)
                {
                    lowerMiddleLine += " ";
                }

                if (numberCode[2, 2] != 0)
                {
                    lowerMiddleLine += "|";
                }
                else
                {
                    lowerMiddleLine += " ";
                }

                numberStrings.Add(lowerMiddleLine);
            }

            var bottomLine = " ";
            for (var i = 0; i < width; i++) // construct bottom horizontal segment
            {
                if (numberCode[2, 1] != 0)
                {
                    bottomLine += "_";
                }
                else
                {
                    bottomLine += " ";
                }             
            }

            bottomLine += " ";
            numberStrings.Add(bottomLine);

            return numberStrings;
        }

        public static int[,] GetNumberCode(char number)
        {
            switch (number)
            {
                case '0':
                    return new[,] { { 0, 1, 0 },
                                    { 2, 0, 2 },
                                    { 2, 1, 2 } };
                case '1':
                    return new[,] { { 0, 0, 0 },
                                    { 0, 0, 2 },
                                    { 0, 0, 2 } };
                case '2':
                    return new[,] { { 0, 1, 0 },
                                    { 0, 1, 2 },
                                    { 2, 1, 0 } };
                case '3':
                    return new[,] { { 0, 1, 0 },
                                    { 0, 1, 2 },
                                    { 0, 1, 2 } };
                case '4':
                    return new[,] { { 0, 0, 0 },
                                    { 2, 1, 2 },
                                    { 0, 0, 2 } };
                case '5':
                    return new[,] { { 0, 1, 0 },
                                    { 2, 1, 0 },
                                    { 0, 1, 2 } };
                case '6':
                    return new[,] { { 0, 1, 0 },
                                    { 2, 1, 2 },
                                    { 2, 1, 2 } };
                case '7':
                    return new[,] { { 0, 1, 0 },
                                    { 0, 0, 2 },
                                    { 0, 0, 2 } };
                case '8':
                    return new[,] { { 0, 1, 0 },
                                    { 2, 1, 2 },
                                    { 2, 1, 2 } };
                case '9':
                    return new[,] { { 0, 1, 0 },
                                    { 2, 1, 2 },
                                    { 0, 1, 2 } };
                default:
                    return null;
            }
        }
    }
}
