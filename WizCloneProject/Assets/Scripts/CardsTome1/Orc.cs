using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Creature {

	public Orc () {
        manacost = 3;
        attack = 3;
        health = 10;
        maxhealth = 10;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/heavy-helm");

        cardname = "Орк - берсерк";
        description = "Наносит на 2 больше урона вражескому игроку";
        tag = "orc";

    }

    override public void OnAttack(Player attacker, Player defender, int slot)
    {
        if (defender.battlelinefilling[slot] == true)
        {
            defender.battleline[slot].health -= (attacker.battleline[slot].attack - defender.battleline[slot].defence);
        }
        else
        {
            defender.health -= attacker.battleline[slot].attack + 2;
        }
    }
	
}
