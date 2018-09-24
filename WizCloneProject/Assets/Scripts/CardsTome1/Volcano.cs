using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : Spell {

    public Volcano()
    {
        power = 99;
        manacost = 6;
        element = "fire";
        icon = Resources.Load<Sprite>("CardIcons/volcano");

        cardname = "Армагеддон";
        description = "Уничтожает все существа, кроме иммунных к магии и наносит 6 урона противнику";
    }


     public override void OnCast(Player att, Player def, int slot)
    {
        
        for (int i = 0; i < 7; i++)
        {
            if (att.battlelinefilling[i] == true && att.battleline[i].tag!= "fireimmune" 
                && att.battleline[i].tag != "magicimmune")
            {
                att.battleline[i].health -= power ;
            }

            if (def.battlelinefilling[i] == true && def.battleline[i].tag != "fireimmune" 
                && def.battleline[i].tag != "magicimmune")
            {
                def.battleline[i].health -= power;
            }
           
        }
        def.health -= 6;
    }
}
