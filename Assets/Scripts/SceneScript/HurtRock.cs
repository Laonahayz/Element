using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class HurtRock : MonoBehaviourPun
{
    private float perTime = 0;//多久变动一次
    private const byte HURT_ROCK = 28;
    public Image CanvasIMG;
    float Num;
    void Update()
    {

    }

    void OnTriggerStay(Collider hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.tag == "HurtRock")
        {
            Num += Time.deltaTime * 2f;
            if (Num >= 1)
            {
                Num = 1;
            }
            CanvasIMG.color = new Color(255, 255, 255, Num);
            perTime += Time.deltaTime;
            if (perTime >= 1)
            {
                perTime = 0;
                ReduceHealth();
            }
        }
    }
    void OnTriggerExit(Collider hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.tag == "HurtRock")
        {
            Num = 0;
            CanvasIMG.color = new Color32(255, 255, 255, 0);
            joycon.speed = 10f;
        }
    }
    private void ReduceHealth()
    {
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;

        if (gameObject.name == "Wood_V2_08_L")
        {
            WoodcurrentHealth -= 0.01f;
        }
        if (gameObject.name == "Water_Bake_02")
        {
            WatercurrentHealth -= 0.01f;
        }
        if (gameObject.name == "Wind_Bake_01")
        {
            WindcurrentHealth -= 0.01f;
        }
        if (gameObject.name == "Fire_Bake_01")
        {
            FirecurrentHealth -= 0.01f;
        }
        if (gameObject.name == "Rock_V04")
        {
            RockcurrentHealth -= 0.01f;
        }
        if (gameObject.name == "RoundOne2_GOLD1")
        {
            GoldcurrentHealth -= 0.01f;
        }

        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth, WatercurrentHealth, GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(HURT_ROCK, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
