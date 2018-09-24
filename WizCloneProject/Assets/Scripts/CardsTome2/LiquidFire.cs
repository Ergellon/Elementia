using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFire : Spell {

    public LiquidFire()
    {
        power = 4;
        manacost = 2;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/flame-claws");

        cardname = "Огненные брызги";
        description = "Наносит 4 урона трем соседствующим существам противника";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        if (def.battleline[slot].tag != "fireimmune" && def.battleline[slot].tag != "magicimmune")
        {
            def.battleline[slot].health -= power;
        }
        if (slot > 0 && def.battleline[slot-1].tag != "fireimmune" && def.battleline[slot-1].tag != "magicimmune")
        {
            def.battleline[slot-1].health -= power;
        }
        if (slot<6 && def.battleline[slot+1].tag != "fireimmune" && def.battleline[slot+1].tag != "magicimmune")
        {
            def.battleline[slot+1].health -= power;
        }
    }
}
