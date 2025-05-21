using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class relive : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    public SphereCollider character;
    public SphereCollider collider_relive;
    public GameObject stickCanvas;
    public GameObject alive_loading;
    PhotonView PV;
    //bool isliving = false;
    bool rescureislive = false;
    bool isdeath = false;
    public GameObject Effect;
    public GameObject DeadCanvas;
    bool isrelive = true;


    void Start()
    {
        Physics.IgnoreCollision(character, collider_relive, true);
        PV = gameObject.transform.parent.parent.parent.parent.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        alive_loading = GameObject.Find("death_loading(Clone)");
        //腳本持有者死亡
        if (gameObject.transform.parent.name == "Wood_V2_08_L" && !PlayerLife_Controll.isWoodAlive)
        {
            isrelive = false;
            isdeath = true;
            if (!isrelive)
            {
                if (alive_loading)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= 5)
                {
                    PlayerLife_Controll.isWoodAlive = true;
                    PlayerLife_Controll.WoodcurrentHealth = 1f;
                    Effect.SetActive(true);
                    Failed.dead--;
                    isrelive = true;
                }
            }
        }
        if (gameObject.transform.parent.name == "Water_Bake_02" && !PlayerLife_Controll.isWaterAlive)
        {
            isrelive = false;
            isdeath = true;
            if (!isrelive)
            {
                if (alive_loading)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= 5)
                {
                    PlayerLife_Controll.isWaterAlive = true;
                    PlayerLife_Controll.WatercurrentHealth = 1f;
                    Failed.dead--;
                    isrelive = true;
                }
            }
        }
        if (gameObject.transform.parent.name == "Wind_Bake_01" && !PlayerLife_Controll.isWindAlive)
        {
            isrelive = false;
            isdeath = true;
            if (!isrelive)
            {
                if (alive_loading)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= 5)
                {
                    PlayerLife_Controll.isWindAlive = true;
                    PlayerLife_Controll.WindcurrentHealth = 1f;
                    Effect.SetActive(true);
                    Failed.dead--;
                    isrelive = true;
                }
            }
        }
        if (gameObject.transform.parent.name == "Fire_Bake_01" && !PlayerLife_Controll.isFireAlive)
        {
            isrelive = false;
            isdeath = true;
            if (!isrelive)
            {
                if (alive_loading)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= 5)
                {
                    PlayerLife_Controll.isFireAlive = true;
                    PlayerLife_Controll.FirecurrentHealth = 1f;
                    Effect.SetActive(true);
                    Failed.dead--;
                    isrelive = true;
                }
            }
        }
        if (gameObject.transform.parent.name == "RoundOne2_GOLD1" && !PlayerLife_Controll.isGoldAlive)
        {
            isrelive = false;
            isdeath = true;
            if (!isrelive)
            {
                if (alive_loading)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= 5)
                {
                    PlayerLife_Controll.isGoldAlive = true;
                    PlayerLife_Controll.GoldcurrentHealth = 1f;
                    Instantiate(Effect, transform);
                    gameObject.transform.parent.GetChild(2).GetComponent<ringcolor>().enabled = true;
                    Failed.dead--;
                    isrelive = true;
                }
            }
        }
        if (gameObject.transform.parent.name == "Rock_V04" && !PlayerLife_Controll.isRockAlive)
        {
            isrelive = false;
            isdeath = true;
            if (!isrelive)
            {
                if (alive_loading)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= 5)
                {
                    PlayerLife_Controll.isRockAlive = true;
                    PlayerLife_Controll.RockcurrentHealth = 1f;
                    Effect.SetActive(true);
                    Failed.dead--;
                    isrelive = true;
                }
            }
        }

        //Debug.Log(timer);
        if (timer >= 5) //超過五秒
        {
            //腳本持有者復活
            rescureislive = false;
            isdeath = false;
            if (alive_loading)
            {
                Destroy(alive_loading);
            }
            //gameObject.GetComponent<Animator>().SetBool("isDie", true);
            if (PV.IsMine)
            {
                stickCanvas.SetActive(true); //要寫isMine
                DeadCanvas.SetActive(false);
            }
            //GameObject.Find("WoodDeadCanvas").SetActive(true);
            gameObject.transform.parent.parent.parent.parent.GetComponent<PlayerMove>().enabled = true;
            //Player_score.Player_wood[2]++;
            gameObject.transform.parent.GetComponent<Animator>().SetBool("isAlive", true);
            gameObject.transform.parent.GetComponent<Animator>().SetBool("isDie", false);
            timer = 0;
            //isliving=false;
        }
    }
    void OnTriggerEnter(Collider hit)
    {
        //Debug.Log(isliving);
        //碰到腳本持有者的人活著
        if (hit.GetComponent<Collider>().tag == "Player")
        {
            if (isdeath)
            {
                if (hit.name == "Wood_V2_08_L")
                {
                    if (PlayerLife_Controll.isWoodAlive)
                    {
                        rescureislive = true;
                    }
                }
                else if (hit.name == "Water_Bake_02")
                {
                    //Debug.Log("碰到水");
                    if (PlayerLife_Controll.isWaterAlive)
                    {
                        rescureislive = true;
                        //Debug.Log("碰到我的水是活著的");
                    }
                }
                else if (hit.name == "Wind_Bake_01")
                {
                    if (PlayerLife_Controll.isWindAlive)
                    {
                        rescureislive = true;
                    }
                }
                else if (hit.name == "Fire_Bake_01")
                {
                    //Debug.Log("碰到火");
                    if (PlayerLife_Controll.isFireAlive)
                    {
                        rescureislive = true;
                    }
                }
                else if (hit.name == "RoundOne2_GOLD1")
                {
                    if (PlayerLife_Controll.isGoldAlive)
                    {
                        rescureislive = true;
                    }
                }
                else if (hit.name == "Rock_V04")
                {
                    if (PlayerLife_Controll.isRockAlive)
                    {
                        rescureislive = true;
                    }
                }
            }
            if (rescureislive && !alive_loading)
            {
                //Debug.Log("碰到腳本持有者的人活著");
                //Debug.Log("腳本持有者死亡");
                //Debug.Log("還沒有生成復活圈");
                PhotonNetwork.Instantiate("Effect/Relive/death_loading", gameObject.transform.parent.position, gameObject.transform.parent.rotation);
                //isliving=true;
                //Debug.Log("生成復活圈");
            }
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "Player")
        {
            if (alive_loading)
            {
                timer = 0;
                Destroy(alive_loading);
                //isliving=false;
                //Debug.Log("刪除復活圈");
                rescureislive = false;
            }
        }
    }

}