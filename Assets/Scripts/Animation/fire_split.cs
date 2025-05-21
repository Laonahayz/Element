using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class fire_split : MonoBehaviourPun
{
    bool isdelate = false;
    private bool iswood, iswater, iswind, isrock, isgold, isfire, isboss;
    float damage = 0.05f;
    private const byte FIRE_SPLIT = 24;
    public Material meshRender = null;
    public Renderer rend;
    bool absorb = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = Resources.Load("tornado_fire") as Material;
        InvokeRepeating("delete", 5f, 5f);
        InvokeRepeating("delate", 0.3f, 5f);
    }
    void delete()
    {
        Destroy(gameObject);
        CancelInvoke();
    }
    void delate()
    {
        isdelate = true;
        CancelInvoke();
    }
    // Update is called once per frame
    void OnParticleCollision(GameObject hit)
    {
        if (isdelate)
        {
            //若碰到標籤為 NPC 或 Boss 把自己毀滅
            if (hit.tag == "Boss")
            {
                Debug.Log("碰");
                Destroy(gameObject);
                isboss = true;
                //hit.GetComponent<healthBar>().Hurt1(0.05f);
                FireSplitHurt();
                Player_score.Player_fire[0] += 0.05f * 100;
            }
            if (hit.tag == "Player")
            {
                Debug.Log("碰");
                Destroy(gameObject);
                if (hit.name == "Wood_V2_08_L")
                {
                    iswood = true;
                    FireSplitHurt();
                    //PlayerLife_Controll.WoodcurrentHealth -= 0.05f;
                    Player_score.Player_fire[4] += 0.05f;
                }
                if (hit.name == "Water_Bake_02")
                {
                    iswater = true;
                    FireSplitHurt();
                    PlayerLife_Controll.WatercurrentHealth -= 0.05f;
                    Player_score.Player_fire[4] += 0.05f;
                }
                if (hit.name == "Rock_V04")
                {
                    isrock = true;
                    FireSplitHurt();
                    //PlayerLife_Controll.RockcurrentHealth -= 0.05f;
                    Player_score.Player_fire[4] += 0.05f;
                }
                if (hit.name == "Fire_Bake_01")
                {
                    isfire = true;
                    FireSplitHurt();
                    //PlayerLife_Controll.FirecurrentHealth -= 0.05f;
                    Player_score.Player_fire[4] += 0.05f;
                }
                if (hit.name == "RoundOne2_GOLD1")
                {
                    isgold = true;
                    FireSplitHurt();
                    //PlayerLife_Controll.GoldcurrentHealth -= 0.05f;
                    Player_score.Player_fire[4] += 0.05f;
                }
                if (hit.name == "Wind_Bake_01")
                {
                    iswind = true;
                    FireSplitHurt();
                    //PlayerLife_Controll.WindcurrentHealth -= 0.05f;
                    Player_score.Player_fire[4] += 0.05f;
                }
                //hit.GetComponent<healthBar>().Hurt1(0.05f);
            }
            if (hit.name == "Tornado")
            {
                rend = hit.gameObject.GetComponent<Renderer>();
                rend.sharedMaterial = meshRender;
                hit.gameObject.transform.localScale = new Vector3(tornado.scale * 1.2f, tornado.scale * 1.2f, tornado.scale * 1.2f);
                tornado.damage2 += 0.05f;
                Destroy(gameObject);
            }
        }

    }
    private void FireSplitHurt()
    {
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;
        float BosscurrentHealth = healthBar.BosscurrentHealth;
        if (iswood)
        {
            WoodcurrentHealth -= damage;
            Destroy(gameObject);
        }
        if (iswater)
        {
            WatercurrentHealth -= damage;
            Destroy(gameObject);
        }
        if (iswind)
        {
            WindcurrentHealth -= damage;
            Destroy(gameObject);
        }
        if (isrock)
        {
            RockcurrentHealth -= damage;
            Destroy(gameObject);
        }
        if (isgold)
        {
            GoldcurrentHealth -= damage;
            Destroy(gameObject);
        }
        if (isfire)
        {
            FirecurrentHealth -= damage;
            Destroy(gameObject);
        }
        if (isboss)
        {
            BosscurrentHealth -= damage;
            Destroy(gameObject);
        }
        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth, WatercurrentHealth, GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth, BosscurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(FIRE_SPLIT, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
