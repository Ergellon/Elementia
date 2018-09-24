using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : Spell {

    public Storm()
    {
        power = 6;
        manacost = 6;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/twister");

        cardname = "Шторм";
        description = "Заполняет все свободные слоты игрока духами воздуха";
        isfriendlyspell = true;
    }

    public override void OnCast(Player attacker, Player defender, int slot)
    {
        for (int i =0; i<7;i++)
        {
            if (attacker.battlelinefilling[i] == false)
            {
                attacker.battleline[i] = new AirSpirit();
                attacker.battlelinefilling[i] = true;
                attacker.battleline[i].OnSpawn(attacker, defender, slot);
            }
        }
    }
}
