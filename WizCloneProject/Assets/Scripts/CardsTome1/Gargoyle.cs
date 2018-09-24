using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : Creature {

    public Gargoyle()
    {
        manacost = 2;
        attack = 3;
        health = 8;
        maxhealth = 8;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/gargoyle");

        cardname = "Горгулья";
        description = "Получает на 1 урона меньше от атак";

        defence = 1;

    }
}
