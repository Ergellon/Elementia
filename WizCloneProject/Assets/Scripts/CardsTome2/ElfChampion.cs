using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfChampion :  Creature {

    public ElfChampion()
    {
        manacost = 2;
        attack = 2;
        health = 8;
        maxhealth = 8;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/elf-helmet");
        tag = "elf";

        cardname = "Эльф-чемпион";
        description = "Каждый ход лечит на 1 всех эльфов на поле боя";

    }

    public override void OnCheck(Player attacker, Player defender, int slot)
    {
        base.OnCheck(attacker, defender, slot);
        for (int i = 0; i < 7; i++)
        {
            if (attacker.battlelinefilling[i] == true && i != slot 
                && (attacker.battleline[i].tag == "elf"||attacker.battleline[i].tag == "archer"))
            {
                attacker.battleline[i].health += 1;
                if (attacker.battleline[i].health > attacker.battleline[i].maxhealth)
                {
                    attacker.battleline[i].health = attacker.battleline[i].maxhealth;
                }
            }
        }

    }
}
