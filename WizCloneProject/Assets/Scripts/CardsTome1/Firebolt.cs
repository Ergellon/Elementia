using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : Spell {

    public Firebolt()
    {
        power = 6;
        manacost = 2;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/burning-dot");

        cardname = "Огненная стрела";
        description = "Наносит 6 урона одному существу противника.";
    }


    override public void  OnCast(Player att, Player def, int slot)
    {
        if (def.battleline[slot].tag != "fireimmune" && def.battleline[slot].tag != "magicimmune")
        {
            def.battleline[slot].health -= power;
        }
    }
}
