using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desintegration : Spell {

    public Desintegration()
    {
        power = 99;
        manacost = 6;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/deadly-strike");

        cardname = "Дезинтеграция";
        description = "Уничтожает существо противника.";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        def.battleline[slot].health -= power;
    }
}
