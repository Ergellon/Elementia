using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLauncher : MonoBehaviour
{

    public string playername = "default";

    public InputField inputname;

    public int selectedportraitnumber;
    public Image selectedportait;
    public List<Sprite> portraits = new List<Sprite>();

	void Start ()
    {

        DontDestroyOnLoad(this.gameObject);

        if (PlayerPrefs.GetString("playedbefore") != "yes")
        {
            PlayerPrefs.SetString("playedbefore", "yes");
            for (int i = 0; i<24; i++)
            {
                PlayerPrefs.SetInt("spell" + i, 0);
            }
            selectedportraitnumber = 0;
            PlayerPrefs.SetInt("selectedportrait", 0);
        }
        selectedportraitnumber = PlayerPrefs.GetInt("selectedportrait");
        selectedportait.sprite = portraits[selectedportraitnumber];
    }
	
	void Update () {
		
	}

    public void ChangePlayerName()
    {      
            playername = inputname.text;       
    }
    public void ChangePortrait (bool forward)
    {
        if (forward == true)
        {
            selectedportraitnumber++;
            if (selectedportraitnumber == portraits.Count)
            {
                selectedportraitnumber = 0;
            }
            PlayerPrefs.SetInt("selectedportrait", selectedportraitnumber);
        }
        else
        {
            selectedportraitnumber--;
            if (selectedportraitnumber<0)
            {
                selectedportraitnumber = portraits.Count - 1;
            }
            PlayerPrefs.SetInt("selectedportrait", selectedportraitnumber);
        }
        selectedportait.sprite = portraits[selectedportraitnumber];
    }
}
