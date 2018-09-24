using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyromancer : Creature {

    public Pyromancer()
    {
        manacost = 4;
        attack = 3;
        health = 9;
        maxhealth = 9;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/pyromaniac");
    

        cardname = "Пиромант";
        description = "При входе в игру наносит 5 урона существу напротив";

    }

    public override void OnSpawn(Player attacker, Player defender, int slot)
    {
        base.OnSpawn(attacker, defender, slot);
        if(defender.battlelinefilling[slot] == true)
        {
            defender.battleline[slot].health -= 5;
        }
    }
}
