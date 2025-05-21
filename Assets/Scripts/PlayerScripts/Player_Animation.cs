using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Animation : MonoBehaviourPunCallbacks
{
    //public PhotonView PV;
    /*如果是要判斷攻擊 可以試試看去判斷子彈有沒有生成*/
    private bool draging = false;
    private bool mousedowun = false;
    public float checktime = 0;
    private Vector3 lastPos;
    public GameObject stickCanvas;
    public GameObject DeadCanvas;
    public GameObject Effect;
    PhotonView PV;
    private const byte RELIVE = 24;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        PV = gameObject.transform.parent.parent.parent.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerLife_Controll.isWoodAlive+","+PlayerLife_Controll.isWaterAlive);
        if (Time.time - checktime > 0.1f)
        {
            checktime = Time.time;
            //判断是否有移动
            if ((transform.position - lastPos).sqrMagnitude > 0.1f)
            {
                draging = true;
            }
            else
            {
                draging = false;
            }
            lastPos = transform.position;
        }

        gameObject.GetComponent<Animator>().SetBool("isMoving", draging);
        if (gameObject.name == "Wood_V2_08_L") //木死亡
        {
            if (PlayerLife_Controll.WoodcurrentHealth == 0 && PlayerLife_Controll.isWoodAlive)
            {
                Effect.SetActive(false);
                stickCanvas.SetActive(false);
                gameObject.GetComponent<Animator>().SetBool("isDie", true);
                if (PV.IsMine)
                {
                    DeadCanvas.SetActive(true);
                    gameObject.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
                }
                Failed.dead++;
                Player_score.Player_wood[2]++;
                PlayerLife_Controll.isWoodAlive = false;
            }
        }
        if (gameObject.name == "Water_Bake_02") //水死亡
        {

            if (PlayerLife_Controll.WatercurrentHealth == 0 && PlayerLife_Controll.isWaterAlive)
            {
                stickCanvas.SetActive(false);
                gameObject.GetComponent<Animator>().SetBool("isDie", true);
                if (PV.IsMine)
                {
                    DeadCanvas.SetActive(true);
                    gameObject.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
                }
                Failed.dead++;
                Player_score.Player_water[2]++;
                PlayerLife_Controll.isWaterAlive = false;
            }
        }
        if (gameObject.name == "Wind_Bake_01") //風死亡
        {
            if (PlayerLife_Controll.WindcurrentHealth == 0 && PlayerLife_Controll.isWindAlive)
            {
                Effect.SetActive(false);
                stickCanvas.SetActive(false);
                gameObject.GetComponent<Animator>().SetBool("isDie", true);
                if (PV.IsMine)
                {
                    gameObject.transform.parent.parent.GetChild(1).gameObject.SetActive(false);
                    DeadCanvas.SetActive(true);
                    gameObject.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
                }
                Failed.dead++;
                Player_score.Player_wind[2]++;
                PlayerLife_Controll.isWindAlive = false;
            }
        }
        if (gameObject.name == "Fire_Bake_01") //火死亡
        {
            if (PlayerLife_Controll.FirecurrentHealth == 0 && PlayerLife_Controll.isFireAlive)
            {
                Effect.SetActive(false);
                stickCanvas.SetActive(false);
                gameObject.GetComponent<Animator>().SetBool("isDie", true);
                if (PV.IsMine)
                {
                    gameObject.transform.parent.parent.GetChild(1).gameObject.SetActive(false);
                    DeadCanvas.SetActive(true);
                    gameObject.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
                }
                Failed.dead++;
                Player_score.Player_fire[2]++;
                PlayerLife_Controll.isFireAlive = false;
            }
        }
        if (gameObject.name == "RoundOne2_GOLD1") //金死亡
        {
            if (PlayerLife_Controll.GoldcurrentHealth == 0 && PlayerLife_Controll.isGoldAlive)
            {
                if (ringcolor.num == 0)
                {
                    Effect = GameObject.Find("RING_V10");
                }
                else if (ringcolor.num == 1)
                {
                    Effect = GameObject.Find("RING_green(Clone)");
                }
                else if (ringcolor.num == 2)
                {
                    Effect = GameObject.Find("RING_blue(Clone)");
                }
                else if (ringcolor.num == 3)
                {
                    Effect = GameObject.Find("RING_red(Clone)");
                }
                else if (ringcolor.num == 4)
                {
                    Effect = GameObject.Find("RING_brown(Clone)");
                }
                else if (ringcolor.num == 5)
                {
                    Effect = GameObject.Find("RING_white(Clone)");
                }

                Destroy(Effect);
                stickCanvas.SetActive(false);
                gameObject.transform.GetChild(2).GetComponent<ringcolor>().enabled = false;
                gameObject.GetComponent<Animator>().SetBool("isDie", true);
                if (PV.IsMine)
                {
                    gameObject.transform.parent.parent.GetChild(1).gameObject.SetActive(false);
                    DeadCanvas.SetActive(true);
                    gameObject.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
                }
                Failed.dead++;
                Player_score.Player_gold[2]++;
                PlayerLife_Controll.isGoldAlive = false;
            }
        }
        if (gameObject.name == "Rock_V04") //土死亡
        {
            if (PlayerLife_Controll.RockcurrentHealth == 0 && PlayerLife_Controll.isRockAlive)
            {
                Effect.SetActive(false);
                stickCanvas.SetActive(false);
                gameObject.GetComponent<Animator>().SetBool("isDie", true);
                if (PV.IsMine)
                {
                    gameObject.transform.parent.parent.GetChild(1).gameObject.SetActive(false);
                    DeadCanvas.SetActive(true);
                    gameObject.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
                }
                Failed.dead++;
                Player_score.Player_rock[2]++;
                PlayerLife_Controll.isRockAlive = false;
            }
        }

        //gameObject.GetComponent<Animator>().SetBool("isAttack", mousedowun);
    }
}
