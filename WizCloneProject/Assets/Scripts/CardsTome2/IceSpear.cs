using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : Spell {

    public IceSpear()
    {
        power = 8;
        manacost = 3;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/ice-spear");

        cardname = "Ледяное копье";
        description = "Наносит 8 урона одному существу противника.";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        if (def.battleline[slot].tag != "waterimmune" && def.battleline[slot].tag != "magicimmune")
        {
            def.battleline[slot].health -= power;
        }
    }
}
