//1
using System.Data.SqlTypes;

static void PrintList(List<string> MyList)
{
    foreach (string name in MyList)
        Console.WriteLine(name);
}
List<string> TestStringList = new List<string>() { "Harry", "Steve", "Carla", "Jeanne" };
PrintList(TestStringList);



//2
static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    for (int i = 0; i < IntList.Count; i++)
    {
        Console.WriteLine(IntList[i]);
        sum += IntList[i];
    }
    Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() { 2, 7, 12, 9, 3 };
SumOfNumbers(TestIntList);
// You should get back 33 in this example




//3
static int FindMax(List<int> IntList)
{
    int max = IntList[0];
    for (int i = 0; i < IntList.Count; i++)
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
    return max;
}
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
// You should get back 17 in this example
FindMax(TestIntList2);



//4
static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++)
        IntList[i] = IntList[i] * IntList[i];
    
    return IntList;
}
List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3);


//5
static int[] NonNegatives(int[] IntArray)
{
    int[] resultIntArray = new int[IntArray.Length];
    for (int i = 0; i < IntArray.Length; i++)
        if (IntArray[i] < 0)
        {
            resultIntArray[i] = 0;
            Console.WriteLine(resultIntArray[i]);
        }
        else
        {
            resultIntArray[i] = IntArray[i];
            Console.WriteLine(IntArray[i]);
        }
    return resultIntArray;
}
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);




//6
static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (var name in MyDictionary)
        Console.WriteLine($"{name}");
}
Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);


//7

static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm);
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));





//8
// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> profiles = new Dictionary<string, int>();
        for (int i = 0; i < Names.Count; i++)
    {
        profiles[Names[i]] = Numbers[i];
    }
    return profiles;
}

List<string> names = new List<string>() {"Julie", "Harold", "James", "Monica"};
List<int> numbers = new List<int>() {6,12,7,10};
Dictionary<string, int> generatedProfiles = GenerateDictionary(names, numbers);
    foreach (var entry in generatedProfiles)
{
    Console.WriteLine(entry.Key + ": " + entry.Value);
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here

