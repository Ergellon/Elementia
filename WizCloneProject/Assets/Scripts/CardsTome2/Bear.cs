using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Creature {

    public Bear()
    {
        manacost = 2;
        attack = 2;
        health = 8;
        maxhealth = 8;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/bear-face");


        cardname = "Медведь";
        description = "Если здоровье меньше максимума, то атака повышается на 2";



    }

    public override void OnCheck(Player attacker, Player defender, int slot)
    {
        base.OnCheck(attacker, defender, slot);
        if(health<maxhealth)
        {
            attack = 4;
        }
        else
        {
            attack = 2;
        }
    }
}
