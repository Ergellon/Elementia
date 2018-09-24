using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingWater : Spell {

    public HealingWater()
    {
        power = 1;
        manacost = 3;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/holy-water");

        cardname = "Исцеляющая вода";
        description = "Исцеляет полностью один юнит игрока";

        isfriendlyspell = true;
    }

    public override void OnCast(Player attacker, Player defender, int slot)
    {
        attacker.battleline[slot].health = attacker.battleline[slot].maxhealth;
    }
}
