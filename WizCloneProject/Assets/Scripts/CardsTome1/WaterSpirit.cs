using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpirit : Creature {

    public WaterSpirit()
    {
        manacost = 1;
        attack = 2;
        health = 6;
        maxhealth = 6;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/gooey-daemon");

        cardname = "Водяной дух";
        description = "При выходе лечит игрока на 2";

        defence = 0;
    }

    public override void OnSpawn(Player attacker, Player defender, int slot)
    {
        attacker.health += 2;
    }
}
