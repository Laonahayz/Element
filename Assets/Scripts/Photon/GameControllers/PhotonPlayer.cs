using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class PhotonPlayer : MonoBehaviour
{
    public PhotonView PV;
    public GameObject myAvatar;
    public GameObject Player;
    public GameObject camOBJ;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        PV = gameObject.GetComponent<PhotonView>();
        int spawnpicker = Random.Range(0, GameSetup.GS.spawnpoints.Length);
        if(PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), GameSetup.GS.spawnpoints[spawnpicker].position, GameSetup.GS.spawnpoints[spawnpicker].rotation,0);
            //camOBJ.transform.position = Player.transform.position;
            //camOBJ.transform.position = playerOBJ.transform.position;
        }
    }

    private void FixedUpdate()
    {
        /*if(playerOBJ != null && camOBJ != null)
        {
            camOBJ.transform.position = playerOBJ.transform.position - offset;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            camOBJ = Camera.main.gameObject;
            if (myAvatar.transform.GetChild(0).name == "woodcharacter(Clone)")
            {
                Player = GameObject.Find("Wood_V2_08_L");
                camOBJ.transform.position = Player.transform.position - offset;
                if(AvatarSetup.isSetting){
                    myAvatar.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                }
                AvatarSetup.isSetting = false;
            }
            if (myAvatar.transform.GetChild(0).name == "watercharacter(Clone)")
            {
                Player = GameObject.Find("Water_Bake_02");
                camOBJ.transform.position = Player.transform.position - offset;
                if(AvatarSetup.isSetting){
                    myAvatar.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                }
                AvatarSetup.isSetting = false;
            }
            if (myAvatar.transform.GetChild(0).name == "goldcharacter(Clone)")
            {
                Player = GameObject.Find("RoundOne2_GOLD1");
                camOBJ.transform.position = Player.transform.position - offset;
                if(AvatarSetup.isSetting){
                    myAvatar.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                }
                AvatarSetup.isSetting = false;
            }
            if (myAvatar.transform.GetChild(0).name == "windcharacter(Clone)")
            {
                if (Player_Game.WindSkillOpen)
                {
                    //Player = GameObject.Find("Tornado");
                    camOBJ.transform.position = GameObject.Find("Tornado").transform.position - offset;
                }
                else if(!Player_Game.WindSkillOpen)
                {
                    Player = GameObject.Find("Wind_Bake_01");
                    camOBJ.transform.position = Player.transform.position - offset;
                    if (AvatarSetup.isSetting)
                    {
                        myAvatar.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                    }
                    AvatarSetup.isSetting = false;
                }
                
            }
            if (myAvatar.transform.GetChild(0).name == "rockcharacter(Clone)")
            {
                Player = GameObject.Find("Rock_V04");
                camOBJ.transform.position = Player.transform.position - offset;
                if(AvatarSetup.isSetting){
                    myAvatar.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                }
                AvatarSetup.isSetting = false;
            }
            if (myAvatar.transform.GetChild(0).name == "firecharacter(Clone)")
            {
                Player = GameObject.Find("Fire_Bake_01");
                camOBJ.transform.position = Player.transform.position - offset;
                if(AvatarSetup.isSetting){
                    myAvatar.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                }
                AvatarSetup.isSetting = false;
            }
        }
    }
}
