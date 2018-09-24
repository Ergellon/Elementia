using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcSoldier : Creature {

    public OrcSoldier()
    {
        manacost = 1;
        attack = 1;
        health = 6;
        maxhealth = 6;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/orc-head");
        tag = "orc";

        cardname = "Орк-солдат";
        description = "Получает 1 к атаке за каждого соседнего орка";

    }
    public override void OnSpawn(Player attacker, Player defender, int slot)
    {
        base.OnSpawn(attacker, defender, slot);
        if (slot>0 && attacker.battlelinefilling[slot-1] == true && attacker.battleline[slot-1].tag == "orc")
        {
            attack++;
            attacker.battleline[slot - 1].attack++;
        }
        if (slot < 6 && attacker.battlelinefilling[slot + 1] == true && attacker.battleline[slot + 1].tag == "orc")
        {
            attack++;
            attacker.battleline[slot + 1].attack++;
        }
    }
    public override void OnDeath(Player attacker, Player defender, int slot)
    {
        if (attacker.selfkillspellused == true)
        {
            base.OnDeath(attacker, defender, slot);
            if (slot > 0 && attacker.battlelinefilling[slot - 1] == true && attacker.battleline[slot - 1].tag == "orc")
            {
                attacker.battleline[slot - 1].attack--;
            }
            if (slot < 6 && attacker.battlelinefilling[slot + 1] == true && attacker.battleline[slot + 1].tag == "orc")
            {
                attacker.battleline[slot + 1].attack--;
            }
        }
        else
        {
            base.OnDeath(attacker, defender, slot);
            if (slot > 0 && defender.battlelinefilling[slot - 1] == true && defender.battleline[slot - 1].tag == "orc")
            {
                defender.battleline[slot - 1].attack--;
            }
            if (slot < 6 && defender.battlelinefilling[slot + 1] == true && defender.battleline[slot + 1].tag == "orc")
            {
                defender.battleline[slot + 1].attack--;
            }
        }
    }
}
