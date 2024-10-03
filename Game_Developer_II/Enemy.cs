public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; } 
    public List<Attack> _attackList { get; set;}


    public Enemy(string name)
    {
        Name = name;
        Health = 100;
        _attackList = [];
    }

    public void AddAttack(Attack name)
    {
        _attackList.Add(name);
    }


    public void RandomAttack()
    {
        Random rand = new();
        Attack ChosenAttack = _attackList[rand.Next(_attackList.Count)];
        Console.WriteLine($"{Health} health and has {_attackList.Count} attacks");
        Console.WriteLine($"{Name} completes {ChosenAttack.Name} and deals {ChosenAttack.Damage} damage");
    }

    public virtual void PerformAttack(Enemy target, Attack ChosenAttack)
    {
        // Write some logic here to reduce the Targets health by your Attack's DamageAmount
        
        target.Health -= ChosenAttack.Damage;
        if(target.Health < 0) target.Health = 0;
        Console.WriteLine($"{Name} attacks {target.Name} with {ChosenAttack.Name}, dealing {ChosenAttack.Damage} damage and reducing {target.Name}'s health to {target.Health}!!");
    }
}