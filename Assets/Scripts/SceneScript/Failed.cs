using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class Failed : MonoBehaviourPunCallbacks
{
    GameObject[] Player;
    static public int dead = 0;
    public GameObject FailedCanvas;
    public GameObject BGM;
    bool isfindpalyer = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(dead);
        Player = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(Player.Length);
        if (Player.Length >= 2 && dead == Player.Length)
        {
            Time.timeScale = 0;
            FailedCanvas.SetActive(true);
            BGM.SetActive(false);
        }
    }

}
