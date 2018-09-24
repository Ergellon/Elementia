using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainlightning : Spell {

    public Chainlightning()
    {
        power = 3;
        manacost = 2;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/chain-lightning");

        cardname = "Цепная молния";
        description = "Наносит 3 урона всем существам противника и самому противнику.";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        for (int i = 0; i < 7; i++)
        {
            if (def.battlelinefilling[i] == true && def.battleline[i].tag != "magicimmune" && def.battleline[i].tag != "airimmune")
            {
                def.battleline[i].health -= power;
            }
        }
        def.health -= power;

    }
}
