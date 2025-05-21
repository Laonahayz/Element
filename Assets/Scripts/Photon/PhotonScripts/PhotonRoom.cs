using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static PhotonRoom room;
    private PhotonView PV;

    // public bool isGameLoaded;
    public int currectScene;
    public int MultiplayerScene;

    private void Awake()
    {
        if(room == null)
        {
            room = this;
        }
        else
        {
            if(room != this)
            {
                Destroy(room.gameObject);
                room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
        PV = GetComponent<PhotonView>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom()
    {
        /*base.OnJoinedRoom();
        Debug.Log("正在房間中");
        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        StartGame();*/
    }
    void StartGame()
    {
        Debug.Log("載入關卡");
    }
    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currectScene = scene.buildIndex;
        if (currectScene == MultiplayerScene)
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
    }
}
