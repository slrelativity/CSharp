class Dog
{
    // Our future code here
    string Name;
                                //creates a backing field hidden from source code.
    public string Breed {get; set;}
    string Color;

    public string _Name
    {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
        }
    }

    public Dog(string n, string b, string c)
    {
        Name = n;
        Breed = b;
        Color = c;
    }

    void Bark()
        {
            Console.WriteLine("Bark! Bark!");
        }
}
