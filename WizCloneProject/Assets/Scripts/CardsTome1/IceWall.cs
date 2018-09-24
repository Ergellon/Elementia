using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : Creature {

    public IceWall()
    {
        manacost = 2;
        attack = 0;
        health = 24;
        maxhealth = 24;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/stalactites");

        cardname = "Стена льда";
        description = "Теряет 2 здоровья каждый ход";

    }
    public override void OnAttack(Player attacker, Player defender, int slot)
    {
        
    }
    public override void OnCheck(Player attacker, Player defender, int slot)
    {
        base.OnCheck(attacker, defender, slot);
        attack = 0;
        this.health -= 2;
    }
}

