using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaButton : MonoBehaviour {


    /*  public GameObject activated;
      public GameObject[] deactivated = new GameObject[3];

      public void UseButton()
      {
          activated.SetActive(true);
          for (int i = 0; i<3; i++)
          {
              deactivated[i].SetActive(false);
          }
      }
      */

    public GameObject[] panels = new GameObject[4];
    public int selected = 0;
    public bool forward;

    public void UseButton()
    {
        if (forward == true)
        {
            selected++;
            if (selected >3)
            {
                selected = 0;
            }
        }
        if (forward == false)
        {
            selected--;
            if (selected <0)
            {
                selected = 3;
            }
        }
        for (int i = 0; i<4; i++)
        {
            if (selected == i)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }
}
