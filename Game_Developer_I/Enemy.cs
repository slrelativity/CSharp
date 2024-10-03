public class Enemy
{
    public string Name {get;set;}
    public int Health {get;set;}
    public List<Attack> _attackList;


public Enemy(string name)
    {
        Name = name;
        Health = 100;
        _attackList =  new List<Attack>();
    }

    public void AddAttack(Attack attack)
    {
        _attackList.Add(attack);
    }

    public void RandomAttack()
    {
        var random = new Random();
        int index = random.Next(_attackList.Count);
        Attack attack = _attackList[index];
        Console.WriteLine($"{Name} the barbarian completes {attack.Name} and does {attack.Damage} to other player");
    }
}