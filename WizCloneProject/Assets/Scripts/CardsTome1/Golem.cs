using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Creature {

    public Golem()
    {
        manacost = 4;
        attack = 3;
        health = 12;
        maxhealth = 12;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/ice-golem");

        cardname = "Голем";
        description = "Иммунитет к магии";
        tag = "magicimmune";

        defence = 0;

    }
}
