using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card  {

    public int manacost;
    public int attack;
    public int health;
    public string element;
    public Sprite icon;
    public bool iscreature;
    public bool isfriendlyspell;

    public string cardname;
    public string description;

    /*
    manacost;
    attack;
    health;
    element;
    icon;

    cardname;
    description;
    */


    public Card()
    {
       
    }

    public Card CopyCard()
    {
        return (Card)this.MemberwiseClone();
    }

}
