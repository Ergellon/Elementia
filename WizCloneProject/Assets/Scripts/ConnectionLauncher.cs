using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ConnectionLauncher : Photon.PunBehaviour {

    string gameversion = "0.01";

    public Text connecting;

    void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true; 
    }

    public void LoadSpellbook()
    {
        SceneManager.LoadScene("Spellbook");
    }

    public void Connect ()
    {
        connecting.text = "Устанавливается связь с сервером...";      
        if (PhotonNetwork.connectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom(); //maybe try JoinOrCreate later
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(gameversion);
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(null);
        connecting.text = "Ожидание второго игрока...";
    }
    public override void OnJoinedRoom()
    {
       if (PhotonNetwork.room.PlayerCount == 2)   //number of players must be set in room properties, not here
        {
          SceneManager.LoadScene("Battle");
        }
    }
    
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        if (PhotonNetwork.room.PlayerCount == 2)
        {
            SceneManager.LoadScene("Battle");
        }
    }
    public void  LoadTestVKScene ()
    {
        SceneManager.LoadScene(3);
    }


}
