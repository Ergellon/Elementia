using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Creature {

    public Archer()
    {
        manacost = 1;
        attack = 1;
        health = 8;
        maxhealth = 8;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/high-shot");
        tag = "archer";

        cardname = "Эльф - стрелок";
        description = "Наносит 1 урона существам при их выходе на поле боя";

        defence = 0;

        //Cпособность находится в функции creature
    }

}
