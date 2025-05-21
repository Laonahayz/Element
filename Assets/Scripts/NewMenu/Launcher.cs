using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] GameObject GameBTN;
    [SerializeField] Text Player1Name, Player2Name, Player3Name, Player4Name;
    [SerializeField] TMP_Text RoomName, Stage, Level, PlayerInroomNum;
    [SerializeField] string[] playersname = new string[4];
    [SerializeField] InputField EnterMyNickname;
    [SerializeField] string[] Roomnames;
    [SerializeField] PhotonView PV;
    [SerializeField] bool FirstTime = false;
    [SerializeField] bool Getinroom = false;
    [SerializeField] int RoomNums;
    public GameObject PSW_Panel;
    public TMP_InputField MyNickname;
    public TMP_InputField PSW;
    public TMP_Text RoomInfo, Stars, Round, MenuStars;
    public string MyName;
    public static bool isP1 = false, isP2 = false, isP3 = false, isP4 = false;


    public GameObject BGM;
    public Button StartBTN;
    public AudioSource kla;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PV = gameObject.GetComponent<PhotonView>();
        //CharacterIMG[0] = 
        if (LeaveTheRoom.isExit)
        {
            //PhotonNetwork.LeaveLobby();
            //PhotonNetwork.LeaveRoom();
            MenuManager.Instance.OpenMenu("title");
        }
    }
    void Update()
    {
        if (Getinroom == true)
        {
            Player[] players = PhotonNetwork.PlayerList;

            if (RoomNums == 1)
            {
                RoomInfo.text = "房間一(" + players.Count() + "/4)\n";
                Stars.text = "<color=#FFEB00>★</color>☆☆";
                Round.text = "第一關";
            }
            if (RoomNums == 2)
            {
                RoomInfo.text = "房間二(" + players.Count() + "/4)\n";
                Stars.text = "<color=#FFEB00>★★</color>☆";
                Round.text = "第二關";
            }
            if (RoomNums == 3)
            {
                RoomInfo.text = "房間三(" + players.Count() + "/4)\n";
                Stars.text = "<color=#FFEB00>★★★</color>";
                Round.text = "第三關";
            }
            for (int i = players.Count(); i < 4; i++)
            {
                playersname[i] = " ";
                //PlayersIMG[i].sprite = null;
            }
            Player1Name.text = playersname[0];
            Player2Name.text = playersname[1];
            Player3Name.text = playersname[2];
            Player4Name.text = playersname[3];

            if (MyName == Player1Name.text)
            {
                isP1 = true;
            }
            if (MyName == Player2Name.text)
            {
                isP2 = true;
            }
            if (MyName == Player3Name.text)
            {
                isP3 = true;
            }
            if (MyName == Player4Name.text)
            {
                isP4 = true;
            }
        }
        if(EnterMyNickname.text.Length > 3)
        {
            EnterMyNickname.text = EnterMyNickname.text.Substring(0, 3);
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("玩家連上Master server了");
        if (FirstTime == false)
        {
            BGM.SetActive(true);
            MenuManager.Instance.OpenMenu("title");
        }
        if (FirstTime == true)
        {
            MenuManager.Instance.OpenMenu("createroom");
        }
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("進入大廳");
        MenuManager.Instance.OpenMenu("createroom");
        //PhotonNetwork.NickName = "匿名" + Nicknames[Random.Range(0, 39)]; //原本39
        
        MyName = PhotonNetwork.NickName;
        
        /*先知道每個playersname[]對應的角色，然後綁相對應的圖(用Nickname索引)*/
        /*建造Map(查) 製造對照表 圖片看名字去對應*/
    }

    public void STARTBTN()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.NickName = "匿名" + EnterMyNickname.text;
        FirstTime = true;
    }
    public void EnterBTN()
    {
        kla.Play();
        if (RoomNums == 1 && PSW.text == "01")
        {
            int randomroomname = 1;
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
            PhotonNetwork.JoinOrCreateRoom("Room" + randomroomname, roomOps, null);
            MenuManager.Instance.OpenMenu("loading");
            Getinroom = true;
            Debug.Log(Getinroom);
        }
        if (RoomNums == 2 && PSW.text == "02")
        {
            int randomroomname = 2;
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
            PhotonNetwork.JoinOrCreateRoom("Room" + randomroomname, roomOps, null);
            MenuManager.Instance.OpenMenu("loading");
            Getinroom = true;
            Debug.Log(Getinroom);
        }
        if (RoomNums == 3 && PSW.text == "03")
        {
            int randomroomname = 3;
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
            PhotonNetwork.JoinOrCreateRoom("Room" + randomroomname, roomOps, null);
            MenuManager.Instance.OpenMenu("loading");
            Getinroom = true;
            Debug.Log(Getinroom);
        }
    }

    public void OpenPSW_Panel()
    {
        kla.Play();
        PSW_Panel.SetActive(true);
        PSW.text = "";
        GameObject.Find("Room1BTN").GetComponent<Button>().interactable = false;
        GameObject.Find("Room2BTN").GetComponent<Button>().interactable = false;
        GameObject.Find("Room3BTN").GetComponent<Button>().interactable = false;
        GameObject.Find("BackBTN").GetComponent<Button>().interactable = false;
        GameObject.Find("EnterBTN").GetComponent<Button>().interactable = false;
    }
    public void Cancel_BTN_Clicked()
    {
        PSW.text = "";
        PSW_Panel.SetActive(false);
        GameObject.Find("Room1BTN").GetComponent<Button>().interactable = true;
        GameObject.Find("Room2BTN").GetComponent<Button>().interactable = true;
        GameObject.Find("Room3BTN").GetComponent<Button>().interactable = true;
        GameObject.Find("BackBTN").GetComponent<Button>().interactable = true;
        GameObject.Find("EnterBTN").GetComponent<Button>().interactable = true;
        //Success_Text.SetActive(false);
        //Fail_Text.SetActive(false);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        GameBTN.SetActive(PhotonNetwork.IsMasterClient);
    }
    public void CreateRoom1()
    {
        kla.Play();
        RoomNums = 1;
        RoomName.text = "房名： 房間一";
        Stage.text = "關卡： 第一關";
        Level.text = "難度：  ";
        MenuStars.text = "<color=#FFEB00>★</color>☆☆";
        PlayerInroomNum.text = "人數： " + PhotonNetwork.CountOfPlayersInRooms + " / 4";
    }
    public void CreateRoom2()
    {
        kla.Play();
        RoomNums = 2;
        RoomName.text = "房名： 房間二";
        Stage.text = "關卡： 第二關";
        Level.text = "難度：  ";
        MenuStars.text = "<color=#FFEB00>★★</color>☆";
        PlayerInroomNum.text = "人數： " + PhotonNetwork.CountOfPlayersInRooms + " / 4";
    }
    public void CreateRoom3()
    {
        kla.Play();
        RoomNums = 3;
        RoomName.text = "房名： 房間三";
        Stage.text = "關卡： 第三關";
        Level.text = "難度：  ";
        MenuStars.text = "<color=#FFEB00>★★★</color>";
        PlayerInroomNum.text = "人數： " + PhotonNetwork.CountOfPlayersInRooms + " / 4";
    }
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        //roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        //PV.RPC("UpdatePlayerCount", RpcTarget.All, true);
        Player[] players = PhotonNetwork.PlayerList;
        PhotonNetwork.Instantiate("CharacterIMG", transform.position, transform.rotation);
        for (int i = 0; i < players.Count(); i++)
        {
            playersname[i] = players[i].NickName;
        }
        GameBTN.SetActive(PhotonNetwork.IsMasterClient);
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            print(player.NickName);
        }
    }
    public void StartGame()
    {
        kla.Play();
        StartBTN.enabled = false;
        if (RoomNums == 1)
        {
            PhotonNetwork.LoadLevel(1);
        }
        if (RoomNums == 2)
        {
            PhotonNetwork.LoadLevel(2);
        }
        if (RoomNums == 3)
        {
            PhotonNetwork.LoadLevel(3);
        }
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        MenuManager.Instance.OpenMenu("error");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("createroom");
        Getinroom = false;
        Debug.Log(Getinroom);
        PSW.text = "";
        PSW_Panel.SetActive(false);
        GameObject.Find("Room1BTN").GetComponent<Button>().interactable = true;
        GameObject.Find("Room2BTN").GetComponent<Button>().interactable = true;
        GameObject.Find("Room3BTN").GetComponent<Button>().interactable = true;
        GameObject.Find("BackBTN").GetComponent<Button>().interactable = true;
        GameObject.Find("EnterBTN").GetComponent<Button>().interactable = true;
    }
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("createroom");
        PV.RPC("UpdatePlayerCount", RpcTarget.All, false);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PV.IsMine)
        {
            PhotonNetwork.DestroyPlayerObjects(otherPlayer);
            Player[] players = PhotonNetwork.PlayerList;
            for (int i = 0; i < players.Count(); i++)
            {
                playersname[i] = players[i].NickName;
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        //Instantiate(PlayerListItemPrefab, PlayerListContent).GetComponent<PlayerListItem>().Setup(newPlayer);
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Count(); i++)
        {
            playersname[i] = players[i].NickName;
        }

    }
    
}