using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Creature {

    public Dwarf()
    {
        manacost = 1;
        attack = 2;
        health = 8;
        maxhealth = 8;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/dwarf-helmet");

        cardname = "Дварф";
        description = "Особых свойств нет";

        tag = "dwarf";

        defence = 0;

    }
}
