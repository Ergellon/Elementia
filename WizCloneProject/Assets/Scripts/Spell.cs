using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Card {

    public int power;

    public Spell()
    {
        attack = -1;
        health = -1;
        isfriendlyspell = false;
    }
    public virtual void OnCast(Player attacker, Player defender, int slot)
    {

    }
}
