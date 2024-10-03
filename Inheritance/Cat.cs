// We specify that our Cat is inheriting from Animal with : Animal
public class Cat : Animal
{
    // Notice the lack of fields. We don't need them!

        // We can add our own fields
        public string FurType;
        // We are not limited in how our constructor receives data
        // Just make sure you're using a constructor from Animal as a base
        public Cat(string ft, string diet) : base("Cat", diet, true)
        {
            FurType = ft;
        }
}

