using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpirit : Creature {

    public FireSpirit()
    {
        manacost = 1;
        attack = 2;
        health = 6;
        maxhealth = 6;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/unfriendly-fire");
        tag = "fireimmune";

        cardname = "Огненный дух" ;
        description = "Иммунитет к магии огня";

    }

}
