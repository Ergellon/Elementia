using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra : Creature {

    public Hydra()
    {
        manacost = 6;
        attack = 2;
        health = 16;
        maxhealth = 16;
        element = "water";
        icon = Resources.Load<Sprite>("CardIcons/hydra");

        cardname = "Гидра";
        description = "Бьет сразу по всем слотам противника и самому противнику";

        defence = 0;

    }
    public override void OnAttack(Player attacker, Player defender, int slot)
    {
        for (int i = 0; i<7; i++)
        {
            if (defender.battlelinefilling[i] == true)
            {
                defender.battleline[i].health -= attack;
            }
        }
        defender.health -= attack;
    }
}
