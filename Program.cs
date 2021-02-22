using System;
using System.Text;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string myFirstName = "Wison";
            string myLastName = "Ye";

            // $ - string interpolation
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            Console.WriteLine($"My name is '{myFirstName} {myLastName}'");

            // String Builder
            StringBuilder strBuffer = new StringBuilder();
            strBuffer.Append("My name is: ");
            strBuffer.Append(myFirstName);
            strBuffer.Append(" ");
            strBuffer.Append(myLastName);
            strBuffer.AppendFormat("\nMy name is '{0} {1}'", myFirstName, myLastName);

            Console.WriteLine($"StringBuffer Len: {strBuffer.Length}, content: {strBuffer.ToString()}");

            // Type Conversion
            string tempAage = "88";
            int age;
            try {
                age = Int32.Parse(tempAage);
            }
            catch (FormatException e) {
                Console.WriteLine(e.Message);
                return;
            }

            double ageInDouble = age;
            string ageInString = Convert.ToString(ageInDouble);
            Console.WriteLine($"\nage: {age}, ageInDouble: {ageInDouble}, ageInString: {ageInString}");
                

            // Convert between byte/int/string
            byte tempByte = 0xAA;
            byte[] byteArr = {tempByte, 0xCD};
            // string byteString = "AABBCCDD";
            int byteInt = 30;
            Console.WriteLine($"tempByte: 0x{BitConverter.ToString(byteArr)}");
            Console.WriteLine($"byteInt: 0x{BitConverter.ToString(BitConverter.GetBytes(byteInt))}");

            // Using class
            Person wison = new Person("Wison", "Ye", 99);
            wison.print();
            wison = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Person mike = new Person("Mike", "Ye", 11);
            mike.print();
            mike = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}

class Person
{
    public string FirstName;
    string LastName;
    uint Age;

    public Person(string firstName, string lastName, uint age) {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public void print() {
        Console.WriteLine($"Person -> FirstName: {FirstName}, LastName: {LastName}, Age: {Age}");
    }

    ~Person() {
        Console.WriteLine($"{GetType().Name} instance will be destroyed >>>");
        System.Diagnostics.Trace.WriteLine($"{GetType().Name} instance will be destroyed >>>");
    }
}
