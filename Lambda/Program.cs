using System.Threading.Tasks.Dataflow;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!


Eruption? firstChileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
Console.WriteLine(firstChileEruption);



Eruption? firstHawaiianIsEruption = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (firstHawaiianIsEruption != null)
{
    Console.WriteLine(firstHawaiianIsEruption);
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}



Eruption? firstGreenlandEruption = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (firstGreenlandEruption != null)
{
    Console.WriteLine(firstGreenlandEruption);
}
else
{
    Console.WriteLine("No Greenland Eruption found.");
}



Eruption? firstEruptionafter = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
Console.WriteLine(firstEruptionafter);



IEnumerable<Eruption> volcanoElevationEruption = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(volcanoElevationEruption);



List<Eruption> volcanoNameL = eruptions.Where(e => e.Volcano.StartsWith('L')).ToList();
PrintEach(volcanoNameL);


int maxElevations = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(maxElevations);




Eruption? highestElevation = eruptions.OrderByDescending(e => e.ElevationInMeters).FirstOrDefault();
Console.WriteLine(highestElevation.Volcano);




int totalElevations = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine(totalElevations);



IEnumerable<Eruption> allInOrder = eruptions.OrderBy(e => e.Volcano).ToList();
PrintEach(allInOrder);



bool lastYear = eruptions.Any(e => e.Year == 2000);
if (lastYear)
{
    Console.WriteLine(lastYear);
}
else
{
    Console.WriteLine("No Eruptions in 2000 found.");
}



IEnumerable<Eruption> firstThreeEruptions = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(firstThreeEruptions);




IEnumerable<Eruption> allBefore = eruptions.Where(e => e.Year < 1000 ).OrderBy(e => e.Volcano);
PrintEach(allBefore);




List <string> namesOnly = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
namesOnly.ForEach(Console.WriteLine);




// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
