using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Djinni : Creature {

    public Djinni()
    {
        manacost = 5;
        attack = 3;
        health = 12;
        maxhealth = 12;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/ifrit");

        cardname = "Джинн";
        description = "Бьет по трем соседствующим слотам противника.";

        defence = 0;
    }

    override public void OnAttack(Player attacker, Player defender, int slot)
    {
        if (defender.battlelinefilling[slot] == true)
        {
            defender.battleline[slot].health -= (attacker.battleline[slot].attack - defender.battleline[slot].defence);
        }
        else
        {
            defender.health -= attacker.battleline[slot].attack;
        }
        if ((slot > 0) && defender.battlelinefilling[slot - 1] == true)
        {
            defender.battleline[slot-1].health -= (attacker.battleline[slot].attack - defender.battleline[slot-1].defence);
        }
        if ((slot < 6) && defender.battlelinefilling[slot + 1] == true)
        {
            defender.battleline[slot+1].health -= (attacker.battleline[slot].attack - defender.battleline[slot+1].defence);
        }
    }
}
