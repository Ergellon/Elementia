using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : Spell {

    public Blessing()
    {
        power = 1;
        manacost = 2;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/sunbeams");

        cardname = "Благословление";
        description = "Прибавляет 4 здоровья и 1 атаку существу";
        isfriendlyspell = true;
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        att.battleline[slot].health += 4;
        att.battleline[slot].attack++;
    }
}
