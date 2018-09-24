using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldbearer : Creature {


    public Shieldbearer()
    {
        manacost = 3;
        attack = 2;
        health = 10;
        maxhealth = 10;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/shield");

        cardname = "Щитоносец";
        description = "Защищает соседних юнитов на 1";

        tag = "shieldbearer";

        defence = 0;

    }

    public override void OnSpawn(Player att, Player def, int slot)
    {
        base.OnSpawn(att, def, slot);
        if ((slot - 1) > -1 && att.battlelinefilling[slot - 1] == true)
        {
            att.battleline[slot - 1].defence += 1;
        }
        if ((slot + 1) < 7 && att.battlelinefilling[slot + 1] == true)
        {
            att.battleline[slot + 1].defence += 1;
        }
    }

    public override void OnDeath(Player att, Player def, int slot)
    {
        if (att.selfkillspellused == true)
        {
            if (slot > 0 && att.battlelinefilling[slot - 1] == true)
            {
                att.battleline[slot - 1].defence -= 1;
            }
            if (slot < 6 && att.battlelinefilling[slot + 1] == true)
            {
                att.battleline[slot + 1].defence -= 1;
            }
        }
        else
        {
            if (slot > 0 && def.battlelinefilling[slot - 1] == true)
            {
                def.battleline[slot - 1].defence -= 1;
            }
            if (slot < 6 && def.battlelinefilling[slot + 1] == true)
            {
                def.battleline[slot + 1].defence -= 1;
            }
        }
    }
}
