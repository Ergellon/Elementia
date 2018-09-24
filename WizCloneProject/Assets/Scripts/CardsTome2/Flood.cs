using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flood : Spell {

    public Flood()
    {
        power = 99;
        manacost = 6;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/waterfall");

        cardname = "Наводнение";
        description = "Уничтожает все существа со стоимостью 3 и меньше.";
    }


    public override void OnCast(Player att, Player def, int slot)
    {

        for (int i = 0; i < 7; i++)
        {
            if (att.battlelinefilling[i] == true && att.battleline[i].tag != "waterimmune"
                && att.battleline[i].tag != "magicimmune" && att.battleline[i].manacost<4)
            {
                att.battleline[i].health -= power;
            }

            if (def.battlelinefilling[i] == true && def.battleline[i].tag != "waterimmune"
                && def.battleline[i].tag != "magicimmune" && def.battleline[i].manacost < 4)
            {
                def.battleline[i].health -= power;
            }

        }
    }
}
