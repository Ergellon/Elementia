using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfSniper : Creature {


    public ElfSniper()
    {
        manacost = 4;
        attack = 2;
        health = 10;
        maxhealth = 10;
        element = "air";
        icon = Resources.Load<Sprite>("CardIcons/heavy-arrow");
        tag = "elf";

        cardname = "Эльф-снайпер";
        description = "Атакует непосредственно игрока противника";

    }

    public override void OnAttack(Player attacker, Player defender, int slot)
    {
        defender.health -= attack;
    }
}
