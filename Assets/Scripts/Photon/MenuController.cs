using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class MenuController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int CharacterNumber;
    public Sprite[] LockSprite;
    public Text Player1Name, Player2Name, Player3Name, Player4Name;
    public Text PicPOS1, PicPOS2;
    public static int countWood = 0, countWater = 0, countWind = 0, countGold = 0, countRock = 0, countFire = 0;
    private const byte PRESS_WOOD_BUTTON = 18;
    public Text WoodBTN;
    bool Onpointerdown;
    float presstime = 0;
    float needtime = 1.5f;
    bool iswood = false;
    public AudioSource oh;
    void Update()
    {
        GameObject[] playerPic1 = GameObject.FindGameObjectsWithTag("PlayerPic1");
        GameObject[] playerPic2 = GameObject.FindGameObjectsWithTag("PlayerPic2");
        GameObject[] playerPic3 = GameObject.FindGameObjectsWithTag("PlayerPic3");
        GameObject[] playerPic4 = GameObject.FindGameObjectsWithTag("PlayerPic4");
        for (int i = 0; i < playerPic1.Length; i++)
        {
            playerPic1[i].transform.SetParent(GameObject.Find("PlayerListContent").transform, true);
        }
        for (int i = 0; i < playerPic2.Length; i++)
        {
            playerPic2[i].transform.SetParent(GameObject.Find("PlayerListContent").transform, true);
        }
        for (int i = 0; i < playerPic3.Length; i++)
        {
            playerPic3[i].transform.SetParent(GameObject.Find("PlayerListContent").transform, true);
        }
        for (int i = 0; i < playerPic4.Length; i++)
        {
            playerPic4[i].transform.SetParent(GameObject.Find("PlayerListContent").transform, true);
        }
        /*鎖角*/
        //UnLockButtons();
        //WoodBTN.text = countWood.ToString();
    }

    public void OnClickCharacterPick(int whichCharacter)
    {
        oh.Play();
        if (PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);
            CharacterNumber = whichCharacter;
        }

        if (Launcher.isP1)
        {
            GameObject[] playerPic1 = GameObject.FindGameObjectsWithTag("PlayerPic1");
            for (int i = 0; i < playerPic1.Length; i++)
            {
                PhotonNetwork.Destroy(playerPic1[i]);
            }
            if (whichCharacter == 0)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wood1PicPref", new Vector3(Player1Name.transform.position.x, Player1Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS1.text = GameObject.Find("Wood1PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 1)
            {
                PhotonNetwork.Instantiate("PlayerPic/Water1PicPref", new Vector3(Player1Name.transform.position.x, Player1Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS1.text = GameObject.Find("Water1PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 2)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wind1PicPref", new Vector3(Player1Name.transform.position.x, Player1Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS1.text = GameObject.Find("Wind1PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 3)
            {
                PhotonNetwork.Instantiate("PlayerPic/Gold1PicPref", new Vector3(Player1Name.transform.position.x, Player1Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS1.text = GameObject.Find("Gold1PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 4)
            {
                PhotonNetwork.Instantiate("PlayerPic/Rock1PicPref", new Vector3(Player1Name.transform.position.x, Player1Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS1.text = GameObject.Find("Rock1PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 5)
            {
                PhotonNetwork.Instantiate("PlayerPic/Fire1PicPref", new Vector3(Player1Name.transform.position.x, Player1Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS1.text = GameObject.Find("Fire1PicPref(Clone)").transform.position.ToString();
            }
        }
        if (Launcher.isP2)
        {
            Debug.Log("我是2");
            GameObject[] playerPic2 = GameObject.FindGameObjectsWithTag("PlayerPic2");
            for (int i = 0; i < playerPic2.Length; i++)
            {
                PhotonNetwork.Destroy(playerPic2[i]);
            }
            if (whichCharacter == 0)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wood2PicPref", new Vector3(Player2Name.transform.position.x, Player2Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS2.text = GameObject.Find("Wood2PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 1)
            {
                PhotonNetwork.Instantiate("PlayerPic/Water2PicPref", new Vector3(Player2Name.transform.position.x, Player2Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS2.text = GameObject.Find("Water2PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 2)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wind2PicPref", new Vector3(Player2Name.transform.position.x, Player2Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS2.text = GameObject.Find("Wind2PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 3)
            {
                PhotonNetwork.Instantiate("PlayerPic/Gold2PicPref", new Vector3(Player2Name.transform.position.x, Player2Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS2.text = GameObject.Find("Gold2PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 4)
            {
                PhotonNetwork.Instantiate("PlayerPic/Rock2PicPref", new Vector3(Player2Name.transform.position.x, Player2Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS2.text = GameObject.Find("Rock2PicPref(Clone)").transform.position.ToString();
            }
            if (whichCharacter == 5)
            {
                PhotonNetwork.Instantiate("PlayerPic/Fire2PicPref", new Vector3(Player2Name.transform.position.x, Player2Name.transform.position.y + 95f, 0), transform.rotation);
                //PicPOS2.text = GameObject.Find("Fire2PicPref(Clone)").transform.position.ToString();
            }
        }
        if (Launcher.isP3)
        {
            GameObject[] playerPic3 = GameObject.FindGameObjectsWithTag("PlayerPic3");
            for (int i = 0; i < playerPic3.Length; i++)
            {
                PhotonNetwork.Destroy(playerPic3[i]);
            }
            if (whichCharacter == 0)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wood3PicPref", new Vector3(Player3Name.transform.position.x, Player3Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 1)
            {
                PhotonNetwork.Instantiate("PlayerPic/Water3PicPref", new Vector3(Player3Name.transform.position.x, Player3Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 2)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wind3PicPref", new Vector3(Player3Name.transform.position.x, Player3Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 3)
            {
                PhotonNetwork.Instantiate("PlayerPic/Gold3PicPref", new Vector3(Player3Name.transform.position.x, Player3Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 4)
            {
                PhotonNetwork.Instantiate("PlayerPic/Rock3PicPref", new Vector3(Player3Name.transform.position.x, Player3Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 5)
            {
                PhotonNetwork.Instantiate("PlayerPic/Fire3PicPref", new Vector3(Player3Name.transform.position.x, Player3Name.transform.position.y + 95f, 0), transform.rotation);
            }
        }
        if (Launcher.isP4)
        {
            GameObject[] playerPic4 = GameObject.FindGameObjectsWithTag("PlayerPic4");
            for (int i = 0; i < playerPic4.Length; i++)
            {
                PhotonNetwork.Destroy(playerPic4[i]);
            }
            if (whichCharacter == 0)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wood4PicPref", new Vector3(Player4Name.transform.position.x, Player4Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 1)
            {
                PhotonNetwork.Instantiate("PlayerPic/Water4PicPref", new Vector3(Player4Name.transform.position.x, Player4Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 2)
            {
                PhotonNetwork.Instantiate("PlayerPic/Wind4PicPref", new Vector3(Player4Name.transform.position.x, Player4Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 3)
            {
                PhotonNetwork.Instantiate("PlayerPic/Gold4PicPref", new Vector3(Player4Name.transform.position.x, Player4Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 4)
            {
                PhotonNetwork.Instantiate("PlayerPic/Rock4PicPref", new Vector3(Player4Name.transform.position.x, Player4Name.transform.position.y + 95f, 0), transform.rotation);
            }
            if (whichCharacter == 5)
            {
                PhotonNetwork.Instantiate("PlayerPic/Fire4PicPref", new Vector3(Player4Name.transform.position.x, Player4Name.transform.position.y + 95f, 0), transform.rotation);
            }
        }
        //LockTheButtons();
    }

    /*public void LockTheButtons()
    {
        if (countWood == 1)
        {
            GameObject.Find("WoodBTN").GetComponent<Button>().interactable = false;
            GameObject.Find("WoodBTN").GetComponent<Button>().image.sprite = LockSprite[0];
        }
        if (countWater == 1)
        {
            GameObject.Find("WaterBTN").GetComponent<Button>().interactable = false;
            GameObject.Find("WoodBTN").GetComponent<Button>().image.sprite = LockSprite[1];
        }
        if (countWind == 1)
        {
            GameObject.Find("WindBTN").GetComponent<Button>().interactable = false;
            GameObject.Find("WoodBTN").GetComponent<Button>().image.sprite = LockSprite[2];
        }
        if (countGold == 1)
        {
            GameObject.Find("GoldBTN").GetComponent<Button>().interactable = false;
            GameObject.Find("WoodBTN").GetComponent<Button>().image.sprite = LockSprite[3];
        }
        if (countRock == 1)
        {
            GameObject.Find("RockBTN").GetComponent<Button>().interactable = false;
            GameObject.Find("WoodBTN").GetComponent<Button>().image.sprite = LockSprite[4];
        }
        if (countFire == 1)
        {
            GameObject.Find("FireBTN").GetComponent<Button>().interactable = false;
            GameObject.Find("WoodBTN").GetComponent<Button>().image.sprite = LockSprite[5];
        }
    }*/
    /*public void UnLockButtons()
    {
        if (Onpointerdown)
        {
            presstime += Time.deltaTime;
            Debug.Log(countWood);
            Debug.Log(presstime);
            //寫一下Reset的RaiseEvent
            if (countWood >= 2 && presstime >= needtime)
            {
                GameObject.Find("WoodBTN").GetComponent<Button>().interactable = true;
                Reset();
            }
            if (presstime >= needtime && countWater == 2)
            {
                GameObject.Find("WaterBTN").GetComponent<Button>().interactable = true;
                Reset();
            }
            if (presstime >= needtime && countWind == 2)
            {
                GameObject.Find("WindBTN").GetComponent<Button>().interactable = true;
                Reset();
            }
            if (presstime >= needtime && countGold == 2)
            {
                GameObject.Find("GoldBTN").GetComponent<Button>().interactable = true;
                Reset();
            }
            if (presstime >= needtime && countRock == 2)
            {
                GameObject.Find("RockBTN").GetComponent<Button>().interactable = true;
                Reset();
            }
            if (presstime >= needtime && countFire == 2)
            {
                GameObject.Find("FireBTN").GetComponent<Button>().interactable = true;
                Reset();
            }
        }
    }*/
    private void Pass_WoodCount()
    {
        int WoodCount = countWood;
        WoodCount++;
        object[] datas = new object[] { WoodCount };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(PRESS_WOOD_BUTTON, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    public void Reset()
    {
        Onpointerdown = false;
        presstime = 0;
        if (gameObject.name == "WoodBTN" && countWood > 2)
        {
            countWood = 0;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Onpointerdown = true;
        if (gameObject.name == "WoodBTN")
        {
            Pass_WoodCount();
        }
        //Debug.Log("isHolding");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }
}
