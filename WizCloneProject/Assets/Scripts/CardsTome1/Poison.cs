using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Spell {

    public Poison()
    {
        power = 1;
        manacost = 5;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/poison-bottle");

        cardname = "Яд";
        description = "Уменьшает атаку всех вражеских существ на 1";
    }

    public override void OnCast(Player attacker, Player defender, int slot)
    {
        for(int i = 0; i<7; i++)
        {
            if (defender.battlelinefilling[i] == true)
            {
                defender.battleline[i].attack -= power;
            }
        }
    }
}
