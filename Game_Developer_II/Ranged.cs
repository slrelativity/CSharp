public class RangedFighter : Enemy
{
    public int Distance { get; set; }

    public RangedFighter(string name) : base(name)
    {
        Distance = 5;
        _attackList.Add(new Attack("Shoot an Arrow", 20));
        _attackList.Add(new Attack("Throw a Knife", 15));
    }

    public override void PerformAttack(Enemy target, Attack ChosenAttack)
    {
        if (Distance < 10)
        {
            base.PerformAttack(target, ChosenAttack);
        }
        else
        {
            Console.WriteLine($"{Name} is unable to perform {ChosenAttack.Name} because the distance is less than 10.");
        }
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} dashes, setting distance to {Distance}.");
    }
}