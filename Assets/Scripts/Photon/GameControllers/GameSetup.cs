using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.SceneManagement;


public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] spawnpoints;

    private void OnEnable()
    {
        if (GS == null)
        {
            GS = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
        }
    }

    // Update is called once per frame
}
