using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    Player player, enemy;

    public Text playername, enemyname;

    public Text playerhealth, enemyhealth;
    public Text playerfire, playerwater, playerearth, playerair;
    public Text enemyfire, enemywater, enemyearth, enemyair;
    public Text cardname, carddesciption;




    public List<GameObject> playerbattleline = new List<GameObject>();
    public List<GameObject> enemybattleline = new List<GameObject>();

    public Text[] playercreatureattack = new Text[7];
    public Text[] enemycreatureattack = new Text[7];
    public Text[] playercreaturehealth = new Text[7];
    public Text[] enemycreaturehealth = new Text[7];
    public Text[] playercreaturecost = new Text[7];
    public Text[] enemycreaturecost = new Text[7];

    public Image[] playercreatureicon = new Image[7];
    public Image[] enemycreatureicon = new Image[7];

    public Text[] playerdamageindicators = new Text[7];
    public Text[] enemydamageindicators = new Text[7];
    public int[] playerhealthbeforeattack = new int[7];
    public int[] enemyhealthbeforeattack = new int[7];
    public bool[] playerslotwasfilled = new bool[7];
    public bool[] enemyslotwasfilled = new bool[7];


    public List<Button> spellbookbuttons = new List<Button>();
    public List<Text> spellbookattack = new List<Text>();
    public List<Text> spellbookhealth = new List<Text>();
    public List<Text> spellbookcost = new List<Text>();
    public List<Image> spellbookicon = new List<Image>();

    public Text selectedcarduiattack;
    public Text selectedcarduihealth;
    public Text selectedcarduimanacost;
        public Image selectedcarduiicon;

    public Text chattext;
    public Text inputchattext;

    public List<Sprite> portraits = new List<Sprite>();
    public Image playerportrait;
    public Image enemyportrait;


    void Start ()
    {
		
	}
	
	void Update ()
    {
      
    }

    public void UpdateStats()
    {
        playerhealth.text = player.health.ToString(); enemyhealth.text = enemy.health.ToString();
        playerfire.text = player.fire.ToString(); enemyfire.text = enemy.fire.ToString();
        playerwater.text = player.water.ToString(); enemywater.text = enemy.water.ToString();
        playerearth.text = player.earth.ToString(); enemyearth.text = enemy.earth.ToString();
        playerair.text = player.air.ToString(); enemyair.text = enemy.air.ToString();
    }
    public void UpdateBattleline()
    {
        for (int i = 0; i < 7; i++)
        {
            if(player.battlelinefilling[i] == true)
            {
                playerbattleline[i].SetActive(true);
                playercreatureattack[i].text = player.battleline[i].attack.ToString();         
                playercreaturehealth[i].text = player.battleline[i].health.ToString();
                playercreaturecost[i].text = player.battleline[i].manacost.ToString();
                playercreatureicon[i].sprite = player.battleline[i].icon;

            }
            if (enemy.battlelinefilling[i] == true)
            {
                enemybattleline[i].SetActive(true);
                enemycreatureattack[i].text = enemy.battleline[i].attack.ToString();
                enemycreaturehealth[i].text = enemy.battleline[i].health.ToString();
                enemycreaturecost[i].text = enemy.battleline[i].manacost.ToString();
                enemycreatureicon[i].sprite = enemy.battleline[i].icon;

            }

        }

    }
    public void SetPlayer(Player pone, Player ptwo)
    {
        if (pone.photonView.isMine)
        {
            player = pone;
            enemy = ptwo;
        }
        else
        {
            player = ptwo;
            enemy = pone;
        }
    }

    public void SetNames()
    {
        playername.text = player.playername;
        enemyname.text = enemy.playername;
    }

    public void SetSpellbookUI()
    {
        for (int i = 0; i <player.spellbook.Count; i++)
        {
            spellbookicon[i].sprite = player.spellbook[i].icon;
            spellbookattack[i].text = player.spellbook[i].attack.ToString();
            spellbookhealth[i].text = player.spellbook[i].health.ToString();
            spellbookcost[i].text = player.spellbook[i].manacost.ToString();
            if (player.spellbook[i].iscreature == false)
            {
                spellbookbuttons[i].image.sprite = Resources.Load<Sprite>("karta_fon2");
                spellbookattack[i].text = " ";
                spellbookhealth[i].text = " ";
            }
        }
    }
    public void CardSelectedUI(int n)
    {
        cardname.text = player.spellbook[n].cardname;
        carddesciption.text = player.spellbook[n].description;


        selectedcarduiattack.text = player.spellbook[n].attack.ToString();
        selectedcarduihealth.text = player.spellbook[n].health.ToString() ;
        selectedcarduimanacost.text = player.spellbook[n].manacost.ToString();
        selectedcarduiicon.sprite = player.spellbook[n].icon;
    }
    public void RemoveCreatureOnUI(Player p, int slot)
    {
        if (p == player)
        {
            playerbattleline[slot].SetActive(false);
        }
        else
        {
            enemybattleline[slot].SetActive(false);
        }
    }

    public void SetPortraits()
    {
        playerportrait.sprite = portraits[player.portraitnumber];
        enemyportrait.sprite = portraits[enemy.portraitnumber];
    }
    public void SaveHealthBeforeAttack()
    {
        for (int i = 0; i < 7; i++)
        {
            if (player.battlelinefilling[i] == true)
            {
                playerhealthbeforeattack[i] = player.battleline[i].health;
            }
            else
            {
                playerhealthbeforeattack[i] = 0;
            }
            if (enemy.battlelinefilling[i] == true)
            {
                enemyhealthbeforeattack[i] = enemy.battleline[i].health;
            }
            else
            {
                enemyhealthbeforeattack[i] = 0;
            }
            playerslotwasfilled[i] = player.battlelinefilling[i];
            enemyslotwasfilled[i] = enemy.battlelinefilling[i];
        }
    }
    public IEnumerator ShowDamageSequence()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 7; i++)
        {
            StopCoroutine(ShowDamage(i));
            StartCoroutine(ShowDamage(i));
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator ShowDamage(int slot)
    {           
            if (enemyslotwasfilled[slot] == true && (enemy.battleline[slot].health - enemyhealthbeforeattack[slot]) != 0)
            {
                enemydamageindicators[slot].text = (enemy.battleline[slot].health - enemyhealthbeforeattack[slot]).ToString();
                yield return new WaitForSeconds(3.0f);
                enemydamageindicators[slot].text = "";
            }
            if (playerslotwasfilled[slot] == true && (player.battleline[slot].health - playerhealthbeforeattack[slot]) != 0)

            {
                Debug.Log("Indicator active");
                playerdamageindicators[slot].text = (player.battleline[slot].health - playerhealthbeforeattack[slot]).ToString();
                yield return new WaitForSeconds(3.0f);
                playerdamageindicators[slot].text = "";
            }
        yield return null;
    }
    
}
