using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : Creature {

    public Kraken()
    {
        manacost = 5;
        attack = 3;
        health = 8;
        maxhealth = 8;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/kraken-tentacle");
       

        cardname = "Кракен";
        description = "Восстанавливает себе 2 здоровья каждый ход";

    }

    public override void OnCheck(Player attacker, Player defender, int slot)
    {
        base.OnCheck(attacker, defender, slot);

        health += 2;
        if (health>maxhealth)
        {
            health = maxhealth;
        }
        
    }
}
