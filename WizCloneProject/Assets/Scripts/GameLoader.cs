using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {

    public GameManager gameManager;

   public int playersready = 0;

	void Start ()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }


	void Update () {
		if (playersready == 2)
        {

            gameManager.gameObject.SetActive(true);
            playersready = 3;
        }
	}
}
