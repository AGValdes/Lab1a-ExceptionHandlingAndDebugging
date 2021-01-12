using System;

namespace Lab1a_ExceptionHandlingAndDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception genException)
            {
                Console.WriteLine($"Sorry, something went wrong, we didn't quite catch that {genException.Message}");
              
            }
            finally
            {
                Console.WriteLine("Program is complete");
            }
          
        }

        static void StartSequence()
        {
            try
            {

                Console.WriteLine("Let's do some math!");
                Console.WriteLine("Please enter a number greater than 0");
                string arraySizeInput = Console.ReadLine();
                int arraySize = Convert.ToInt32(arraySizeInput);
                int[] numsArray = new int[arraySize];
                //Populates the numArray based on user input and then sets variables equal to the returns of all other methods
                Populate(numsArray);
                int sum = GetSum(numsArray);
                int prod = GetProduct(numsArray, sum);
                decimal quot = GetQuotient(prod);
                //I'm doing this in order to print the user's selections to the screen as they were entered since we cannot grab their values out of other methods becasue of scope
                int numberToBeMultiplied = prod / sum;
                int convertedQuot = Convert.ToInt32(quot);
                int numberToBeDivided = prod / convertedQuot;
                //prints everything to the screen
                Console.WriteLine($"Your array is size:{arraySize}");
                Console.WriteLine("The numbers in your array are: {0}", string.Join(", ", numsArray));

                Console.WriteLine($"The sum of your array is: {sum}");
                Console.WriteLine($"{sum} * {numberToBeMultiplied} = {prod}");
                Console.WriteLine($"{prod} / {numberToBeDivided} = {quot}");



            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Sorry, the input was not formatted correctly{fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Sorry, that number was too big {oe.Message}");
            }
            
        }
        static int[] Populate(int[] arr)
        {
                //using the counter to display how many numbers they have selected out of their orignal number
                int counter = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"Please Enter Number {counter + 1} of {arr.Length} ");
                    string userNumberInput = Console.ReadLine();
                    int userNumber = Convert.ToInt32(userNumberInput);
                    arr[i] = userNumber;
                    counter++;
                }
            return arr;
         
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
         if (sum < 20)
            {
                Console.WriteLine($"Value of {sum} is too low... ");
            }
            return sum;
        }

        static int GetProduct(int[] arr, int sum)
        {
            try
            {
                Console.WriteLine($"Please enter a number between 1 and {arr.Length}");
                string userInput = Console.ReadLine();
                int userNum = Convert.ToInt32(userInput);
                int product = sum * arr[userNum-1];
                Console.WriteLine(product);
               
                return product;
               
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine($"That number was out of the specified range...{ioore.Message}");
                throw;
            }
         
        }

        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide the product:{product} by");
                string userInput = Console.ReadLine();
                decimal userDecimal = Convert.ToDecimal(userInput);
                decimal productAsDecimal = Convert.ToDecimal(product);
                //decimal.Divide takes in first the dividend, then the divisor
                decimal quotient = decimal.Divide(product, userDecimal);
                return quotient;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine($"You can't divide by zero...it's first grade spongebob {dbze.Message}");
                return 0;
            }
        }
    }
}
