using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regeneration : Spell {

    public Regeneration()
    {
        power = 1;
        manacost = 4;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/self-love");
        isfriendlyspell = true;

        cardname = "Регенерация";
        description = "Лечит 4 здоровья существу и добавляет 8 здоровья игроку";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        att.battleline[slot].health += 4;
        if (att.battleline[slot].health>att.battleline[slot].maxhealth)
        {
            att.battleline[slot].health = att.battleline[slot].maxhealth;
        }
        att.health += 8;
    }
}
