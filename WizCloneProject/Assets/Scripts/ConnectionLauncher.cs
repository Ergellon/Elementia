using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class ConnectionLauncher : MonoBehaviourPunCallbacks {

    string gameversion = "0.01";

    public Text connecting;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = gameversion;
    }

    public void LoadSpellbook()
    {
        SceneManager.LoadScene("Spellbook");
    }

    public void Connect ()
    {
        connecting.text = "Устанавливается связь с сервером...";      
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom(); //maybe try JoinOrCreate later
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returncode, string message)
    {
        PhotonNetwork.CreateRoom(null);
        connecting.text = "Ожидание второго игрока...";
    }
    public override void OnJoinedRoom()
    {
       if (PhotonNetwork.CurrentRoom.PlayerCount == 2)   //number of players must be set in room properties, not here
        {
          SceneManager.LoadScene("Battle");
        }
    }
    
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Battle");
        }
    }
    public void  LoadTestVKScene ()
    {
        SceneManager.LoadScene(3);
    }


}
