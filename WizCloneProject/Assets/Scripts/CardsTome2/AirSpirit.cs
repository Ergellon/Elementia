using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpirit : Creature {

    public AirSpirit()
    {
        manacost = 1;
        attack = 2;
        health = 6;
        maxhealth = 6;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/hidden");
        tag = "airimmune";

        cardname = "Дух ветра";
        description = "Иммунитет к магии воздуха";

    }
}
