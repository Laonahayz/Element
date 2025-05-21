using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject LoginButton;
    public GameObject CancelButton;

    // Start is called before the first frame update
    private void Awake()
    {
        lobby = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("玩家連上Master server了");
        PhotonNetwork.AutomaticallySyncScene = true;
        LoginButton.SetActive(true);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("加入隨機房間失敗");
        CreateRoom();
    }

    void CreateRoom()
    {
        //int randomroomname = Random.Range(0, 1000);
        int randomroomname = 10;
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom("Room" + randomroomname, roomOps, null);
    }
    // Update is called once per frame

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("創建房間失敗");
        CreateRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("進入房間");
    }
    public void OnclickLoginBTN()
    {
        CancelButton.SetActive(true);
        LoginButton.SetActive(false);
        CreateRoom();
        //PhotonNetwork.JoinRandomRoom();
    }
    public void OnclickCancelBTN()
    {
        CancelButton.SetActive(false);
        LoginButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    void Update()
    {
        
    }
}
