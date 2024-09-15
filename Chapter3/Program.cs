using System;

namespace Chapter3;

// Base class
public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public virtual void Speak()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
}

// Derived class with inheritance
public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void Speak()
    {
        Console.WriteLine($"{Name} barks.");
    }
}

// Access modifiers demo
public class AccessModifierDemo
{
    public int PublicField = 10;        // Accessible everywhere
    private int PrivateField = 20;      // Accessible only within the class
    protected int ProtectedField = 30;  // Accessible in derived classes
    internal int InternalField = 40;    // Accessible within the same assembly
}

class Program
{
    static void Main(string[] args)
    {
        // Class and inheritance example
        Dog dog = new Dog("Buddy");
        dog.Speak();

        // Access modifier example
        AccessModifierDemo demo = new AccessModifierDemo();
        Console.WriteLine($"Public Field: {demo.PublicField}");
        Console.WriteLine($"Internal Field: {demo.InternalField}");
    }
}
