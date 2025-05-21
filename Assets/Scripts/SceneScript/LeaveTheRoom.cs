using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LeaveTheRoom : MonoBehaviourPunCallbacks
{
    public static bool isExit = false;
    /*public override void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/
    public void Click_Exit()
    {
        //PhotonNetwork.LeaveRoom();
        //isExit = true;
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LoadLevel(0);
        /*沒辦法重新進房間。*/
        StartCoroutine(DisConnectAndLoad());
    }

    public override void OnLeftRoom()
    {
        //SceneManager.LoadScene(0);
        /*if(PhotonNetwork.InRoom)
        {
            
        }*/
        PhotonNetwork.LoadLevel(0);
        Debug.Log("離開ㄌ");
        //base.OnLeftRoom();
        
    }
    IEnumerator DisConnectAndLoad()
    {
        isExit = true;
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }
        //PhotonNetwork.LoadLevel(0);
    }
}
