namespace AnimalKingdom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird parrot = new Bird("Parrot", 5);
            Fish goldfish = new Fish("Goldfish", 1);

            // Although MakeSound is overridden, the property Name is inherited from Animal
            //Keeping this for future review context
            parrot.MakeSound();
            goldfish.MakeSound();

            // Accessing inherited properties
            Console.WriteLine(parrot.Name); // Outputs: Parrot
            Console.WriteLine(goldfish.Age); // Outputs: 1
        }
    }
}
