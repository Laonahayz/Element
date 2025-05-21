using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class fire_skill01 : MonoBehaviourPun
{
    // Start is called before the first frame update
    Vector3 move;
    private const byte FIRE = 23;
    private bool iswood, iswater, iswind, isrock, isgold, isfire, isboss;
    float damage = 0.15f;
    void Start()
    {
        InvokeRepeating("delete", 5f, 5f);
        move = (Player_Game.look_pos) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(move.x * Time.deltaTime, 0, move.z * Time.deltaTime), Space.World);
    }
    void delete()
    {
        Destroy(gameObject);
        CancelInvoke();
    }
    void OnParticleCollision(GameObject hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.tag == "Boss")
        {
            Debug.Log("碰");
            //hit.GetComponent<healthBar>().Hurt1(0.15f);
            isboss = true;
            //Destroy(gameObject);
            FireHurt();
            PhotonNetwork.Instantiate("Effect/split", transform.position, Quaternion.Euler(0, 0, 0));
            Player_score.Player_fire[0] += 0.15f * 100;
        }
        if (hit.tag == "Player")
        {
            Debug.Log("碰");
            Destroy(gameObject);
            if (hit.name == "Wood_V2_08_L")
            {
                iswood = true;
                //PlayerLife_Controll.WoodcurrentHealth -= damage;
                FireHurt();
                Player_score.Player_fire[4] += 0.15f;
            }
            if (hit.name == "Water_Bake_02")
            {
                iswater = true;
                //PlayerLife_Controll.WatercurrentHealth -= damage;
                FireHurt();
                Player_score.Player_fire[4] += 0.15f;
            }
            if (hit.name == "Rock_V04")
            {
                isrock = true;
                //PlayerLife_Controll.RockcurrentHealth -= damage;
                FireHurt();
                Player_score.Player_fire[4] += 0.15f;
            }
            if (hit.name == "RoundOne2_GOLD1")
            {
                isgold = true;
                //PlayerLife_Controll.GoldcurrentHealth -= damage;
                FireHurt();
                Player_score.Player_fire[4] += 0.15f;
            }
            if (hit.name == "Wind_Bake_01")
            {
                iswind = true;
                //PlayerLife_Controll.WindcurrentHealth -= damage;
                FireHurt();
                Player_score.Player_fire[4] += 0.15f;
            }
            //hit.GetComponent<healthBar>().Hurt1(0.05f);
        }
    }
    private void FireHurt()
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
        if (isboss)
        {
            BosscurrentHealth -= damage;
            Destroy(gameObject);
        }
        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth, WatercurrentHealth, GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth, BosscurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(FIRE, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
