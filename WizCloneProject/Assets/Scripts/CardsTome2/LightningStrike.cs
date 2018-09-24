using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : Spell {

    public LightningStrike()
    {
        power = 6;
        manacost = 3;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/lightning-branches");

        cardname = "Разряд молнии";
        description = "Наносит 6 урона существу противника и 6 урона противнику";
    }


    override public void OnCast(Player att, Player def, int slot)
    {
        def.battleline[slot].health -= power;
        def.health -= power;

    }
}
