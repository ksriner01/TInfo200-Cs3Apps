// Kyle Riner
// Cs3 Assignment, Elimination Program
// TINFO-200A, Winter 2022

//////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer   Description of change
// 03-09-2022   kriner      initial creation of file, creation of array, for loop, and if statements
// 03-11-2022   kriner      changed the array from size of 5 to 0 to satisfy smallest array requirement
// 03-11-2022   kriner      changed for loop and if/else statements to accomodate for new array size
// 03-11-2022   kriner      testing with new array
// 03-12-2022   kriner      creation of user interface and documentation of program
// 03-12-2022   kriner      final testing of program before canvas submission
//
// Uses a one-dimensional array in a program that prompts a user for five number inputs, each between 10 and 100,
// inclusive. As each number is read it is displayed only if it’s not a duplicate of a number already read.
// The program also displays the complete set of unique values input after the user inputs each new value.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the namespace of the Elimination program
namespace Elimination
{
    // declaration of the class that holds the Elimination program
    internal class Program
    {
        // the main method for the Elimination program
        static void Main(string[] args)
        {
            int[] arr = new int[0]; // the array for user inputs

            // user interface of the program
            Console.WriteLine(@"
Welcome to the Elimination app! This app will prompt you for 5
whole numbers between 10 and 100 inclusive. The number you enter
will be displayed so long as it is not a duplicate of a number 
you have already inputted.");

            int counter = 0;    // counter for while loop iterations
            int index = 0;      // index of array

            // while the counter is less than five, to allow for five user inputs
            while (counter < 5)
            {
                Console.Write("\nPlease enter a whole number between 10 and 100 inclusive: ");
                int num = int.Parse(Console.ReadLine());
                // if the number is within the given range (10 to 100 inclusive)
                if (num >= 10 && num <= 100)
                {
                    // if the array does not contain the number, increases the size of the
                    // array by one and the value of the array at the current index value.
                    // the contents of the array are then displayed for the user and the
                    // index and counter are incremented by one.
                    if (!arr.Contains(num))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[index] = num;
                        foreach (int j in arr)
                        {
                            Console.Write($"{j} ");
                        }
                        index++;
                        counter++;
                    }
                    // if the array already contains the number the user inputted only the
                    // contents of the array are displayed for the user and the counter is
                    // incremented by one.
                    else
                    {
                        foreach (int j in arr)
                        {
                            Console.Write($"{j} ");
                        }
                        counter++;
                    }
                }
                // if the number is outside of the given range (10 to 100 inclusive)
                // displays the contents of the array for the user
                else
                {
                    Console.WriteLine("That number was not in the specified range.");
                    foreach (int j in arr)
                    {
                        Console.Write($"{j} ");
                    }
                }
            }
        }
    }
}
