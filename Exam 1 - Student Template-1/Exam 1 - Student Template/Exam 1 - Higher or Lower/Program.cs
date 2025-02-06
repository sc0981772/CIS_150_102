namespace LargestNumberFinder
{
    public class NumberProgram
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int number;
            int largest = int.MinValue //Initialize at the smallest possible integer

            //User prompt
            Console.WriteLine("Please enter 10 positive integers.");

            while (counter < 10)
            {
                Console.WriteLine($"Enter integer {counter + 1}: ");
                ProcessInput(); //calls the ProcessInput function which also has the ReadLine embedded in, hopefully did this correctly
                try
                {
                    Console.WriteLine($"You entered: {number}");
                    //negative number course correction
                    if (number <= 0) 
                    {
                        Console.WriteLine("Error: Please enter a positive integer.");
                        break; //does not continue to next part of the loop
                    }

                    //zero course correction
                    if (number == 0)
                    {
                        Console.WriteLine("Error: Please enter a positive integer.");
                        break; //does not continue to next part of the loop
                    }

                    counter++;
                }

                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occured: {ex.Message}");
                }
            }

            Console.WriteLine($"The largest number is {largest}");
        }

        public static int ProcessInput(string input, ref int largest)
        {
            input = int.Parse(Console.ReadLine());
            if (input > largest)
            {
                largest = input;
            }
        }
    }
}
