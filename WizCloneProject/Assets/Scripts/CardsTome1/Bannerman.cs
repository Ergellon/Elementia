using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bannerman : Creature {

    public Bannerman()
    {
        manacost = 4;
        attack = 3;
        health = 8;
        maxhealth = 8;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/rally-the-troops");

        cardname = "Знаменосец";
        description = "Прибавляет 1 атаку соседним суещствам.";
        tag = "bannerman";

        defence = 0;


    }

    public override void OnSpawn(Player att, Player def, int slot)
    {
        if ((slot - 1) > -1 && att.battlelinefilling[slot - 1] == true)
        {
            att.battleline[slot - 1].attack += 1;
        }
        if ((slot + 1) < 7 && att.battlelinefilling[slot + 1] == true)
        {
            att.battleline[slot + 1].attack += 1;
        }
    }

    public override void OnDeath(Player att, Player def, int slot)
    {
        if (att.selfkillspellused == true)
        {
            if ((slot - 1) > -1 && att.battlelinefilling[slot - 1] == true)
            {
                att.battleline[slot - 1].attack -= 1;
            }
            if ((slot + 1) < 7 && att.battlelinefilling[slot + 1] == true)
            {
                att.battleline[slot + 1].attack -= 1;
            }
        }
        else
        {

            if ((slot - 1) > -1 && def.battlelinefilling[slot - 1] == true)
            {
                def.battleline[slot - 1].attack -= 1;
            }
            if ((slot + 1) < 7 && def.battlelinefilling[slot + 1] == true)
            {
                def.battleline[slot + 1].attack -= 1;
            }
        }
    }
}
