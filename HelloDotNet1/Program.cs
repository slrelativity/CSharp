// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello, World!");

// Variable to interpolate
string place = "Coding Dojo";
// Interpolated string, note the $
Console.WriteLine($"Hello {place}");
// Another option uses placeholders like so
// Note this does NOT have a $ at the start
Console.WriteLine("Hello {0}", place);

string book = "fudge";
Console.WriteLine($"Read {book}");

char h ='p'; //requires single ' '
Console.WriteLine($"Q comes after {h}");

int number = 8;
Console.WriteLine($"what is {number}");




int temp = 68;
if(temp >= 72)
{
    // This executes if the temperature is greater than or equal to 72
    Console.WriteLine("It's a beautiful day to go outside!");
} else if(temp > 64) {
    // This executes only if the temperature was NOT greater than or equal to 72 and IS above 64
    Console.WriteLine("I think it should be fine to go outside today with a light jacket.");    
} else {
    // If neither of the above conditions are met, we run the else statement
    Console.WriteLine("Maybe I'll stay inside today.");
}


// OPERATORS
//     < is the number to the left less than the number on the right
//     > is the number to the left greater than the number on the right
//     <= is the number to the left less than or equal to the number on the right
//     >= is the number to the left greater than or equal to the number on the right
//     == is the number to the left equal to the number on the right
//     "!= is the number to the left equal to the number on the right

//      && are  two conditions BOTH true
//      || are eother conditions true
//      "! true becomes false and flase becomes true


int temperature = 62;
string weather = "Cloudy";
// If the temperature is greater than or equal to 72 OR the weather is sunny, we run the first condition
if(temperature >= 72 || weather == "Sunny")
{
    Console.WriteLine("It's a beautiful day to go outside!");
// Otherwise, if the temperature is greater than 64 AND it is not raining out, we run the second condition
} else if(temperature > 64 && weather != "Rainy") {
	Console.WriteLine("I think it should be fine to go outside today with a jacket.");    
} else {
    Console.WriteLine("Maybe I'll stay inside today.");
}


// for(int i = 0; i <= 10; i++)
// {
// Console.WriteLine(i);
// }

int g = 1;
while (g <=10)
{
    Console.WriteLine(g);
    g++;
}


// int start = 0;
// int end = 10;
// // loop from start to end including end
// for (int i = start; i <= end; i++)
// {
//     Console.WriteLine(i);
// }
// // loop from start to end excluding end
// for (int i = start; i < end; i++)
// {
//     Console.WriteLine(i);
// }


int j = 1;
while(j <=10)
{
    Console.WriteLine(j);
    j++;
}


// int start = 0;
// int end = 50;
// // loop from start to end including end
// for (int i = start; i <= end-1; i+=2)
// {
//     Console.WriteLine(i);
// }

// Random rand = new Random();
// // Console.WriteLine(rand.Next(2,10));

// //Decimal
// Console.WriteLine(rand.NextDouble());

Random rand = new Random();
for (int i = 1; i <= 10; i++)
{
    // Every time the loop executes we will get a NEW random value between 2 and 7
    Console.WriteLine(rand.Next(2, 8));
}

// Initializing an empty list of Motorcycle Manufacturers that expects string values
List<string> bikes = new List<string>();
// Use the Add function in a similar fashion to push
bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");
// Accessing a generic list value is the same as an array
Console.WriteLine(bikes[2]); //Prints "BMW", remember we start at 0!
// To get the size of a List, we use Count instead of Length
Console.WriteLine($"We currently know of {bikes.Count} motorcycle manufacturers.");


// Using our list of motorcycle manufacturers from before
// we can easily loop through the list of them with a for loop
// this time, however, Count is the attribute for a number of items.
Console.WriteLine("The current manufacturers we have seen are:");
for (int idx = 0; idx < bikes.Count; idx++)
{
    Console.WriteLine("-" + bikes[idx]);
}
// Insert a new item between a specific index
bikes.Insert(2, "Yamaha");
// Removal from List
// Remove is a lot like Javascript array pop, but searches for a specified value
bikes.Remove("Suzuki");
bikes.Remove("Yamaha");
// We can also remove from a specific index
bikes.RemoveAt(0);
// RemoveAt has no return value however, so we cannot get back what we removed
// The updated list can then be iterated through using a foreach loop
Console.WriteLine("List of Non-Japanese Manufacturers:");
foreach (string manu in bikes)
{
    Console.WriteLine("-" + manu);
}



