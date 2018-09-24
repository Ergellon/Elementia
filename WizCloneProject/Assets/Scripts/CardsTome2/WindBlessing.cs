using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlessing : Spell {

    public WindBlessing()
    {
        power = 2;
        manacost = 5;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/swirl-ring");
        isfriendlyspell = true;

        cardname = "Попутный ветер";
        description = "Лечит существа игрока на 2, наносит 2 урона существам противника.";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        for (int i = 0; i < 7; i++)
        {
            if (def.battlelinefilling[i] == true && def.battleline[i].tag != "airimmune" && def.battleline[i].tag != "magicimmune")
            {
                def.battleline[i].health -= power;
            }
            if (att.battlelinefilling[i] == true)
            {
                att.battleline[i].health += power;
            }
        }

    }
}
