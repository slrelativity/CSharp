public class MeleeFighter : Enemy
    {

        Random rand = new Random();
        public MeleeFighter(string name) : base(name)
        {
        _attackList.Add(new Attack("Punch", 20));
        _attackList.Add(new Attack("Kick", 15));
        _attackList.Add(new Attack("Tackle", 25));
        }

    public void Rage(Enemy target)
    {
        Attack randomAttack = _attackList[rand.Next(_attackList.Count)];
        int rageAttack = randomAttack.Damage +10;
        target.Health -= rageAttack;
        Console.WriteLine($"Melee Figter rages and completes {randomAttack.Name} and deals {rageAttack}");
    }
}