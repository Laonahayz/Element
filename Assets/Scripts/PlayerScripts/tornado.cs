using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class tornado : MonoBehaviourPun
{
    // Start is called before the first frame update
    float timer = 0;
    static public float damage = 0;
    public GameObject tornadoo;
    static public float damage2 = 0;
    float damage_time = 0;
    public GameObject player_wind;
    private const byte WIND_SKILL_CL = 17;
    private const byte WINDHURT = 26;
    static public float scale = 0.3f;
    public Material[] meshRender = null;
    public Renderer rend;
    bool isdamage = false;
    private bool iswood, iswater, iswind, isrock, isgold, isfire, isboss;
    // Update is called once per frame
    void Update()
    {
        damage_time = timer / 100;
        damage = damage_time + damage2;
        timer += Time.deltaTime;
        if (timer >= 30)
        {
            timer = 0;
            BoolWindSkillClose();
        }
        if (!Player_Game.WindSkillOpen)
        {
            player_wind.transform.position = tornadoo.transform.position;
            tornadoo.SetActive(false);
            player_wind.SetActive(true);
        }
        if (Player_Game.WindSkillOpen)
        {
            tornadoo.transform.position = player_wind.transform.position;
        }
        Debug.Log(timer);
        //player_wind.transform.position = tornadoo.transform.position;
    }
    private void BoolWindSkillClose()
    {
        bool WindSkillOpen = false;
        object[] datas = new object[] { WindSkillOpen };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(WIND_SKILL_CL, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    void OnTriggerEnter(Collider hit)
    {
        if (!isdamage)
        {
            if (hit.GetComponent<Collider>().tag == "Player")
            {
                if (hit.name == "Wood_V2_08_L")
                {
                    iswood = true;
                    TornadoHurt();
                    //PlayerLife_Controll.WoodcurrentHealth -= damage;
                    Player_score.Player_wind[4] += damage;
                    isdamage = true;
                }
                if (hit.name == "Water_Bake_02")
                {
                    iswater = true;
                    TornadoHurt();
                    //PlayerLife_Controll.WatercurrentHealth -= damage;
                    Player_score.Player_wind[4] += damage;
                    isdamage = true;
                }
                if (hit.name == "RoundOne2_GOLD1")
                {
                    isgold = true;
                    TornadoHurt();
                    //PlayerLife_Controll.GoldcurrentHealth -= damage;
                    Player_score.Player_wind[4] += damage;
                    isdamage = true;
                }
                if (hit.name == "Rock_V04")
                {
                    isrock = true;
                    TornadoHurt();
                    //PlayerLife_Controll.RockcurrentHealth -= damage;
                    Player_score.Player_wind[4] += damage;
                    isdamage = true;
                }
                if (hit.name == "Fire_Bake_01")
                {
                    isfire = true;
                    TornadoHurt();
                    //PlayerLife_Controll.FirecurrentHealth -= damage;
                    Player_score.Player_wind[4] += damage;
                    isdamage = true;
                }
                tornadoo.SetActive(false);
                player_wind.SetActive(true);
                timer = 0;
                rend = GetComponent<Renderer>();
                rend.sharedMaterial = meshRender[0];
                gameObject.transform.localScale = new Vector3(scale, scale, scale);
                BoolWindSkillClose();
            }
            if (hit.GetComponent<Collider>().tag == "Boss")
            {
                damage = timer / 100;
                isboss = true;
                TornadoHurt();
                isdamage = true;
                //hit.GetComponent<healthBar>().Hurt1(damage);
                tornadoo.SetActive(false);
                player_wind.SetActive(true);
                rend = GetComponent<Renderer>();
                rend.sharedMaterial = meshRender[0];
                gameObject.transform.localScale = new Vector3(scale, scale, scale);
                timer = 0;
                BoolWindSkillClose();
            }
            if (hit.GetComponent<Collider>().tag == "Bullet")
            {
                Destroy(hit.gameObject);
            }
            if (hit.GetComponent<Collider>().tag == "Skill")
            {
                Destroy(hit.gameObject);
                if (hit.name == "fireball(Clone)")
                {
                    rend = GetComponent<Renderer>();
                    rend.sharedMaterial = meshRender[1];
                    gameObject.transform.localScale = new Vector3(scale * 1.2f, scale * 1.2f, scale * 1.2f);
                    damage2 += 0.15f;
                }
            }
        }
    }
    private void TornadoHurt()
    {
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;
        float BosscurrentHealth = healthBar.BosscurrentHealth;
        if (iswood)
        {
            WoodcurrentHealth -= damage;
            BoolWindSkillClose();
        }
        if (iswater)
        {
            WatercurrentHealth -= damage;
            BoolWindSkillClose();
        }
        if (isrock)
        {
            RockcurrentHealth -= damage;
            BoolWindSkillClose();
        }
        if (isgold)
        {
            GoldcurrentHealth -= damage;
            BoolWindSkillClose();
        }
        if (isfire)
        {
            FirecurrentHealth -= damage;
            BoolWindSkillClose();
        }
        if (isboss)
        {
            BosscurrentHealth -= damage;
            BoolWindSkillClose();
        }
        object[] datas = new object[] { WoodcurrentHealth, WatercurrentHealth, GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth, BosscurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(WINDHURT, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
