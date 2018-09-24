using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : Spell {

    public Balance()
    {
        power = 5;
        manacost = 6;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/life-in-the-balance");

        cardname = "Равновесие";
        description = "Передает 5 здоровья от игрока с большим здоровьем игроку с меньшим";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        if (att.health>def.health)
        {
            att.health -= power;
            def.health += power;
        }
        else if (att.health <def.health )
        {
            att.health += power;
            def.health -= power;
        }
    }
}
