using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour{

    GameLoader gameLoader;
    BattleLauncher battleLauncher;
    public string playername;

    public int health;
    public int fire, water, earth, air;
    public bool hasturn;

    public bool selfkillspellused = false;


    //Card[] spellbook = new Card[24];

    public Creature[] battleline = new Creature[7];
    public bool[] battlelinefilling = new bool[7];

    public List<Card> spellbook = new List<Card>();
    public int[] spellbooknumbers = new int[24];
    public int spellbooksync = 0;
    //List<Creature> battleline = new List<Creature>();
    //List<bool> battlelinefilling = new List<bool>();

    bool sendspellbooknumbers = false;

    public int portraitnumber = 0;


	void Start ()
    {
        health = 40;
        fire = water = earth = air = 0;
        hasturn = false;
        for (int i = 0; i<7; i++)
        {
            battlelinefilling[i] = false;
        }
        portraitnumber = battleLauncher.selectedportraitnumber;   
        //FillSpellbook();
        //Debug.Log("Spellbook filled");
    }

    public void FillSpellbookNumbers()
    {
        for (int i = 0; i < 24; i++)
        {
            spellbooknumbers[i] = PlayerPrefs.GetInt("spell" + i);
        }
        sendspellbooknumbers = true;
    }
	

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(playername);
            stream.SendNext(health);
            stream.SendNext(fire);
            stream.SendNext(water);
            stream.SendNext(earth);
            stream.SendNext(air);
            stream.SendNext(hasturn);
            for(int i = 0; i<7; i++)
            {
                stream.SendNext(battlelinefilling[i]);
            }
            if (sendspellbooknumbers == true)
            {
                for (int i = 0; i < 24; i++)
                {
                    stream.SendNext(spellbooknumbers[i]);
                }
                stream.SendNext(portraitnumber);
            }

        }
        else
        {
            this.playername = (string)stream.ReceiveNext();
            this.health = (int)stream.ReceiveNext();
            this.fire = (int)stream.ReceiveNext();
            this.water = (int)stream.ReceiveNext();
            this.earth = (int)stream.ReceiveNext();
            this.air = (int)stream.ReceiveNext();
            this.hasturn = (bool)stream.ReceiveNext();
            for (int i = 0; i < 7; i++)
            {
                this.battlelinefilling[i] = (bool)stream.ReceiveNext();
            }
            for (int j = 0; j<24; j++)
            {
               this.spellbooknumbers[j] = (int)stream.ReceiveNext();
            }
            this.portraitnumber = (int)stream.ReceiveNext();
        }
        if (spellbooksync == 0)
        {
            spellbooksync = 1;
        }
    }
    
    void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (photonView.isMine)
        {
            battleLauncher = GameObject.FindGameObjectWithTag("BattleLauncher").GetComponent<BattleLauncher>();
            playername = battleLauncher.playername;
        }
        gameLoader = GameObject.FindGameObjectWithTag("GameLoader").GetComponent<GameLoader>();
        gameLoader.playersready++;
    }

    public void ChangeHealth(int n)
    {
        health += n;
    }
    public void IncreaseMana()
    {
        fire++;water++;earth++;air++;
    }
    public void FillSpellbook()
    {
        for (int i = 0; i<24; i++)
        {
            if (spellbooknumbers[i] ==0)
            {              
                spellbook.Add(SpellBook.testspells1[i]());
            }
            else
            {
                spellbook.Add(SpellBook.testspells2[i]());
               
            }
        }
    }

    public bool CheckMana(string type, int amount)
    {
        if (type == "fire")
        {
            if (amount <= fire)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (type == "water")
        {
            if (amount <= water)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (type == "earth")
        {
            if (amount <= earth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (type == "air")
        {
            if (amount <= air)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void DecreaseMana(string type, int amount)
    {
        if (type == "fire")
        {
            fire -= amount;
        }
        if (type == "water")
        {
            water -= amount;
        }
        if (type == "earth")
        {
            earth -= amount;
        }
        if (type == "air")
        {
            air -= amount;
        }
    }
}


