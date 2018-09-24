using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell {

    public Fireball()
    {
        power = 8;
        manacost = 4;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/burning-meteor");

        cardname = "Огненный шар";
        description = "Наносит 8 урона существу противника и 4 урона его соседям";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        if (def.battleline[slot].tag != "fireimmune" && def.battleline[slot].tag != "magicimmune")
        {
            def.battleline[slot].health -= power;
        }
        if (slot - 1>=0 && def.battlelinefilling[slot-1] == true
            && def.battleline[slot-1].tag != "fireimmune" && def.battleline[slot-1].tag != "magicimmune")
        {
            def.battleline[slot-1].health -= 4 ;
        }
        if (slot + 1 <= 6 && def.battlelinefilling[slot + 1] == true
    && def.battleline[slot+1].tag != "fireimmune" && def.battleline[slot+1].tag != "magicimmune")
        {
            def.battleline[slot+1].health -= 4;
        }
    }
}
