using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Creature {

    public Healer()
    {
        manacost = 4;
        attack = 3;
        health = 12;
        maxhealth = 12;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/heart-bottle");

        cardname = "Лекарь";
        description = "При входе в игру лечит все существа игрока на 4";

        defence = 0;
        magicmodifier = 1;

    }
    public override void OnSpawn(Player attacker, Player defender, int slot)
    {
        for (int i = 0; i < 7; i++)
        {
            if (attacker.battlelinefilling[i] == true && i != slot)
            {
                attacker.battleline[i].health += 4;
                if (attacker.battleline[i].health > attacker.battleline[i].maxhealth)
                {
                    attacker.battleline[i].health = attacker.battleline[i].maxhealth;
                }
            }
        }

    }
}
