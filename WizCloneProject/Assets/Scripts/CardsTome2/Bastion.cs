using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bastion : Creature {

    public Bastion()
    {
        manacost = 4;
        attack = 0;
        health = 20;
        maxhealth = 20;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/defensive-wall");

        cardname = "Бастион";
        description = "При выходе восстанавливает 4 здоровья всем гномам";

    }
    public override void OnSpawn(Player attacker, Player defender, int slot)
    {
        base.OnSpawn(attacker, defender, slot);
        for(int i = 0; i<7; i++)
        {
            if (attacker.battlelinefilling[i] == true && attacker.battleline[i].tag == "dwarf")
            {
                attacker.battleline[i].health += 4;
                if (attacker.battleline[i].health > attacker.battleline[i].maxhealth)
                {
                    attacker.battleline[i].health = attacker.battleline[i].maxhealth;
                }
            }
        }
    }
    public override void OnCheck(Player attacker, Player defender, int slot)
    {
        base.OnCheck(attacker, defender, slot);
        attack = 0;
    }
}
