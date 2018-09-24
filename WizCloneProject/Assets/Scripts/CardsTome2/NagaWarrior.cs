using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagaWarrior : Creature {

    public NagaWarrior()
    {
        manacost = 1;
        attack = 2;
        health = 6;
        maxhealth = 6;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/mermaid");
        tag = "waterimmune";

        cardname = "Нага-воин";
        description = "Иммунитет к магии воды";

    }
}
