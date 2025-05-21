using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class bullet_move : MonoBehaviour
{
    // Start is called before the first frame update
    bool Right, Left, Top, Buttom = false;
    bool UpperRight, UpperLeft, LowerRight, LowerLeft = false;
    public float speed = 10f;
    Vector3 move;
    public static float damage = 0.03f;
    public static float BOSS1_Ori_damage = 0.03f;
    private const byte BULLET_HURT = 15;
    private bool iswood, iswater, iswind, isrock, isgold, isfire;

    void Start()
    {
        InvokeRepeating("delete", 5f, 5f);
        move = transform.position - (Player_Game.look_pos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(move.x * speed * Time.deltaTime * 0.3f, 0, move.z * speed * Time.deltaTime * 0.3f), Space.World);
    }
    void OnTriggerEnter(Collider hit)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.GetComponent<Collider>().tag == "Player")
        {
            //hit.transform.parent.parent.parent.GetComponent<healthBar_Player>().Hurt1(0.1f);
            if (hit.name == "Wood_V2_08_L")
            {
                iswood = true;
                Hurt();
            }
            if (hit.name == "Water_Bake_02")
            {
                iswater = true;
                Hurt();
            }
            if (hit.name == "Wind_Bake_01")
            {
                iswind = true;
                Hurt();
            }
            if (hit.name == "RoundOne2_GOLD1")
            {
                isgold = true;
                Hurt();
            }
            if (hit.name == "Rock_V04")
            {
                isrock = true;
                Hurt();
            }
            if (hit.name == "Fire_Bake_01")
            {
                isfire = true;
                Hurt();
            }

            //healthBar_Player.Hurt1();
        }
        if (hit.GetComponent<Collider>().tag == "Scene")
        {
            Destroy(gameObject);
        }
    }
    void delete()
    {
        Destroy(gameObject);
        CancelInvoke();
    }
    private void Hurt()
    {
        float WoodcurrentHealth = PlayerLife_Controll.WoodcurrentHealth;
        float WindcurrentHealth = PlayerLife_Controll.WindcurrentHealth;
        float WatercurrentHealth = PlayerLife_Controll.WatercurrentHealth;
        float GoldcurrentHealth = PlayerLife_Controll.GoldcurrentHealth;
        float RockcurrentHealth = PlayerLife_Controll.RockcurrentHealth;
        float FirecurrentHealth = PlayerLife_Controll.FirecurrentHealth;

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
        object[] datas = new object[] { WoodcurrentHealth, WatercurrentHealth, WindcurrentHealth, RockcurrentHealth, GoldcurrentHealth, FirecurrentHealth };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(BULLET_HURT, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}