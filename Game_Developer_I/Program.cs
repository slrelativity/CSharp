        Enemy bandit = new Enemy("Bandit");

        Attack energyblast = new Attack("an EnergyBlast", 20);
        Attack punch = new Attack("a Punch", 15);
        Attack throwAxe = new Attack("a Throw of an Axe", 20);


        bandit.AddAttack(energyblast);
        bandit.AddAttack(punch);
        bandit.AddAttack(throwAxe);

        for (int i = 0; i < 5; i++)
        {
            bandit.RandomAttack();
        }



