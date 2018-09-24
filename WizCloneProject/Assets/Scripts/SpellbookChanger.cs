using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpellbookChanger : MonoBehaviour
{

    public Button[] buttons = new Button[24];

    List<Card> spellbook = new List<Card>();

    public Text[] attack = new Text[24];
    public Text[] health = new Text[24];
    public Text[] manacost = new Text[24];
    public Image[] image = new Image[24];

    public Button[] selectedbuttons = new Button[2];

    public Card[] selectedcard = new Card[2];
    public Text[] selattack = new Text[2];
    public Text[] selhealth = new Text[2];
    public Text[] selmanacost = new Text[2];
    public Text[] selname = new Text[2];
    public Text[] seldescr = new Text[2];
    public Image[] selimage = new Image[2];

    public Image[] selector = new Image[2];

    int changingcard;


    public void Start()
    {
        FillSpellbook();
        for (int i = 0; i<24; i++)
        {
            FillSpellbookImage(i);
        }
        SelectionLeft(0);
    }


    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    void FillSpellbook()
    {
        for (int i = 0; i < 24; i++)
        {
            if (PlayerPrefs.GetInt("spell" + i) == 0)
            {
                spellbook.Add(SpellBook.testspells1[i]());
            }
            else
            {
                spellbook.Add(SpellBook.testspells2[i]());
            }
        }
    }
    void FillSpellbookImage(int i)
    {
        attack[i].text = spellbook[i].attack.ToString();
        health[i].text = spellbook[i].health.ToString();
        if(spellbook[i].attack == -1)
        {
            attack[i].text = "";
            health[i].text = "";
            buttons[i].image.sprite = Resources.Load<Sprite>("karta_fon2");
        }
        else
        {
            buttons[i].image.sprite = Resources.Load<Sprite>("karta_fon");
        }
        manacost[i].text = spellbook[i].manacost.ToString();
        image[i].sprite = spellbook[i].icon;
    }

    public void SelectionLeft (int n)
    {
        selectedcard[0] = SpellBook.testspells1[n]();
        selectedcard[1] = SpellBook.testspells2[n]();

        changingcard = n;

        for (int i = 0; i<2; i++)
        {
            selattack[i].text = selectedcard[i].attack.ToString();
            selhealth[i].text = selectedcard[i].health.ToString();
            if (selectedcard[i].attack == -1)
            {
                selattack[i].text = "";
                selhealth[i].text = "";
                selectedbuttons[i].image.sprite = Resources.Load<Sprite>("karta_fon2");
            }
            else
            {
                selectedbuttons[i].image.sprite = Resources.Load<Sprite>("karta_fon");
            }
            selmanacost[i].text = selectedcard[i].manacost.ToString();
            selname[i].text = selectedcard[i].cardname;
            seldescr[i].text = selectedcard[i].description;
            selimage[i].sprite = selectedcard[i].icon;
            if (PlayerPrefs.GetInt("spell" + n) == i)
            {
                selector[i].gameObject.SetActive(true);
            }
            else
            {
                selector[i].gameObject.SetActive(false);
            }
        }
    }

    public void SelectionRight(int n)
    {
        PlayerPrefs.SetInt("spell" + changingcard, n);
        for (int i = 0; i<2; i++)
        {
            if (PlayerPrefs.GetInt("spell" + changingcard) == i)
            {
                selector[i].gameObject.SetActive(true);
            }
            else
            {
                selector[i].gameObject.SetActive(false);
            }
        }
        if (n == 0)
        {
            spellbook[changingcard] = SpellBook.testspells1[changingcard]();
        }
        else
        {
            spellbook[changingcard] = SpellBook.testspells2[changingcard]();
        }
        FillSpellbookImage(changingcard);
        
    }
}
