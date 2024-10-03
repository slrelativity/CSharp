MeleeFighter meleeFighter = new MeleeFighter("Skeletor");
RangedFighter rangedFighter = new RangedFighter("Sandor");
MagicCaster magicCaster = new MagicCaster("Dumbledore");

meleeFighter.PerformAttack(rangedFighter, meleeFighter._attackList[2]);
meleeFighter.Rage(magicCaster);

rangedFighter.PerformAttack(meleeFighter, rangedFighter._attackList[0]);
rangedFighter.Dash();
rangedFighter.PerformAttack(meleeFighter, rangedFighter._attackList[0]);

magicCaster.PerformAttack(meleeFighter, magicCaster._attackList[0]);
magicCaster.Heal(rangedFighter);
magicCaster.Heal(magicCaster);