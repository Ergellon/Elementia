using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Card {

    public bool firstturn;
    public int defence;
    public float magicmodifier;
    public int maxhealth;
    public string tag;

    /*
    manacost;
    attack;
    health;
    element;
    icon;

    cardname;
    description;

*/
    public Creature()
    {
        iscreature = true;
        firstturn = true;
        isfriendlyspell = false;
        tag = " ";
        defence = 0;
    }
    public virtual void OnSpawn(Player attacker, Player defender, int slot)
    {
        for (int i = 0; i< 7; i++)
        {
            if (defender.battlelinefilling[i] == true && defender.battleline[i].tag == "archer")
            {
                this.health--;
            }
            if ( slot > 0 && attacker.battlelinefilling[slot-1] == true  && attacker.battleline[slot-1].tag == "shieldbearer")
            {
                attacker.battleline[slot].defence++;
            }
            if ( slot < 6 && attacker.battlelinefilling[slot+1] == true && attacker.battleline[slot + 1].tag == "shieldbearer")
            {
                attacker.battleline[slot].defence++;
            }
            if (slot > 0 && attacker.battlelinefilling[slot-1] == true && attacker.battleline[slot - 1].tag == "bannerman")
            {
                attacker.battleline[slot].attack++;
            }
            if (slot < 6 && attacker.battlelinefilling[slot + 1] == true  && attacker.battleline[slot + 1].tag == "bannerman")
            {
                attacker.battleline[slot].attack++;
            }
        }

    }
    public virtual void OnAttack(Player attacker, Player defender, int slot)
    {
        if (defender.battlelinefilling[slot] == true)
        {
            defender.battleline[slot].health -= (attacker.battleline[slot].attack - defender.battleline[slot].defence) ;
        }
        else
        {
            defender.health -= attacker.battleline[slot].attack ;          
        }
    }
    public virtual void OnDefence(Player attacker, Player defender, int slot)
    {

    }

    public virtual void OnCheck(Player attacker, Player defender, int slot)
    {

    }
    public virtual void OnDeath(Player attacker, Player defender, int slot)
    {

    }

}
