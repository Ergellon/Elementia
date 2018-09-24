using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcChieftain : Creature {

    public OrcChieftain()
    {
        manacost = 5;
        attack = 4;
        health = 12;
        maxhealth = 12;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/horned-helm");
        tag = "orc";

        cardname = "Вождь орков";
        description = "Добавляет 1 атаку всем оркам";

    }
    public override void OnSpawn(Player att, Player def, int slot)
    {
        base.OnSpawn(att, def, slot);
        for (int i = 0; i<7; i++)
        {
            if (att.battlelinefilling[i] == true && att.battleline[i].tag == "orc" && i !=slot)
            {
                att.battleline[i].attack++;
            }
        }
        
    }

    public override void OnDeath(Player att, Player def, int slot)
    {
        if (att.selfkillspellused == true)
        {
            for (int i = 0; i < 7; i++)
            {
                if (att.battlelinefilling[i] == true && att.battleline[i].tag == "orc" && i != slot)
                {
                    att.battleline[i].attack--;
                }
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (def.battlelinefilling[i] == true && def.battleline[i].tag == "orc" && i != slot)
                {
                    def.battleline[i].attack--;
                }
            }
        }
    }
}
