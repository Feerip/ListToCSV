using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            Console.SetWindowSize(100, 50);

            try
            {
                Console.WriteLine("ListToCSV 2.1");
                Console.WriteLine("By Phillip Smith");
                Console.WriteLine("---------");
                Console.WriteLine("A small program created to convert a vertical list");
                Console.WriteLine("of items into a CSV (Comma Separated Value) format.");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Example:");
                Console.WriteLine("BEFORE PROCESSING:");
                Console.WriteLine("one");
                Console.WriteLine("two");
                Console.WriteLine("three");
                Console.WriteLine("four");
                Console.WriteLine("five");
                Console.WriteLine("six");
                Console.WriteLine("seven");
                Console.WriteLine("eight");
                Console.WriteLine("nine");
                Console.WriteLine("ten");
                Console.WriteLine("eleven");
                Console.WriteLine();
                Console.WriteLine("AFTER PROCESSING:");
                Console.WriteLine("one, two, three, four, five, six, seven, eight, nine, ten, eleven");
                Console.WriteLine();
                Console.WriteLine("Instructions (Regular):");
                Console.WriteLine("1. Open this program");
                Console.WriteLine("2. Drag the file you would like to convert into this window");
                Console.WriteLine("3. Press enter");
                Console.WriteLine("4. Open the text file again, and you will");
                Console.WriteLine("   see that your text has been converted.");
                Console.WriteLine();
                Console.WriteLine("Instructions (Quick):");
                Console.WriteLine("1. Drag the text file you would like to convert directly");
                Console.WriteLine("   onto the program file (ListToCSV2_1.exe) for this program.");
                Console.WriteLine("   It will instantly convert the file without needing you");
                Console.WriteLine("   to press enter.");
                Console.WriteLine();
                Console.WriteLine("Please drag your file into the console window now, and hit enter after you do so.");

                if (args.Length == 0)
                {
                    path = Console.ReadLine();
                    if (path == string.Empty)
                        throw new Exception("No input received.");
                }
                else if (args.Length == 1)
                    path = args[0];
                else
                    throw new InvalidOperationException("ERROR: Too many arguments passed");



                //Console.WriteLine("Please specify which file you would like to convert.");
                //Console.WriteLine("You can do this by dragging the text file on top of the program file for this program.");
                //Console.WriteLine("This program is designed to convert a list of things, separated by newline characters,");
                //Console.WriteLine("Into a CSV file for you to use.");
                //Console.WriteLine();
                //Console.WriteLine("It replaces all new lines with a single \",\" character, creating a file that has everything");
                //Console.WriteLine("separated by commas.");
                //Console.WriteLine();
                //if (args.Length == 0)
                //{
                //    Console.WriteLine("Please drag the file into the window now,");
                //    Console.WriteLine("Or just hit enter to exit the program without converting.");
                //    Console.WriteLine("If you drag the file into the window, hit enter to process.");

                //    path = Console.ReadLine();
                //}
                //else
                //{
                //    path = args[0];
                //}



                if (!File.Exists(path))
                    throw new Exception("Sorry, I could not find the file you specified.");
                else
                {
                    string[] theFile = File.ReadAllLines(path);
                    string replacement = string.Empty;


                    string last = theFile.Last();
                    foreach (string s in theFile)
                    {
                        replacement += s;
                        if (!s.Equals(last))
                        {
                            replacement += ", ";
                        }
                    }

                    File.WriteAllText(path, replacement);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(replacement);
                    Console.WriteLine();
                    Console.WriteLine("Translation complete. You will find the text in the original file,");
                    Console.WriteLine("so you can just open it and copy it out.");
                    Console.WriteLine();
                    Console.WriteLine("Please hit enter to exit.");
                    if (args.Length == 0)
                        Console.ReadLine();


                }



            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please hit enter to exit.");
                Console.ReadLine();
            }
        }



    }
}

