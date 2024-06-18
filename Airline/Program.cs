// Kyle Riner
// Cs3 Assignment, Airline Program
// TINFO-200A, Winter 2022

//////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer   Description of change
// 03-10-2022   kriner      initial creation of program, creation of array, creation of while loop
// 03-10-2022   kriner      creation of if statements for userSelection inputs, creation of OccupiedSeat method
// 03-11-2022   kriner      creation of yesNo if statement, testing of program
// 03-11-2022   kriner      removed redundant foreach loops and created the DisplaySeating method
// 03-12-2022   kriner      documentation of program and creation of user interface
// 03-12-2022   kriner      final testing before canvas submission
// 
// This program assigns seats on a flight with a maximum capacity of 10 seats using a one-dimensional array of
// type bool where false values are empty seats and true values are occupied seats. Prompts the user for an int
// value of 1, 2, or 3 where 1 assigns a seat in first class (seats 1-5), 2 assigns a seat in the economy section
// (seats 6-10), and 3 exits the program in case the plane must urgently take off at less-than-full capacity. As
// each seat is assigned, the corresponding element in the array is set to true, indicating the seat is no longer
// available. If the first class or economy sections are full the program will prompt the user if it is acceptable
// to be assigned a seat in the opposite class. If yes, the appropriate seating assignment is made. If no, the
// program displays the message "Next flight leaves in 3 hours" and keeps running so long as there are still
// available seats on the plane given that the next customer may be willing to swap. Once the plane reaches max
// capacity (there are no more false values in the array) the program displays the message "This flight is at
// maximum occupancy, the next flight leaves in 3 hours." and the program exits.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the namespace for the AirLine program
namespace Airline
{
    // declaration of the class that holds the AirLine program
    internal class Program
    {
        // the main method that executes the AirLine program
        static void Main(string[] args)
        {
            bool[] arr = new bool[10];  // array of seats, all initialized as false

            // user interface of the program
            Console.WriteLine(@"
Welcome to the AirLine app! This app will assign seats on the airline's 
plane with a capacity of 10 seats based on your inputs. At the start of
the program the initial seating chart will be displayed with false values
representing available seats and true values representing occupied seats.

You will be prompted to either enter a 1 to assign a seat in first class, 
a 2 to assign a seat in economy class, or a 3 to exit the program if the 
plane needs to stay on schedule and depart without being full. After every 
seat assignment the new seating chart will be output back to you. 

If the first class or economy sections are full you will be prompted to ask 
the customer if it is acceptable to assign them a seat in the opposite class.
If so, a seat in the respective class will be assigned. If no, a statement
saying when the next flight departs will be output and the program will
continue running to account for following customers.

When all seats are occupied the program will output a statement of when 
the next flight departs and the program exits. 
");

            // displays the initial seating chart, an array of all false boolss
            Console.WriteLine("Initial seating chart:");
            DisplaySeating(ref arr);

            // prompts the user for an input and records the input in an int variable userSelection
            Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
            int userSelection = int.Parse(Console.ReadLine());

            int index;  // index of the array

            // while there are still false values within the array
            while (Array.IndexOf(arr, false) != -1)
            {
                // if the user inputs a 1
                if (userSelection == 1)
                {
                    // if first class is not full then the index is set equal to the index of the 
                    // location of the first instance of a false value and that value is set to true.
                    // the seating chart is displayed and the user is then prompted for another input.
                    if (arr[(arr.Length / 2) - 1] != true)
                    {
                        index = Array.IndexOf(arr, false);
                        OccupiedSeat(ref arr[index]);
                        DisplaySeating(ref arr);
                        Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                        userSelection = int.Parse(Console.ReadLine());
                    }
                    // if first class is full the user is prompted for if it is acceptable to be assigned
                    // a seat in economy class and their input is recorded in a char variable yesNo.
                    else if (arr[(arr.Length / 2) - 1] == true)
                    {
                        Console.WriteLine("First class is full, would it be acceptable to give the customer a seat in the economy class?");
                        Console.Write("Please answer Y for yes and N for no: ");
                        char yesNo = char.ToUpper(char.Parse(Console.ReadLine()));
                        // if the user inputs a 'Y' the first instance of a false in the array, which would be
                        // in the economy class, is set to true, the seating chart is displayed, and the user is
                        // prompted for another input
                        if (yesNo == 'Y')
                        {
                            OccupiedSeat(ref arr[Array.IndexOf(arr, false)]);
                            DisplaySeating(ref arr);
                            Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                            userSelection = int.Parse(Console.ReadLine());
                        }
                        // if the user inputs a 'N' they are told that the next flight will leave in 3 hours
                        // and are prompted for another input for the next passenger
                        else if (yesNo == 'N')
                        {
                            Console.WriteLine("Next flight leaves in 3 hours.");
                            Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                            userSelection = int.Parse(Console.ReadLine());
                        }
                        // if the response to the yes or no prompt is not a 'Y' or 'N' they are informed that
                        // their input was not appropriate and prompted for the yes or no response again
                        else
                        {
                            Console.WriteLine("That was not an appropriate input.");
                            Console.Write("Please answer Y for yes and N for no: ");
                            yesNo = char.ToUpper(char.Parse(Console.ReadLine()));
                        }
                    }
                }
                // if the user inputs a 2
                else if (userSelection == 2)
                {
                    // if economy class is not full the index is set equal to the index of the 
                    // location of the first instance of a false value and that value is set to true.
                    // the seating chart is displayed and the user is then prompted for another input.
                    if (arr[arr.Length - 1] != true)
                    {
                        index = Array.IndexOf(arr, false, 5);
                        OccupiedSeat(ref arr[index]);
                        DisplaySeating(ref arr);
                        Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                        userSelection = int.Parse(Console.ReadLine());
                    }
                    // if economy class is full the user is prompted for if it is acceptable to be assigned
                    // a seat in first class and their input is recorded in a char variable yesNo.
                    else if (arr[arr.Length - 1] == true)
                    {
                        Console.WriteLine("The economy class is full, would it be acceptable to give the customer a seat in first class?");
                        Console.Write("Please answer Y for yes and N for no: ");
                        char yesNo = char.ToUpper(char.Parse(Console.ReadLine()));
                        // if the user inputs a 'Y' the first instance of a false in the array, which would be
                        // in first class, is set to true, the seating chart is displayed, and the user is prompted
                        // for another input
                        if (yesNo == 'Y')
                        {
                            OccupiedSeat(ref arr[Array.IndexOf(arr, false)]);
                            DisplaySeating(ref arr);
                            Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                            userSelection = int.Parse(Console.ReadLine());
                        }
                        // if the user inputs a 'N' they are told that the next flight will leave in 3 hours
                        // and are prompted for another input for the next passenger
                        else if (yesNo == 'N')
                        {
                            Console.WriteLine("Next flight leaves in 3 hours.");
                            Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                            userSelection = int.Parse(Console.ReadLine());
                        }
                        // if the response to the yes or no prompt is not a 'Y' or 'N' they are informed that
                        // their input was not appropriate and prompted for the yes or no response again
                        else
                        {
                            Console.WriteLine("That was not a Y for yes or N for no.");
                            Console.Write("Please answer Y for yes and N for no: ");
                            yesNo = char.ToUpper(char.Parse(Console.ReadLine()));
                        }
                    }
                }
                // if the user inputs a 3 because the plane must stay on schedule, informs the user the program
                // is exiting
                else if (userSelection == 3)
                {
                    Console.WriteLine("Now exiting the program.");
                    break;
                }
                // if the user enters anything but a 1, 2, or 3 the user is told that the input was not
                // appropriate and prompts them for a new input
                else
                {
                    Console.WriteLine("That was not an appropriate input.");
                    Console.Write("\nPlease enter 1 for First Class, 2 for Economy, or 3 to exit: ");
                    userSelection = int.Parse(Console.ReadLine());
                }
            }
            // if the array has no more false values, meaning that all seats are occupied, the user is
            // informed that the flight is at max occupancy and the next flight leaves in 3 hours
            if (Array.IndexOf(arr, false) == -1) {
                Console.WriteLine("This flight is at maximum occupancy, the next flight leaves in 3 hours.");
            }

            //DisplaySeating(ref arr);
        }

        // changes a value in the array from false to true to indicate that a seat is occupied and no
        // longer available
        static void OccupiedSeat(ref bool seat)
        {
            seat = true;
        }

        // outputs each bool value in the array so that the user can see the initial seating chart and after
        // assigning a seat.
        static void DisplaySeating(ref bool[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("");
        }
    }
}
