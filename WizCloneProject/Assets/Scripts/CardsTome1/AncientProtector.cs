using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientProtector : Creature {


    public AncientProtector()
    {
        manacost = 6;
        attack = 4;
        health = 16;
        maxhealth = 16;
        element = "earth";
        icon = Resources.Load<Sprite>("CardIcons/shambling-mound");

        cardname = "Колосс";
        description = "При выходе на поле уничтожает все существа противника со стоимостью 1";

        defence = 0;

    }
    public override void OnSpawn(Player att, Player def, int slot)
    {
        for (int i = 0; i<7; i++)
        {
            if (def.battlelinefilling[i] == true && def.battleline[i].manacost == 1)
            {
                def.battleline[i].health -= 99;
            }
        }
    }


}
