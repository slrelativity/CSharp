public class MagicCaster : Enemy
{
    public MagicCaster(string name) : base(name)
    {
        Health = 80;
        _attackList.Add(new Attack("Fireball", 25));
        _attackList.Add(new Attack("Lightning Bolt", 20));
        _attackList.Add(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy target)
    {
        target.Health += 40;
        Console.WriteLine($"{Name} heals {target.Name}, increasing their health to {target.Health}.");
    }
}