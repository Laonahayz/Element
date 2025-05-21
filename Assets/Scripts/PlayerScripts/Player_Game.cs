using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Player_Game : MonoBehaviour//, IPunObservable
{
    [Header("子彈物件")]
    private GameObject Arrow;
    //[Header("法術物件")]
    //public GameObject Skill_Obj;
    [Header("法術按鈕")]
    public Button Skill_btn;
    public GameObject Skill_btnwood;

    [Header("法術要產生的位置")]
    public GameObject SpawnPosition;

    static public Vector3 look_pos;
    [Header("玩家物件")]
    public Transform Player1;
    public GameObject wind;
    public Image joyconIMG, handle;
    public GameObject tornado;
    public AudioSource hachu;
    //private bool Attack = false;
    //private Vector3 AttacklastPos;
    static public bool WoodSkillOpen = false;
    public static bool WindSkillOpen = false;
    private const byte WIND_SKILL_OP = 16;
    private const byte DELETE_COIN = 21;
    private const byte COIN_NUM = 22;
    //[Header("Boss物件")]
    /*[SerializeField]
    private GameObject Boss;*/
    static public bool isskill_water = false; //使用水技能
    float timer = 1;
    float timer_button = 0;
    static public float atk_speed = 1f;
    int CDtime = 30;
    //[SerializeField]
    bool mousedowun = false;
    public PhotonView PV;
    // Start is called before the first frame update
    int viewid;
    public static bool Delete_Coin;
    public static int Coin;
    public static bool isClickCoin = false;
    void Awake()
    {
        PV = gameObject.transform.parent.parent.parent.GetComponent<PhotonView>();

        //Arrow = (GameObject)Resources.Load("FIREBALL_V02");
        Skill_btn.interactable = false;
        //gameObject.AddComponent<Rigidbody>();
        if (gameObject.name == "Wood_V2_08_L")
        {
            CDtime = 20;
        }
        if (gameObject.name == "Water_Bake_02")
        {
            CDtime = 17;
        }
        if (gameObject.name == "Fire_Bake_01")
        {
            CDtime = 25;
        }
        if (gameObject.name == "RoundOne2_GOLD1")
        {
            CDtime = 15;
        }
        if (gameObject.name == "Rock_V04")
        {
            CDtime = 30;
        }
        if (gameObject.name == "Wind_Bake_01")
        {
            CDtime = 30;
        }
        //Debug.Log(CDtime);
        //GameObject.Find("Coin(Clone)").transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!PV.IsMine)
        {
            gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
        }
        timer_button += Time.deltaTime;
        Skill_btn.GetComponent<Image>().fillAmount = timer_button / CDtime;
        if (timer_button >= CDtime)
        {
            Skill_btn.interactable = true;
            Skill_btn.GetComponent<Image>().fillAmount = 1;
            //PhotonNetwork.Destroy(GameObject.Find("wood_circle(Clone)"));
        }
        look_pos = GameObject.FindGameObjectWithTag("Boss").transform.position;//Boss.transform.position;
        Player1.transform.LookAt(look_pos);

        if (WindSkillOpen)
        {
            GameObject.Find("Wind_Bake_01").transform.parent.GetChild(2).gameObject.SetActive(true);
            GameObject.Find("Wind_Bake_01").SetActive(false);
            //Destroy(gameObject.GetComponent<Animator>());
            //WindSkillOpen = false;
        }
        if (Delete_Coin)
        {
            Destroy(GameObject.Find("Coin(Clone)"));
            Delete_Coin = false;
        }
        if (Coin == 0 && isClickCoin)
        {
            GameObject.Find("Coin(Clone)").transform.GetChild(0).GetComponent<Animator>().SetBool("front", true);
            Debug.Log("正面");
            isClickCoin = false;
        }
        else if (Coin == 1 && isClickCoin)
        {
            GameObject.Find("Coin(Clone)").transform.GetChild(0).GetComponent<Animator>().SetBool("back", true);
            Debug.Log("背面");
            isClickCoin = false;
        }
        GameObject obj = GameObject.Find("Coin(Clone)");
        if (obj)
        {
            obj.transform.SetParent(GameObject.Find("goldcharacter(Clone)").transform, true);
        }
    }

    private void BoolWindSkillOpen()
    {
        bool WindSkillOpen = true;
        object[] datas = new object[] { WindSkillOpen };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(WIND_SKILL_OP, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    public void OnPointerDown()
    {
        if (timer >= 0.5f)
        {
            timer = 0;
            if (gameObject.name == "Wood_V2_08_L")
            {
                Debug.Log("木");
                PhotonNetwork.Instantiate("Effect/FB/FB_WOOD", new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                timer = 0;
            }
            if (gameObject.name == "Water_Bake_02")
            {
                Debug.Log("水");
                PhotonNetwork.Instantiate("Effect/FB/FB_WATER", new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                timer = 0;
            }
            if (gameObject.name == "Fire_Bake_01")
            {
                Debug.Log("火");
                PhotonNetwork.Instantiate("Effect/FB/FB_FIRE", new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                timer = 0;
            }
            if (gameObject.name == "RoundOne2_GOLD1")
            {
                Debug.Log("金");
                PhotonNetwork.Instantiate("Effect/FB/FB_GOLD", new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                timer = 0;
            }
            if (gameObject.name == "Rock_V04")
            {
                Debug.Log("土");
                PhotonNetwork.Instantiate("Effect/FB/FB_ROCK", new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                timer = 0;
            }
            if (gameObject.name == "Wind_Bake_01")
            {
                Debug.Log("風");
                PhotonNetwork.Instantiate("Effect/FB/FB_WIND", new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
                timer = 0;
            }
        }
    }

    public void OnPointerUp()
    {
        mousedowun = false;
    }
    
    public void OnClickSkillwood()
    {
        hachu.Play();
        if (timer_button >= CDtime)
        {
            PhotonNetwork.Instantiate("Effect/wood_circle", transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            joyconIMG.color = new Color(255, 255, 255, 255);
            handle.color = new Color(255, 255, 255, 255);
            Skill_btnwood.SetActive(false);
            timer_button = 0;
            
            Skill_btn.interactable = false;
            WoodSkillOpen = true;
        }
    }
    public void OnClickSkillwater()
    {
        hachu.Play();
        PhotonNetwork.Instantiate("Effect/WATER_V05", SpawnPosition.transform.position, transform.rotation);
        isskill_water = true;
        timer_button = 0;
        Skill_btn.GetComponent<Image>().fillAmount = 0;
        Skill_btn.interactable = false;
    }
    public void OnClickSkillgold()
    {
        hachu.Play();
        isClickCoin = true;
        if (PV.IsMine)
        {
            Coin = Random.Range(0, 2);
        }
        Coin_Num();
        PhotonNetwork.Instantiate("Effect/Coin", new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));

        //int coin = Random.Range(0, 2);


        timer_button = 0;
        Skill_btn.GetComponent<Image>().fillAmount = 0;
        Skill_btn.interactable = false;
        StartCoroutine(coin_delete());
    }
    public void OnClickSkillwind()
    {
        hachu.Play();
        wind.SetActive(false);
        tornado.SetActive(true);
        timer_button = 0;
        Skill_btn.GetComponent<Image>().fillAmount = 0;
        Skill_btn.interactable = false;
        BoolWindSkillOpen();
    }
    public void OnClickSkillrock()
    {
        hachu.Play();
        PhotonNetwork.Instantiate("Effect/rockkkkkk", new Vector3(transform.position.x, -0.6f, transform.position.z + 6), Quaternion.Euler(-90, 0, 0));
        timer_button = 0;
        Skill_btn.GetComponent<Image>().fillAmount = 0;
        Skill_btn.interactable = false;
    }
    public void OnClickSkillfire()
    {
        hachu.Play();
        PhotonNetwork.Instantiate("Effect/fireball", SpawnPosition.transform.position, transform.rotation);
        timer_button = 0;
        Skill_btn.GetComponent<Image>().fillAmount = 0;
        Skill_btn.interactable = false;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 為玩家本人的狀態, 將 IsFiring 的狀態更新給其他玩家
            stream.SendNext(Arrow.transform.position);
        }
        else if (stream.IsReading)
        {
            // 非為玩家本人的狀態, 單純接收更新的資料
            Arrow.transform.position = (Vector3)stream.ReceiveNext();
        }
    }
    IEnumerator coin_delete()
    {
        yield return new WaitForSeconds(3);
        Delete();
    }
    private void Delete()
    {
        bool Delete_Coin = true;
        object[] datas = new object[] { Delete_Coin };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(DELETE_COIN, datas, raiseEventOptions, SendOptions.SendReliable);
    }
    private void Coin_Num()
    {
        int coin = Coin;
        bool isClickCoin = true;
        object[] datas = new object[] { coin, isClickCoin };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(COIN_NUM, datas, raiseEventOptions, SendOptions.SendReliable);
    }
}
