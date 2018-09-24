using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madness : Spell {

    public Madness()
    {
        power = 6;
        manacost = 3;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/enrage");
        isfriendlyspell = true;

        cardname = "Безумие";
        description = "Повышает атаку существа на 2 и понижает его здоровье на 4.";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        att.battleline[slot].health -= 4;
        att.battleline[slot].attack += 2;
    }
}
