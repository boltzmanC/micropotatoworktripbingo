using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace micropotatoworktripbingo
{
    class Program
    {
        static void Main(string[] args)
        {
            // bingo
            // output is console | delimited string values

            //Console.WriteLine("Enter Name: ");
            //string username = Console.ReadLine().Trim().ToUpper();

            //Console.WriteLine("Is he leaving the country (y/n)?: ");
            //string input = Console.ReadLine().Trim().ToUpper();

            // get defaut bingo values
            List<string> defaultvalues = typeof(BingoValuesDefault).GetAllPublicConstantValues<string>();

            // array
            // random number
            // choose item
            // subtract from array and number
            // loop


            string[,] valuematrix = new string[5, 5];

            Random randomnumber = new Random();

            // store values not added to matrix
            List<string> notadded = defaultvalues;
            List<string> alreadyused = new List<string>();

            // initial length is from initial list
            int newlength = defaultvalues.Count();

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    // use value calculated at end of loop OR use first declared value
                    int valuetoadd = randomnumber.Next(0, newlength - 1);

                    if (!alreadyused.Contains(notadded[valuetoadd])) // if value has not been used yet
                    {
                        // add value to matrix
                        valuematrix[x, y] = notadded[valuetoadd];

                        //add to used list
                        alreadyused.Add(notadded[valuetoadd]);

                        // remove value from notadded
                        List<string> templist = new List<string>();
                        for (int l = 0; l < newlength; l++)
                        {
                            if (l != valuetoadd)
                            {
                                templist.Add(notadded[l]);
                            }
                        }

                        //overwrite list with new list
                        notadded = templist;

                        // new length
                        newlength = notadded.Count();
                    }
                    else
                    {
                        // rerun the current matrix value
                        --y;
                    }
                }
            }

            // get length of longest string
            int valuelength = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (valuelength < valuematrix[x,y].Length)
                    {
                        valuelength = valuematrix[x, y].Length;
                    }
                }
            }
            

            // print
            for (int y = 0; y < 5; y++)
            {
                //build first row of the array
                List<string> linebuilder = new List<string>();
                
                for (int x = 0; x < 5; x++)
                {
                    linebuilder.Add(valuematrix[x, y]);
                }
                
                for (int v = 0; v < linebuilder.Count; v++)
                {
                    // left justify
                    //valuelength *= -1;

                    //write value
                    //Console.Write(string.Format("{0," + valuelength +"}", linebuilder[v]));

                    Console.Write(linebuilder[v].PadRight(valuelength, ' '));

                    if (v < linebuilder.Count - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Just take a streenshot you lazy boi....");
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
