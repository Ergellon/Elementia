﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public BattleManager battleManager;
    public BattleUIManager battleUIManager;
    public Player playerone, playertwo;
    public Player localplayer;

    GameObject[] playerobjects = new GameObject[2];
    Player[] players = new Player[2];

    public Card selectedcard;
    public Text infotext;
    public Text infotextsmall;
    public Button blocker;


    PhotonView photonView;
    void Start()
    {
        infotext.text = "Загрузка...";
        photonView = PhotonView.Get(this);
        playerobjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerobjects[0].GetComponent<Player>().photonView.viewID < playerobjects[1].GetComponent<Player>().photonView.viewID)
        {
            playerone = playerobjects[0].GetComponent<Player>();
            playertwo = playerobjects[1].GetComponent<Player>();
        }
        else
        {
            playerone = playerobjects[1].GetComponent<Player>();
            playertwo = playerobjects[0].GetComponent<Player>();
        }

        if (playerone.photonView.isMine)
        {
            localplayer = playerone;
            Debug.Log("local player one");
        }
        else if (playertwo.photonView.isMine)
        {
            localplayer = playertwo;
            Debug.Log("local player two");
        }
        
        players[0] = playerone; players[1] = playertwo;

        battleManager.SetPlayer(playerone, playertwo);
        battleUIManager.SetPlayer(playerone, playertwo);
        battleUIManager.SetNames();

        localplayer.FillSpellbookNumbers();





        playerone.hasturn = true;
        playerone.IncreaseMana();
        battleManager.attacker = playerone;
        battleManager.defender = playertwo;
        battleUIManager.UpdateStats();

    }
    void Update()
    {
         if (playerone.spellbooksync == 1 && playertwo.spellbooksync == 1)
        {
            LoadSpellbook();

            playertwo.spellbooksync = 2;
            playerone.spellbooksync = 2;

            battleUIManager.SetPortraits();
            battleUIManager.UpdateStats();
            CardSelected(0);
            battleUIManager.CardSelectedUI(0);
            infotext.text = "";

            blocker.gameObject.SetActive(false);
            StartCoroutine(TurnInfo());

        }
    }
    void LoadSpellbook()
    {
        
        playerone.FillSpellbook();
        playertwo.FillSpellbook();
        

        battleUIManager.SetSpellbookUI();

    }

    public void TurnSequence()
    {
        battleUIManager.UpdateStats();
        battleUIManager.UpdateBattleline();
        //battleUIManager.SaveHealthBeforeAttack();
        photonView.RPC("RPCSaveHealthBeforeAttack", PhotonTargets.All);
        photonView.RPC("CheckSequence", PhotonTargets.All);
        photonView.RPC("AttackSequence", PhotonTargets.All);
        photonView.RPC("RPCShowDamageSequence", PhotonTargets.All);
        battleUIManager.UpdateStats();
        battleUIManager.UpdateBattleline();
        photonView.RPC("ChangeTurn", PhotonTargets.All);


    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    public void SkipTurn()
    {
        if (localplayer.hasturn == true)
        {
            TurnSequence();
        }
    }


    [PunRPC]
    public void ChangeTurn()
    {
        for (int i = 0; i < 2; i++)
        {
            if (players[i].hasturn == true)
            {
                players[i].hasturn = false;
            }
            else
            {
                players[i].IncreaseMana();
                players[i].hasturn = true;
            }
        }
        battleManager.SwitchAttacker();
        battleUIManager.UpdateStats();
        StartCoroutine(TurnInfo());
    }

    public void CardSelected(int n)
    {
        if (localplayer.hasturn == true)
        {
            photonView.RPC("SelectCard", PhotonTargets.All, n);
        }
    }
    [PunRPC]
    public void SelectCard(int n)
    {
        if (playerone.hasturn == true)
        {
            selectedcard = playerone.spellbook[n].CopyCard();
        }
        else if (playertwo.hasturn == true)
        {
            selectedcard = playertwo.spellbook[n].CopyCard();
        }
        
    }
    public void CardPlaced(int slot)
    {

        if (localplayer.hasturn == true 
            && localplayer.CheckMana(selectedcard.element, selectedcard.manacost) == true
            && selectedcard.iscreature == true
            && localplayer.battlelinefilling[slot] == false)
        {
            photonView.RPC("PlaceCard", PhotonTargets.All, slot);
            localplayer.DecreaseMana(selectedcard.element, selectedcard.manacost);

            TurnSequence();
        }
    }
    [PunRPC]
    public void PlaceCard(int slot)
    {
        battleManager.PlaceCard((Creature)selectedcard, slot);
        battleUIManager.UpdateBattleline();
    }
    public void SpellUsed(int slot)
    {
        if(localplayer.hasturn == true && selectedcard.iscreature == false
            && localplayer.CheckMana(selectedcard.element, selectedcard.manacost) == true)
        {
            photonView.RPC("UseSpell", PhotonTargets.All, slot);
            localplayer.DecreaseMana(selectedcard.element, selectedcard.manacost);

            TurnSequence();
        }
    }
    [PunRPC]
    public void UseSpell (int slot)
    {
        battleManager.UseSpell((Spell)selectedcard, slot);
        
    }

    public void FriendlySpellUsed(int slot)
    {
        if (localplayer.hasturn == true && selectedcard.iscreature == false
            && selectedcard.isfriendlyspell == true
            && localplayer.CheckMana(selectedcard.element, selectedcard.manacost) == true)
        {
            photonView.RPC("UseFriendlySpell", PhotonTargets.All, slot);
            localplayer.DecreaseMana(selectedcard.element, selectedcard.manacost);

            TurnSequence();
        }
    }
    [PunRPC]
    public void UseFriendlySpell(int slot)
    {
        battleManager.UseSpell((Spell)selectedcard, slot);

    }
    [PunRPC]
    public void AttackSequence()
    {
        battleManager.AttackSequence(localplayer);
    }
    [PunRPC]
    public void CheckSequence()
    {
        battleManager.CheckSequence(localplayer);
    }
    public void SendChatMessage()
    {
        string s = "\n" + localplayer.playername + ":" + battleUIManager.inputchattext.text;
        photonView.RPC("RPCSendChatMessage", PhotonTargets.All, s);
        battleUIManager.inputchattext.text = "";
    }
    [PunRPC]
    public void RPCSendChatMessage(string t)
    {
        battleUIManager.chattext.text += t;
    }

    IEnumerator TurnInfo()
    {
        if (localplayer.hasturn)
        {
            infotextsmall.text = "Ваш ход!";

        }
        else
        {
            infotextsmall.text = "Ход противника...";
        }
        yield return new WaitForSeconds(1f);
        infotextsmall.text = "";
    }
    [PunRPC]
    public void RPCSaveHealthBeforeAttack()
    {
        battleUIManager.SaveHealthBeforeAttack();
    }
    [PunRPC]
    public void RPCShowDamageSequence()
    {
        StartCoroutine(battleUIManager.ShowDamageSequence());
    }
}