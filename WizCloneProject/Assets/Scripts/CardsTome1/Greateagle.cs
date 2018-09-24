using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greateagle : Creature {

    public Greateagle()
    {
        manacost = 3;
        attack = 3;
        health = 11;
        maxhealth = 11;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/crow-dive");

        cardname = "Великий орел";
        description = "Бьет в свой первый ход";

        defence = 0;

        firstturn = false;

    }
}
