using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerLife_Controll : MonoBehaviour
{
    public const int maxHealth = 1;
    public static float WoodcurrentHealth = maxHealth;
    public static float WatercurrentHealth = maxHealth;
    public static float WindcurrentHealth = maxHealth;
    public static float GoldcurrentHealth = maxHealth;
    public static float RockcurrentHealth = maxHealth;
    public static float FirecurrentHealth = maxHealth;
    public GameObject[] ThePlayers;
    public Image[] PlayersIMG;
    public Sprite[] PlayersSprite;
    public Image[] BuffIMG;
    public Sprite[] BuffSprite;

    public RectTransform[] PlayersHealth;
    public RectTransform[] PlayersHurt;
    private RectTransform WoodHealth, WoodHurt;
    private RectTransform WaterHealth, WaterHurt;
    private RectTransform WindHealth, WindHurt;
    private RectTransform GoldHealth, GoldHurt;
    private RectTransform RockHealth, RockHurt;
    private RectTransform FireHealth, FireHurt;

    private RectTransform WoodHisMeealth, WoodHisMeHurt;
    private RectTransform WaterisMeHealth, WaterisMeHurt;
    private RectTransform WindisMeHealth, WindisMeHurt;
    private RectTransform GoldisMeHealth, GoldisMeHurt;
    private RectTransform RockisMeHealth, RockisMeHurt;
    private RectTransform FireisMeHealth, FireisMeHurt;
    static public bool isWoodAlive, isWaterAlive, isFireAlive, isRockAlive, isGoldAlive, isWindAlive;
    //public Text BOSSAttack, PlayerAttack, PlayerAttackSpeed, PlayerWalkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isWoodAlive = true;
        isWaterAlive = true;
        isFireAlive = true;
        isRockAlive = true;
        isGoldAlive = true;
        isWindAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //BOSSAttack.text = "現BOSS攻擊：" + bullet_move.damage.ToString();
        //PlayerAttack.text = "原BOSS攻擊：" + bullet_move.BOSS1_Ori_damage.ToString();
        //PlayerAttack.text = "PLAYER攻擊：" + Bullet_Player.damage.ToString();
        /*PlayerAttackSpeed.text = "PLAYER攻速：" + Player_Game.atk_speed.ToString() + "秒/發";
        PlayerWalkSpeed.text = "PLAYER跑速：" + joycon.speed.ToString();*/
        ThePlayers = GameObject.FindGameObjectsWithTag("Player");
        PlayerLifeChange();
        PlayerBuffIcon();
    }
    public void PlayerLifeChange()
    {
        for (int i = 0; i < ThePlayers.Length; i++)
        {
            PlayersIMG[i].gameObject.SetActive(true);
            PlayersHealth[i].gameObject.SetActive(true);
            PlayersHurt[i].gameObject.SetActive(true);
            if (ThePlayers[i].name == "Wood_V2_08_L")
            {
                PlayersIMG[i].sprite = PlayersSprite[0];
                WoodHealth = PlayersHealth[i];
                WoodHurt = PlayersHurt[i];
                if (ThePlayers[i].transform.parent.parent.parent.GetComponent<PhotonView>().IsMine)
                {
                    WoodHisMeealth = GameObject.Find("Lifepoint_Wood").GetComponent<RectTransform>();
                    WoodHisMeHurt = GameObject.Find("Hurt_Wood").GetComponent<RectTransform>();
                    WoodHisMeealth.sizeDelta = new Vector2(WoodcurrentHealth, WoodHisMeealth.sizeDelta.y);
                    if (WoodHisMeHurt.sizeDelta.x > WoodHisMeealth.sizeDelta.x)
                    {
                        //讓傷害量(紅色血條)逐漸追上當前血量
                        WoodHisMeHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 5; //原本倍數為10
                    }
                }

                if (WoodcurrentHealth > 1)
                {
                    WoodcurrentHealth = 1;
                }
                if (WoodcurrentHealth < 0)
                {
                    WoodcurrentHealth = 0;
                    PlayersIMG[i].color = new Color32(135, 135, 135, 255);
                }
                if (WoodcurrentHealth > 0)
                {
                    PlayersIMG[i].color = new Color32(255, 255, 255, 255);
                }
                WoodHealth.sizeDelta = new Vector2(WoodcurrentHealth, WoodHealth.sizeDelta.y);
                if (WoodHurt.sizeDelta.x > WoodHealth.sizeDelta.x)
                {
                    //讓傷害量(紅色血條)逐漸追上當前血量
                    WoodHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15; //原本倍數為10
                }
            }

            if (ThePlayers[i].name == "Water_Bake_02")
            {
                PlayersIMG[i].sprite = PlayersSprite[1];
                WaterHealth = PlayersHealth[i];
                WaterHurt = PlayersHurt[i];
                if (ThePlayers[i].transform.parent.parent.parent.GetComponent<PhotonView>().IsMine)
                {
                    WaterisMeHealth = GameObject.Find("Lifepoint_Water").GetComponent<RectTransform>();
                    WaterisMeHurt = GameObject.Find("Hurt_Water").GetComponent<RectTransform>();
                    WaterisMeHealth.sizeDelta = new Vector2(WatercurrentHealth, WaterisMeHealth.sizeDelta.y);
                    if (WaterisMeHurt.sizeDelta.x > WaterisMeHealth.sizeDelta.x)
                    {
                        //讓傷害量(紅色血條)逐漸追上當前血量
                        WaterisMeHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15; //原本倍數為10
                    }
                }
                //WaterHealth = GameObject.Find("Lifepoint_Water").GetComponent<RectTransform>();
                //WaterHurt = GameObject.Find("Hurt_Water").GetComponent<RectTransform>();
                
                if (WatercurrentHealth > 1)
                {
                    WatercurrentHealth = 1;
                }
                if (WatercurrentHealth < 0)
                {
                    WatercurrentHealth = 0;
                    PlayersIMG[i].color = new Color32(135, 135, 135, 255);
                }
                if (WatercurrentHealth > 0)
                {
                    PlayersIMG[i].color = new Color32(255, 255, 255, 255);
                }
                WaterHealth.sizeDelta = new Vector2(WatercurrentHealth, WaterHealth.sizeDelta.y);
                if (WaterHurt.sizeDelta.x > WaterHealth.sizeDelta.x)
                {
                    //讓傷害量(紅色血條)逐漸追上當前血量
                    WaterHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15;
                }
            }

            if (ThePlayers[i].transform.parent.parent.name == "windcharacter(Clone)")
            {
                PlayersIMG[i].sprite = PlayersSprite[2];
                WindHealth = PlayersHealth[i];
                WindHurt = PlayersHurt[i];
                if (ThePlayers[i].transform.parent.parent.parent.GetComponent<PhotonView>().IsMine)
                {
                    WindisMeHealth = GameObject.Find("Lifepoint_Wind").GetComponent<RectTransform>();
                    WindisMeHurt = GameObject.Find("Hurt_Wind").GetComponent<RectTransform>();
                    WindisMeHealth.sizeDelta = new Vector2(WindcurrentHealth, WindisMeHealth.sizeDelta.y);
                    if (WindisMeHurt.sizeDelta.x > WindisMeHealth.sizeDelta.x)
                    {
                        //讓傷害量(紅色血條)逐漸追上當前血量
                        WindisMeHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15; //原本倍數為10
                    }
                }
                
                if (WindcurrentHealth > 1)
                {
                    WindcurrentHealth = 1;
                }
                if (WindcurrentHealth < 0)
                {
                    WindcurrentHealth = 0;
                    PlayersIMG[i].color = new Color32(135, 135, 135, 255);
                }
                if (WindcurrentHealth > 0)
                {
                    PlayersIMG[i].color = new Color32(255, 255, 255, 255);
                }
                WindHealth.sizeDelta = new Vector2(WindcurrentHealth, WindHealth.sizeDelta.y);
                if (WindHurt.sizeDelta.x > WindHealth.sizeDelta.x)
                {
                    //讓傷害量(紅色血條)逐漸追上當前血量
                    WindHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15;
                }
            }

            if (ThePlayers[i].name == "RoundOne2_GOLD1")
            {
                PlayersIMG[i].sprite = PlayersSprite[3];
                GoldHealth = PlayersHealth[i];
                GoldHurt = PlayersHurt[i];
                if (ThePlayers[i].transform.parent.parent.parent.GetComponent<PhotonView>().IsMine)
                {
                    GoldisMeHealth = GameObject.Find("Lifepoint_Gold").GetComponent<RectTransform>();
                    GoldisMeHurt = GameObject.Find("Hurt_Gold").GetComponent<RectTransform>();
                    GoldisMeHealth.sizeDelta = new Vector2(GoldcurrentHealth, GoldisMeHealth.sizeDelta.y);
                    if (GoldisMeHurt.sizeDelta.x > GoldisMeHealth.sizeDelta.x)
                    {
                        //讓傷害量(紅色血條)逐漸追上當前血量
                        GoldisMeHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15; //原本倍數為10
                    }
                }
                
                if (GoldcurrentHealth > 1)
                {
                    GoldcurrentHealth = 1;
                }
                if (GoldcurrentHealth < 0)
                {
                    GoldcurrentHealth = 0;
                    PlayersIMG[i].color = new Color32(135, 135, 135, 255);
                }
                if (GoldcurrentHealth > 0)
                {
                    PlayersIMG[i].color = new Color32(255, 255, 255, 255);
                }
                GoldHealth.sizeDelta = new Vector2(GoldcurrentHealth, GoldHealth.sizeDelta.y);
                if (GoldHurt.sizeDelta.x > GoldHealth.sizeDelta.x)
                {
                    //讓傷害量(紅色血條)逐漸追上當前血量
                    GoldHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15;
                }
            }
            if (ThePlayers[i].name == "Rock_V04")
            {
                PlayersIMG[i].sprite = PlayersSprite[4];
                RockHealth = PlayersHealth[i];
                RockHurt = PlayersHurt[i];
                if (ThePlayers[i].transform.parent.parent.parent.GetComponent<PhotonView>().IsMine)
                {
                    RockisMeHealth = GameObject.Find("Lifepoint_Rock").GetComponent<RectTransform>();
                    RockisMeHurt = GameObject.Find("Hurt_Rock").GetComponent<RectTransform>();
                    RockisMeHealth.sizeDelta = new Vector2(RockcurrentHealth, RockisMeHealth.sizeDelta.y);
                    if (RockisMeHurt.sizeDelta.x > RockisMeHealth.sizeDelta.x)
                    {
                        //讓傷害量(紅色血條)逐漸追上當前血量
                        RockisMeHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15; //原本倍數為10
                    }
                }
                if (RockcurrentHealth > 1)
                {
                    RockcurrentHealth = 1;
                }
                if (RockcurrentHealth < 0)
                {
                    RockcurrentHealth = 0;
                    PlayersIMG[i].color = new Color32(135, 135, 135, 255);
                }
                if (RockcurrentHealth > 0)
                {
                    PlayersIMG[i].color = new Color32(255, 255, 255, 255);
                }
                RockHealth.sizeDelta = new Vector2(RockcurrentHealth, RockHealth.sizeDelta.y);
                if (RockHurt.sizeDelta.x > RockHealth.sizeDelta.x)
                {
                    //讓傷害量(紅色血條)逐漸追上當前血量
                    RockHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15;
                }
            }
            if (ThePlayers[i].name == "Fire_Bake_01")
            {
                PlayersIMG[i].sprite = PlayersSprite[5];
                FireHealth = PlayersHealth[i];
                FireHurt = PlayersHurt[i];
                if (ThePlayers[i].transform.parent.parent.parent.GetComponent<PhotonView>().IsMine)
                {
                    FireisMeHealth = GameObject.Find("Lifepoint_Fire").GetComponent<RectTransform>();
                    FireisMeHurt = GameObject.Find("Hurt_Fire").GetComponent<RectTransform>();
                    FireisMeHealth.sizeDelta = new Vector2(FirecurrentHealth, FireisMeHealth.sizeDelta.y);
                    if (FireisMeHurt.sizeDelta.x > FireisMeHealth.sizeDelta.x)
                    {
                        //讓傷害量(紅色血條)逐漸追上當前血量
                        FireisMeHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15; //原本倍數為10
                    }
                }
                if (FirecurrentHealth > 1)
                {
                    FirecurrentHealth = 1;
                }
                if (FirecurrentHealth < 0)
                {
                    FirecurrentHealth = 0;
                    PlayersIMG[i].color = new Color32(135, 135, 135, 255);
                }
                if (FirecurrentHealth > 0)
                {
                    PlayersIMG[i].color = new Color32(255, 255, 255, 255);
                }
                FireHealth.sizeDelta = new Vector2(FirecurrentHealth, FireHealth.sizeDelta.y);
                if (FireHurt.sizeDelta.x > FireHealth.sizeDelta.x)
                {
                    //讓傷害量(紅色血條)逐漸追上當前血量
                    FireHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 15;
                }
            }
        }
    }
    public void PlayerBuffIcon()
    {
        for (int i = 0; i < ThePlayers.Length; i++)
        {
            /*防禦力*/
            if (bullet_move.damage == 0.015f)    //UP
            {
                BuffIMG[i].sprite = BuffSprite[0];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            else if (bullet_move.damage == 0.045f)    //DOWN
            {
                BuffIMG[i].sprite = BuffSprite[1];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            /*攻擊力*/
            else if (Bullet_Player.damage == 0.0075f)  //UP
            {
                BuffIMG[i].sprite = BuffSprite[2];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            else if (Bullet_Player.damage == 0.0025f)  //DOWN
            {
                BuffIMG[i].sprite = BuffSprite[3];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            /*攻速*/
            else if (Player_Game.atk_speed == 0.5f)  //UP
            {
                BuffIMG[i].sprite = BuffSprite[4];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            else if (Player_Game.atk_speed == 1.5f)  //DOWN
            {
                BuffIMG[i].sprite = BuffSprite[5];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }

            /*跑速*/
            else if (joycon.speed == 15f)  //UP
            {
                BuffIMG[i].sprite = BuffSprite[6];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            else if (joycon.speed == 5f)  //DOWN
            {
                BuffIMG[i].sprite = BuffSprite[7];
                BuffIMG[i].color = new Color(255, 255, 255, 255);
            }
            /*重置*/
            else if (Player_Game.atk_speed == 1f && joycon.speed == 10f && Bullet_Player.damage == 0.005f && bullet_move.damage == bullet_move.BOSS1_Ori_damage)
            {
                BuffIMG[i].color = new Color(255, 255, 255, 0);
            }
        }
    }
}
