using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonefall : Spell {

    public Stonefall()
    {
        power = 6;
        manacost = 5;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/ancient-ruins");

        cardname = "Обвал";
        description = "Наносит 6 урона всем существам противника.";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        for (int i = 0; i < 7; i++)
        {
            if (def.battlelinefilling[i] == true && def.battleline[i].tag != "magicimmune")
            {
                def.battleline[slot].health -= power ;
            }
        }

    }
}
