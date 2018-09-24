using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Creature {

    public Dragon()
    {
        manacost = 6;
        attack = 4;
        health = 15;
        maxhealth = 6;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/spiked-dragon-head");
        tag = "magicimmune";

        cardname = "Дракон";
        description = "Иммунитет к магии";

    }
}
