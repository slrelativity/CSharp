
int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

string[] namesArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };

bool[] Array = new bool[10];

for (int i = 0; i < Array.Length; i++)

    Array[i] = (i % 2 == 0);


List <string> iceCreamFlavors = new List<string>();
iceCreamFlavors.Add("Strawberry");
iceCreamFlavors.Add("Custard");
iceCreamFlavors.Add("Choclate");
iceCreamFlavors.Add("Vanilla");
iceCreamFlavors.Add("Peach");
iceCreamFlavors.Add("Pistacio");

iceCreamFlavors.RemoveAt(2);
Console.WriteLine($"Number of flavors {iceCreamFlavors.Count}");
Console.WriteLine(iceCreamFlavors[2]);
Console.WriteLine("Flavors");
foreach (string flavors in iceCreamFlavors)
{
    Console.WriteLine("-" + flavors);
}


Dictionary<string,string> storage = new Dictionary<string, string>();
storage.Add("Name0", "Tim" );
storage.Add("Name1", "Martin");
storage.Add("Name2", "Nikki" );


Random rand = new();

for (int i = 0; i <3; i++)
{
    int flavorName = rand.Next(iceCreamFlavors.Count);
    int name = rand.Next(storage.Count);
    string randomFlavorName = iceCreamFlavors[flavorName];
    string randomName= storage["Name" + name];
    Console.WriteLine(randomFlavorName + randomName);
}