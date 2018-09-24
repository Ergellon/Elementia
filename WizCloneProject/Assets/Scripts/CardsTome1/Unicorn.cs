using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : Creature {

    public Unicorn()
    {
        manacost = 5;
        attack = 3;
        health = 12;
        maxhealth = 12;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/unicorn");

        cardname = "Единорог";
        description = "Каждый ход добавляет 1 здоровье существам игрока";

        defence = 0;
        magicmodifier = 1;

    }
    public override void OnAttack(Player attacker, Player defender, int slot)
    {
        for (int i = 0; i < 7; i++)
        {
            if (attacker.battlelinefilling[i] == true)
            {
                attacker.battleline[i].health += 1;
            }
            if (attacker.battleline[i].health>attacker.battleline[i].maxhealth)
            {
                attacker.battleline[i].health = attacker.battleline[i].maxhealth;
            }
        }

    }
}
