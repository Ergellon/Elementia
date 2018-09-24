using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpellBook {

    //delegate void SpellbookD();

    //public static List<System.Func<Card>> testspells1;
    //public static List<System.Func<Card>> testspells2;
    public static System.Func<Card>[] testspells1;
    public static System.Func<Card>[] testspells2;

    static SpellBook()
    {
        //testspells1 = new List<System.Func<Card>>();
        //testspells2 = new List<System.Func<Card>>();
        testspells1 = new System.Func<Card>[24];
        testspells2 = new System.Func<Card>[24];

        testspells1[0] = () => new FireSpirit();
        testspells1[1] = () => new Firebolt();
        testspells1[2] = () => new Orc();
        testspells1[3] = () => new Fireball();
        testspells1[4] = () => new Djinni();
        testspells1[5] = () => new Volcano();
        testspells1[6] = () => new WaterSpirit();
        testspells1[7] = () => new IceWall();
        testspells1[8] = () => new HealingWater();
        testspells1[9] = () => new Healer();
        testspells1[10] = () => new Poison();
        testspells1[11] = () => new Hydra();
        testspells1[12] = () => new Dwarf();
        testspells1[13] = () => new Gargoyle();
        testspells1[14] = () => new Shieldbearer();
        testspells1[15] = () => new Golem();
        testspells1[16] = () => new Stonefall();
        testspells1[17] = () => new AncientProtector();
        testspells1[18] = () => new Archer();
        testspells1[19] = () => new Chainlightning();
        testspells1[20] = () => new Greateagle();
        testspells1[21] = () => new Bannerman();
        testspells1[22] = () => new Unicorn();
        testspells1[23] = () => new Desintegration();

        testspells2[0] = () => new OrcSoldier();
        testspells2[1] = () => new LiquidFire();
        testspells2[2] = () => new Madness();
        testspells2[3] = () => new Pyromancer();
        testspells2[4] = () => new OrcChieftain();
        testspells2[5] = () => new Dragon();
        testspells2[6] = () => new NagaWarrior();
        testspells2[7] = () => new Blessing();
        testspells2[8] = () => new IceSpear();
        testspells2[9] = () => new Regeneration();
        testspells2[10] = () => new Kraken();
        testspells2[11] = () => new Flood();
        testspells2[12] = () => new EarthSpirit();
        testspells2[13] = () => new Bear();
        testspells2[14] = () => new NaturePower();
        testspells2[15] = () => new Bastion();
        testspells2[16] = () => new DwarfKing();
        testspells2[17] = () => new Balance();
        testspells2[18] = () => new AirSpirit();
        testspells2[19] = () => new ElfChampion();
        testspells2[20] = () => new LightningStrike();
        testspells2[21] = () => new ElfSniper();
        testspells2[22] = () => new WindBlessing();
        testspells2[23] = () => new Storm();
    }
    
}
