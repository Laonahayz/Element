using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;

public class Player_score : MonoBehaviourPun
{
    // Start is called before the first frame update
    static public float[] Player_wood = new float[5];
    static public float[] Player_water = new float[5];
    static public float[] Player_fire = new float[5];
    static public float[] Player_gold = new float[5];
    static public float[] Player_rock = new float[5];
    static public float[] Player_wind = new float[5];
    private const byte ATTACK = 25;

    //public Text score;
    //0:傷害量，1:治療量，2:死亡次數，3:幫復次數，4：對隊友造成ㄉ傷害
    bool iswood, iswater, iswind, isgold, isfire, isrock;
    // Update is called once per frame
    void Update()
    {
        //score.text="木死亡次數"+Player_wood[2]+"水救援次數"+Player_water[3];
        //score.text="木："+Player_wood[1];
        //score.text="木："+Player_wood[0]+"，水："+Player_water[0]+"火："+Player_fire[0]+"土"+Player_rock[0]+"風"+Player_wind[0]+"金"+Player_gold[0];
        //score.text = healthBar.BosscurrentHealth.ToString();

    }
    void OnTriggerEnter(Collider hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.GetComponent<Collider>().tag == "Bullet")
        {
            if (hit.name == "FB_WOOD(Clone)")
            {
                this.GetComponent<healthBar>().Hurt1(Bullet_Player.damage);
                iswood = true;
                AttackHurt();
                Debug.Log("打到一下");
                Destroy(hit.gameObject);
                //healthBar.Hurt1();
                Player_wood[0] += Bullet_Player.damage * 100; //傷害量增加
            }
            if (hit.name == "FB_WATER(Clone)")
            {
                this.GetComponent<healthBar>().Hurt1(Bullet_Player.damage);
                iswater = true;
                AttackHurt();
                Debug.Log("打到一下");
                Destroy(hit.gameObject);
                //healthBar.Hurt1();
                Player_water[0] += Bullet_Player.damage * 100; //傷害量增加
            }
            if (hit.name == "FB_WIND(Clone)")
            {
                this.GetComponent<healthBar>().Hurt1(Bullet_Player.damage);
                iswind = true;
                AttackHurt();
                Debug.Log("打到一下");
                Destroy(hit.gameObject);
                //healthBar.Hurt1();
                Player_wind[0] += Bullet_Player.damage * 100; //傷害量增加
            }
            if (hit.name == "FB_FIRE(Clone)")
            {
                this.GetComponent<healthBar>().Hurt1(Bullet_Player.damage);
                isfire = true;
                AttackHurt();
                Debug.Log("打到一下");
                Destroy(hit.gameObject);
                //healthBar.Hurt1();
                Player_fire[0] += Bullet_Player.damage * 100; //傷害量增加
            }
            if (hit.name == "FB_ROCK(Clone)")
            {
                this.GetComponent<healthBar>().Hurt1(Bullet_Player.damage);
                isrock = true;
                AttackHurt();
                Debug.Log("打到一下");
                Destroy(hit.gameObject);
                //healthBar.Hurt1();
                Player_rock[0] += Bullet_Player.damage * 100; //傷害量增加
            }
            if (hit.name == "FB_GOLD(Clone)")
            {
                this.GetComponent<healthBar>().Hurt1(Bullet_Player.damage);
                isgold = true;
                AttackHurt();
                Debug.Log("打到一下");
                Destroy(hit.gameObject);
                //healthBar.Hurt1();
                Player_gold[0] += Bullet_Player.damage * 100; //傷害量增加
            }
        }
        if (hit.GetComponent<Collider>().name == "Tornado")
        {
            Player_wind[0] += tornado.damage * 100;
        }
    }
    private void AttackHurt()
    {
        float BosscurrentHealth = healthBar.BosscurrentHealth;
        if (iswood)
        {
            BosscurrentHealth -= Bullet_Player.damage;
        }
        if (iswater)
        {
            BosscurrentHealth -= Bullet_Player.damage;
        }
        if (iswind)
        {
            BosscurrentHealth -= Bullet_Player.damage;
        }
        if (isgold)
        {
            BosscurrentHealth -= Bullet_Player.damage;
        }
        if (isrock)
        {
            BosscurrentHealth -= Bullet_Player.damage;
        }
        if (isfire)
        {
            BosscurrentHealth -= Bullet_Player.damage;
        }

        object[] datas = new object[] { BosscurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(ATTACK, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
