using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturePower : Spell {

    public NaturePower()
    {
        power = 1;
        manacost = 3;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/flowers");
        isfriendlyspell = true;

        cardname = "Мощь природы";
        description = "Лечит 1 здоровья всем существам и добавляет 6 здоровья игроку";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        for (int i = 0; i < 7; i++)
        {
            if (att.battlelinefilling[i] == true)
            {
                att.battleline[i].health += 1;
                if (att.battleline[i].health > att.battleline[i].maxhealth)
                {
                    att.battleline[i].health = att.battleline[i].maxhealth;
                }
            }
        }
        att.health += 6;
    }
}
