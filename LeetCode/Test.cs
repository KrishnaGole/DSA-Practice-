using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Test
    {
        

    }
    public class Animal
    {
        protected int ID { get; set; }
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : Animal
    {
        public Dog()
        {
            //ID = 12;
        }
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    public class Cat : Dog
    {
        public Cat()
        {
            ID = 23;
        }
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
    }

}
