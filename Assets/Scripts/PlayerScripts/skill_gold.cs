using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class skill_gold : MonoBehaviourPun
{
    // Start is called before the first frame update
    public GameObject[] player;
    private const byte ADD_HEALTH_EVENT = 0;
    private const byte HURT_HEALTH_EVENT = 1;
    private const byte ADD_DEFENSE = 2;
    private const byte REDUCE_DEFENSE = 3;
    private const byte RESET_DEFENSE = 4;
    private const byte ADD_ATTACK = 5;
    private const byte REDUCE_ATTACK = 6;
    private const byte RESET_ATTACK = 7;
    private const byte ADD_ATTACK_SPEED = 8;
    private const byte REDUCE_ATTACK_SPEED = 9;
    private const byte RESET_ATTACK_SPEED = 10;
    private const byte ADD_PLAYER_SPEED = 11;
    private const byte REDUCE_PLAYER_SPEED = 12;
    private const byte RESET_PLAYER_SPEED = 13;
    float time=0;
    public static bool isAddHealth;
    public GameObject Boss;
    void Start()
    {
        Boss=GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bullet_move.damage);
    }
    public void Coin()
    {
        //int coin = Random.Range(0, 2);
        player = GameObject.FindGameObjectsWithTag("Player");
        if (Player_Game.Coin == 0)
        {
            if (ringcolor.num == 0)
            {
                //金
            }
            else if (ringcolor.num == 1)
            {
                //木
                //全體角色回血
                AddHealth();
            }
            else if (ringcolor.num == 2)
            {
                //水
                //全體角色防禦力增加
                DefenseUp();
                StartCoroutine(def());
            }
            else if (ringcolor.num == 3)
            {
                //火
                //全體角色攻擊力增加
                AttackUp();
                StartCoroutine(atk());

            }
            else if (ringcolor.num == 4)
            {
                //土
                //全體角色攻速增加
                //Player_Game.atk_speed=0.5f;
                AttackSpeedUp();
                StartCoroutine(atk_sd());
            }
            else if (ringcolor.num == 5)
            {
                //風
                //全體角色跑速增加
                WalkSpeedUp();
                StartCoroutine(run_sd());
            }
            Debug.Log("正面");
        }
        else
        {
            if (ringcolor.num == 0)
            {
                //金
            }
            else if (ringcolor.num == 1)
            {
                //木
                //全體扣血
                HurtHealth();
                //Boss.GetComponent<healthBar>().Hurt_G(0.5f);
            }
            else if (ringcolor.num == 2)
            {
                //水
                //全體防禦力減少
                DefenseDown();
                StartCoroutine(def());
            }
            else if (ringcolor.num == 3)
            {
                //火
                //全體角色攻擊力減少
                AttackDown();
                StartCoroutine(atk());
            }
            else if (ringcolor.num == 4)
            {
                //土
                //全體角色攻速減緩含敵方
                /*Player_Game.atk_speed=2f;
                bullet.atk_speed=5f;*/
                AttackSpeedDown();
                StartCoroutine(atk_sd());
            }
            else if (ringcolor.num == 5)
            {
                //風
                //全體角色跑速增加
                WalkSpeedDown();
                StartCoroutine(run_sd());
            }
            Debug.Log("背面");
        }
    }
    IEnumerator def(){
        yield return new WaitForSeconds(5f);
        //bullet_move.damage=0.1f;
        DefenseReset();
        
    }
    IEnumerator atk(){
        yield return new WaitForSeconds(5f);
        AttackReset();
    }
    IEnumerator atk_sd()
    {
        yield return new WaitForSeconds(5f);
        AttackSpeedReset();
    }
    IEnumerator run_sd()
    {
        yield return new WaitForSeconds(5f);
        WalkSpeedReset();
    }

    /*------治癒------*/
    private void AddHealth()
    {
        //bool isAddHealth = true;
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;

        WoodcurrentHealth += 0.15f;
        WindcurrentHealth += 0.15f;
        WatercurrentHealth += 0.15f;
        GoldcurrentHealth += 0.15f;
        RockcurrentHealth += 0.15f;
        FirecurrentHealth += 0.15f;

        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth,WatercurrentHealth,
        GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(ADD_HEALTH_EVENT, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void HurtHealth()
    {
        //bool isAddHealth = true;
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;

        WoodcurrentHealth -= 0.15f;
        WindcurrentHealth -= 0.15f;
        WatercurrentHealth -= 0.15f;
        GoldcurrentHealth -= 0.15f;
        RockcurrentHealth -= 0.15f;
        FirecurrentHealth -= 0.15f;

        object[] datas = new object[] { WoodcurrentHealth, WindcurrentHealth,WatercurrentHealth,
        GoldcurrentHealth, RockcurrentHealth, FirecurrentHealth};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(HURT_HEALTH_EVENT, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    /*------防禦力------*/
    private void DefenseUp()
    {
        float DefenseUpNum = 0.015f;
        object[] datas = new object[] { DefenseUpNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(ADD_DEFENSE, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void DefenseDown()
    {
        float DefenseDownNum = 0.045f;
        object[] datas = new object[] { DefenseDownNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(REDUCE_DEFENSE, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void DefenseReset()
    {
        float Defense = 0.03f;
        object[] datas = new object[] { Defense };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(RESET_DEFENSE, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    /*------攻擊力------*/
    private void AttackUp()
    {
        float AttackUpNum = 0.0075f;
        object[] datas = new object[] { AttackUpNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(ADD_ATTACK, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void AttackDown()
    {
        float AttackDownNum = 0.0025f;
        object[] datas = new object[] { AttackDownNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(REDUCE_ATTACK, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void AttackReset()
    {
        float Attack = 0.005f;
        object[] datas = new object[] { Attack };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(RESET_ATTACK, datas, raiseEventOptions, SendOptions.SendReliable);
    }

    /*------攻速------*/
    private void AttackSpeedUp()
    {
        float AttackSpeedUpNum = 0.5f;
        object[] datas = new object[] { AttackSpeedUpNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(ADD_ATTACK_SPEED, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void AttackSpeedDown()
    {
        float AttackSpeedDownNum = 1.5f;
        object[] datas = new object[] { AttackSpeedDownNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(REDUCE_ATTACK_SPEED, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void AttackSpeedReset()
    {
        float AttackSpeed = 1f;
        object[] datas = new object[] { AttackSpeed };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(RESET_ATTACK_SPEED, datas, raiseEventOptions, SendOptions.SendReliable);
    }

    /*------跑速------*/
    private void WalkSpeedUp()
    {
        float WalkSpeedUpNum = 15f;
        object[] datas = new object[] { WalkSpeedUpNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(ADD_PLAYER_SPEED, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void WalkSpeedDown()
    {
        float WalkSpeedDownNum = 5f;
        object[] datas = new object[] { WalkSpeedDownNum };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(REDUCE_PLAYER_SPEED, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void WalkSpeedReset()
    {
        float WalkSpeed = 10f;
        object[] datas = new object[] { WalkSpeed };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(RESET_PLAYER_SPEED, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
