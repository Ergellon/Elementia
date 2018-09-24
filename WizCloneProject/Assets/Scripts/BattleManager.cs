using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public BattleUIManager battleUIManager;

    Player playerone, playertwo;

    public Player attacker, defender;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    public void SetPlayer (Player pone, Player ptwo)
    {
        playerone = pone;
        playertwo = ptwo;
    }
    public void SwitchAttacker()
    {
        Player p = attacker;
        attacker = defender;
        defender = p;
    }
    public void PlaceCard(Creature creature, int slot)
    {
        attacker.battleline[slot] = creature;
        attacker.battlelinefilling[slot] = true;
        attacker.battleline[slot].OnSpawn(attacker, defender, slot);
    }
    public void UseSpell (Spell spell, int slot)
    {
        spell.OnCast(attacker, defender, slot);
    }
    public void CheckSequence(Player localplayer)
    {
        for (int i = 0; i<7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (defender.battlelinefilling[j] == true)
                {
                    if (defender.battleline[j].health <= 0)
                    {
                        defender.battleline[j].OnDeath(attacker, defender, j);
                        defender.battleline[j].firstturn = true;
                        battleUIManager.RemoveCreatureOnUI(defender, j);
                        defender.battlelinefilling[j] = false;
                    }
                }
            }
            for (int j = 0; j < 7; j++)
            {
                if (attacker.battlelinefilling[j] == true)
                {
                    if (attacker.battleline[j].health <= 0)
                    {
                        attacker.selfkillspellused = true;
                        attacker.battleline[j].OnDeath(attacker, defender, j);
                        attacker.battleline[j].firstturn = true;
                        battleUIManager.RemoveCreatureOnUI(attacker, j);
                        attacker.battlelinefilling[j] = false;
                        attacker.selfkillspellused = false;
                    }
                }
            }

        }
        for (int i = 0; i<7; i++)
        {
            if (attacker.battlelinefilling[i] ==true)
            attacker.battleline[i].OnCheck(attacker, defender, i);
        }

    }
    public void AttackSequence(Player localplayer)
    {
        for (int i = 0; i<7; i++)
        {
                if (attacker.battlelinefilling[i] == true && attacker.battleline[i].firstturn == false)
                {
                    attacker.battleline[i].OnAttack(attacker, defender, i);
                }
                for (int j = 0; j < 7; j++)
                {
                    if (defender.battlelinefilling[j] == true)
                    {
                        if (defender.battleline[j].health <= 0)
                        {
                            defender.battleline[j].OnDeath(attacker, defender, j);
                            defender.battleline[j].firstturn = true;
                            battleUIManager.RemoveCreatureOnUI(defender, j);
                            defender.battlelinefilling[j] = false;
                        }
                    }
                }           

            battleUIManager.UpdateBattleline();

            if (attacker.battlelinefilling[i] == true && attacker.battleline[i].firstturn == true)
            {
                {
                    attacker.battleline[i].firstturn = false;
                }
            }
        }
    }
    
}
