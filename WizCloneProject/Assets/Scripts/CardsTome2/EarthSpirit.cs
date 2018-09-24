using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpirit : Creature {

    public EarthSpirit()
    {
        manacost = 1;
        attack = 2;
        health = 5;
        maxhealth = 5;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/golem-head");
        

        cardname = "Дух земли";
        description = "Неуязвим в свой первый ход";

    }

    public override void OnCheck(Player attacker, Player defender, int slot)
    {
        base.OnCheck(attacker, defender, slot);
        if (firstturn == true)
        {
            defence = 99;
        }
        else
        {
            defence = 0;
        }
    }
}
