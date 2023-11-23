using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NewBehaviourScript : MonoBehaviourPunCallbacks  
{
    public GameObject EnterPlayerNamePanel;

    public GameObject ConnectionStatusPanel;

    public GameObject LobbyPanel;

    void awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        EnterPlayerNamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log (PhotonNetwork.NickName + " Connected to Photon Servers");
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(true);

    }

    public override void OnConnected()
    {
        Debug.Log("Connected to the Internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning(message);
        CreateAndJoinRoom();
    }

    public void ConnectToPhotonServer()
    {

        if (!PhotonNetwork.IsConnected)
        {
           PhotonNetwork.ConnectUsingSettings(); 
           ConnectionStatusPanel.SetActive(true);
           EnterPlayerNamePanel.SetActive(false);  
        }
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    private void CreateAndJoinRoom()
    {
        string RandomRoomName = " Room " + Random.Range(0, 100);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.CreateRoom(RandomRoomName, roomOptions);    
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " has entered " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " has entered room "+ PhotonNetwork.CurrentRoom.Name + ". Room now has " + PhotonNetwork.CurrentRoom.PlayerCount + " Players.");
    }

    
}
