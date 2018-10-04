using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverCard : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler{

    public BattleUIManager battleUIManager;
    public int n;
    public bool onbattlefield;
    public bool isenemycard;

    Card card;

    public void OnPointerEnter(PointerEventData eventData)
    {
       if (onbattlefield == false)
        {
            battleUIManager.CardShowInfo(n);
            return;
        }
       if (onbattlefield == true)
        {
            battleUIManager.CardShowInfo(NumberCounter(n, battleUIManager.player));
        }
       if (onbattlefield == true && isenemycard == true)
        {
            battleUIManager.CardShowInfoEnemy(NumberCounter(n, battleUIManager.enemy));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        battleUIManager.CardSelectedUI(battleUIManager.selectedcardnumber);
    }

    int NumberCounter(int n, Player player)
    {
        int x = player.battleline[n].manacost-1;
        if (player.battleline[n].element == "water")
        {
            x += 6;
        }
        if (player.battleline[n].element == "earth")
        {
            x += 12;
        }
        if (player.battleline[n].element == "air")
        {
            x += 18;
        }
        return x;
    }
}
