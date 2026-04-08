using System;
using System.Collections.Generic;

namespace PeriodicTableApp
{
    // Class to represent an Element
    public class Element
    {
        public int AtomicNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Element(int atomicNumber, string name, string category)
        {
            AtomicNumber = atomicNumber;
            Name = name;
            Category = category;
        }

        public void Display()
        {
            Console.WriteLine($"\nAtomic Number: {AtomicNumber}");
            Console.WriteLine($"Name of the Element: {Name}");
            Console.WriteLine($"Category of the Element: {Category}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Dictionary to store first 30 elements
            Dictionary<int, Element> elements = new Dictionary<int, Element>()
            {
                {1, new Element(1, "Hydrogen", "Nonmetal")},
                {2, new Element(2, "Helium", "Noble Gas")},
                {3, new Element(3, "Lithium", "Alkali Metal")},
                {4, new Element(4, "Beryllium", "Alkaline Earth Metal")},
                {5, new Element(5, "Boron", "Metalloid")},
                {6, new Element(6, "Carbon", "Nonmetal")},
                {7, new Element(7, "Nitrogen", "Nonmetal")},
                {8, new Element(8, "Oxygen", "Nonmetal")},
                {9, new Element(9, "Fluorine", "Halogen")},
                {10, new Element(10, "Neon", "Noble Gas")},
                {11, new Element(11, "Sodium", "Alkali Metal")},
                {12, new Element(12, "Magnesium", "Alkaline Earth Metal")},
                {13, new Element(13, "Aluminium", "Post-transition Metal")},
                {14, new Element(14, "Silicon", "Metalloid")},
                {15, new Element(15, "Phosphorus", "Nonmetal")},
                {16, new Element(16, "Sulfur", "Nonmetal")},
                {17, new Element(17, "Chlorine", "Halogen")},
                {18, new Element(18, "Argon", "Noble Gas")},
                {19, new Element(19, "Potassium", "Alkali Metal")},
                {20, new Element(20, "Calcium", "Alkaline Earth Metal")},
                {21, new Element(21, "Scandium", "Transition Metal")},
                {22, new Element(22, "Titanium", "Transition Metal")},
                {23, new Element(23, "Vanadium", "Transition Metal")},
                {24, new Element(24, "Chromium", "Transition Metal")},
                {25, new Element(25, "Manganese", "Transition Metal")},
                {26, new Element(26, "Iron", "Transition Metal")},
                {27, new Element(27, "Cobalt", "Transition Metal")},
                {28, new Element(28, "Nickel", "Transition Metal")},
                {29, new Element(29, "Copper", "Transition Metal")},
                {30, new Element(30, "Zinc", "Transition Metal")}
            };

            Console.WriteLine("Hi there! Happy to help!");

            while (true)
            {
                Console.Write("\nPlease enter an atomic number: ");

                // Input validation
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                if (elements.ContainsKey(number))
                {
                    elements[number].Display();
                }
                else
                {
                    Console.WriteLine("Element not found (only 1–30 available).");
                }

                Console.Write("\nDo you want to know more elements [y/n]? ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "n")
                    break;
            }

            Console.WriteLine("\nThank you!");
        }
    }
}
