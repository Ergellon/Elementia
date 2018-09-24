using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfKing : Creature {

    public DwarfKing()
    {
        manacost = 5;
        attack = 3;
        health = 12;
        maxhealth = 12;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/dwarf-king");
        tag = "dwarf";

        cardname = "Король гномов";
        description = "Вызывает при выходе двух гномов-пехотинцев в соседние слоты";

        
    }
    public override void OnSpawn(Player attacker, Player defender, int slot)
    {
        base.OnSpawn(attacker, defender, slot);
        if (slot > 0 && attacker.battlelinefilling[slot - 1] == false)
        {
            attacker.battleline[slot-1] = new Dwarf();
            attacker.battlelinefilling[slot-1] = true;
            attacker.battleline[slot-1].OnSpawn(attacker, defender, slot);
        }
        if (slot <6 && attacker.battlelinefilling[slot + 1] == false)
        {
            attacker.battleline[slot + 1] = new Dwarf();
            attacker.battlelinefilling[slot + 1] = true;
            attacker.battleline[slot+1].OnSpawn(attacker, defender, slot);
        }
    }
}
