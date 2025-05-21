using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class water_skill : MonoBehaviourPun
{
    /*
    private ParticleSystem water;
    public GameObject Player,Boss;
    Vector3 pos_p,pos_b;
    float distan=0;
    Vector3 move,target;
    float temp=1;
    bool back=false;
    */
    public GameObject Boss;
    Vector3 move;
    float time = 0;
    float pertime = 0;
    bool iswood, iswind, isrock, isgold, isfire, isboss;
    private const byte WATER_HURT = 27;

    public GameObject wood_skill;
    bool isboom = false;
    void Update()
    {
        wood_skill = GameObject.Find("wood_circle(Clone)");
        time += Time.deltaTime;
        Boss = GameObject.FindWithTag("Boss");
        pertime += Time.deltaTime;
        if (pertime >= 1)
        {
            WaterHurt();
            pertime = 0;
        }
        if (time >= 5)
        { //5秒刪除
            Destroy(gameObject);
            Player_Game.isskill_water = false;
        }
    }
    void OnParticleCollision(GameObject hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.tag == "Boss")
        {
            Debug.Log("碰");
            isboss = true;
            move = Boss.transform.position - transform.position;
            Boss.transform.position = Vector3.MoveTowards(Boss.transform.position, Boss.transform.position + move, Time.deltaTime * 100);
            //Boss.GetComponent<healthBar>().Hurt1(0.04f);
            //WaterHurt();
            Player_score.Player_water[0] += 0.04f * 100;
        }
        if (hit.tag == "Player")
        {
            Debug.Log("打到");
            if (hit.name != "Water_Bake_02")
            {
                move = hit.transform.position - transform.position;
                hit.transform.parent.parent.parent.position = Vector3.MoveTowards(hit.transform.position, hit.transform.position + move, Time.deltaTime * 100);
            }
            if (hit.name == "Wood_V2_08_L")
            {
                iswood = true;
                WaterHurt();
                Player_score.Player_water[4] += 0.02f;
            }
            if (hit.name == "Rock_V04")
            {
                isrock = true;
                WaterHurt();
                Player_score.Player_water[4] += 0.02f;
            }
            if (hit.name == "Fire_Bake_01")
            {
                isfire = true;
                WaterHurt();
                Player_score.Player_water[4] += 0.02f;
            }
            if (hit.name == "RoundOne2_GOLD1")
            {
                isgold = true;
                WaterHurt();
                Player_score.Player_water[4] += 0.02f;
            }
            if (hit.name == "Wind_Bake_01")
            {
                iswind = true;
                WaterHurt();
                Player_score.Player_water[4] += 0.02f;
            }
            //hit.GetComponent<healthBar>().Hurt1(0.05f);
        }
    }
    void OnParticleTrigger()
    {
        Debug.Log("水碰到木");
        if (wood_skill)
        {
            wood_skill.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            if (!isboom)
            {
                PhotonNetwork.Instantiate("Effect/efffect/exp_suc", wood_skill.transform.position, wood_skill.transform.rotation);
                isboom = true;
            }
        }
    }
    void WaterHurt()
    {
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;
        float BosscurrentHealth = healthBar.BosscurrentHealth;
        if (iswood)
        {
            WoodcurrentHealth -= 0.02f;
        }
        if (iswind)
        {
            WindcurrentHealth -= 0.02f;
        }
        if (isfire)
        {
            FirecurrentHealth -= 0.02f;
        }
        if (isgold)
        {
            GoldcurrentHealth -= 0.02f;
        }
        if (isrock)
        {
            RockcurrentHealth -= 0.02f;
        }
        if (isboss)
        {
            BosscurrentHealth -= 0.04f;
        }
        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth, GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth, BosscurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(WATER_HURT, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
