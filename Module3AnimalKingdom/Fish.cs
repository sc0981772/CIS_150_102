using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalKingdom
{
    public class Fish : Animal
    {
        public Fish(string name, int age) : base(name, age)
        {
        }

        public override void MakeSound()
        {
            // Fish don't make sounds. They blub. Blub Blub.
            Console.WriteLine($"{Name} bubbles.");
        }
    }
}
