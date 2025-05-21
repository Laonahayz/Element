using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class skill_wood : MonoBehaviourPun
{
    private int count = 0;
    private float perTime = 0;//多久变动一次
    private bool iswood, iswater, iswind, isrock, isgold, isfire;
    private const byte WOOD_SKILL = 14;
    void Update()
    {
        perTime += Time.deltaTime;
        if (perTime >= 1)
        {
            perTime = 0;
            count++;
            AddHealth();
        }
        if (count == 5)
        {
            count = 0;
            Destroy(gameObject);
            Player_Game.WoodSkillOpen=false;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.GetComponent<Collider>().tag == "Player")
        {

            if (hit.name == "Wood_V2_08_L")
            {
                iswood = true;
            }

            if (hit.name == "Water_Bake_02")
            {
                iswater = true;
            }
            if (hit.name == "Wind_Bake_01")
            {
                iswind = true;
            }
            if (hit.name == "Fire_Bake_01")
            {
                isfire = true;
            }
            if (hit.name == "Rock_V04")
            {
                isrock = true;
            }
            if (hit.name == "RoundOne2_GOLD1")
            {
                isgold = true;
            }
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "Player")
        {

            if (hit.name == "Wood_V2_08_L")
            {
                iswood = false;
            }

            if (hit.name == "Water_Bake_02")
            {
                iswater = false;
            }
            if (hit.name == "Wind_Bake_01")
            {
                iswind = false;
            }
            if (hit.name == "Fire_Bake_01")
            {
                isfire = false;
            }
            if (hit.name == "Rock_V04")
            {
                isrock = false;
            }
            if (hit.name == "RoundOne2_GOLD1")
            {
                isgold = false;
            }
        }
    }
    private void AddHealth()
    {
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;

        if (iswood)
        {
            if (WoodcurrentHealth != 0 && WoodcurrentHealth != 1)
            {
                WoodcurrentHealth += 0.06f;
                Player_score.Player_wood[1] += 0.06f * 100;
            }
        }
        if (iswater)
        {
            if (WatercurrentHealth != 0 && WatercurrentHealth != 1)
            {
                WatercurrentHealth += 0.06f;
                Player_score.Player_wood[1] += 0.06f * 100;
            }
        }
        if (iswind)
        {
            if (WindcurrentHealth != 0 && WindcurrentHealth != 1)
            {
                WindcurrentHealth += 0.06f;
                Player_score.Player_wood[1] += 0.06f * 100;
            }
        }
        if (isrock)
        {
            if (RockcurrentHealth != 0 && RockcurrentHealth != 1)
            {
                RockcurrentHealth += 0.06f;
                Player_score.Player_wood[1] += 0.06f * 100;
            }
        }
        if (isfire)
        {
            if (FirecurrentHealth != 0 && FirecurrentHealth != 1)
            {
                FirecurrentHealth += 0.06f;
                Player_score.Player_wood[1] += 0.06f * 100;
            }
        }
        if (isgold)
        {
            if (GoldcurrentHealth != 0 && GoldcurrentHealth != 1)
            {
                GoldcurrentHealth += 0.06f;
                Player_score.Player_wood[1] += 0.06f * 100;
            }
        }
        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth, WatercurrentHealth, GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(WOOD_SKILL, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
