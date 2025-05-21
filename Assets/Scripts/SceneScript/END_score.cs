using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class END_score : MonoBehaviour
{
    GameObject[] player;
    float[,] player_score = new float[5, 6];
    string[] player_num = new string[4];
    public Text player1_Cure, player1_Hurt, player1_Death, player1_Rescue;
    public Text player2_Cure, player2_Hurt, player2_Death, player2_Rescue;
    public Text player3_Cure, player3_Hurt, player3_Death, player3_Rescue;
    public Text player4_Cure, player4_Hurt, player4_Death, player4_Rescue;
    public Text player1_Name, player2_Name, player3_Name, player4_Name;
    public Text[] Title = new Text[4];
    public Image[] playerIMG;
    public Sprite[] CharacterSprites;
    bool isdisplay = false;
    public Text text;
    float[] rescure = new float[4]; // 救護車/救死扶傷/提燈天使
    float[] hurt_p = new float[4]; // 背骨仔/無情背刺
    float[] hurt_n = new float[4]; // 神隊友/精神輸出
    float[] bad = new float[4]; //就你在雷
    public GameObject[] player_canvas = new GameObject[4];

    //scroe，0:角色，1:傷害量，2:治療量，3:死亡次數，4:幫復次數，5:對隊友造成ㄉ傷害
    // Start is called before the first frame update
    void Start()
    {
        Player[] players = PhotonNetwork.PlayerList;
        player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].name == "Wood_V2_08_L")
            {
                player_score[i, 0] = i;
                player_score[i, 1] = Player_score.Player_wood[0];
                player_score[i, 2] = Player_score.Player_wood[1];
                player_score[i, 3] = Player_score.Player_wood[2];
                player_score[i, 4] = Player_score.Player_wood[3];
                player_score[i, 5] = Player_score.Player_wood[4];
                //player_num[i]="Wood_V2_08_L";
                player_num[i] = player[i].gameObject.transform.parent.parent.parent.GetComponent<PhotonView>().Controller.NickName;
                playerIMG[i].sprite = CharacterSprites[0];
                player_canvas[i].SetActive(true);
            }
            else if (player[i].name == "Water_Bake_02")
            {
                player_score[i, 0] = i;
                player_score[i, 0] = Player_score.Player_water[0];
                player_score[i, 2] = Player_score.Player_water[1];
                player_score[i, 3] = Player_score.Player_water[2];
                player_score[i, 4] = Player_score.Player_water[3];
                player_score[i, 5] = Player_score.Player_water[4];
                player_num[i] = player[i].gameObject.transform.parent.parent.parent.GetComponent<PhotonView>().Controller.NickName;
                playerIMG[i].sprite = CharacterSprites[1];
                player_canvas[i].SetActive(true);
            }
            else if (player[i].name == "Wind_Bake_01")
            {
                player_score[i, 0] = i;
                player_score[i, 1] = Player_score.Player_wind[0];
                player_score[i, 2] = Player_score.Player_wind[1];
                player_score[i, 3] = Player_score.Player_wind[2];
                player_score[i, 4] = Player_score.Player_wind[3];
                player_score[i, 5] = Player_score.Player_wind[4];
                player_num[i] = player[i].gameObject.transform.parent.parent.parent.GetComponent<PhotonView>().Controller.NickName;
                playerIMG[i].sprite = CharacterSprites[2];
                player_canvas[i].SetActive(true);
            }
            else if (player[i].name == "Rock_V04")
            {
                player_score[i, 0] = i;
                player_score[i, 1] = Player_score.Player_rock[0];
                player_score[i, 2] = Player_score.Player_rock[1];
                player_score[i, 3] = Player_score.Player_rock[2];
                player_score[i, 4] = Player_score.Player_rock[3];
                player_score[i, 5] = Player_score.Player_rock[4];
                player_num[i] = player[i].gameObject.transform.parent.parent.parent.GetComponent<PhotonView>().Controller.NickName;
                playerIMG[i].sprite = CharacterSprites[3];
                player_canvas[i].SetActive(true);
            }
            else if (player[i].name == "RoundOne2_GOLD1")
            {
                player_score[i, 0] = i;
                player_score[i, 1] = Player_score.Player_gold[0];
                player_score[i, 2] = Player_score.Player_gold[1];
                player_score[i, 3] = Player_score.Player_gold[2];
                player_score[i, 4] = Player_score.Player_gold[3];
                player_score[i, 5] = Player_score.Player_gold[4];
                player_num[i] = player[i].gameObject.transform.parent.parent.parent.GetComponent<PhotonView>().Controller.NickName;
                playerIMG[i].sprite = CharacterSprites[4];
                player_canvas[i].SetActive(true);
            }
            else if (player[i].name == "Fire_Bake_01")
            {
                player_score[i, 0] = i;
                player_score[i, 1] = Player_score.Player_fire[0];
                player_score[i, 2] = Player_score.Player_fire[1];
                player_score[i, 3] = Player_score.Player_fire[2];
                player_score[i, 4] = Player_score.Player_fire[3];
                player_score[i, 5] = Player_score.Player_fire[4];
                player_num[i] = player[i].gameObject.transform.parent.parent.parent.GetComponent<PhotonView>().Controller.NickName;
                playerIMG[i].sprite = CharacterSprites[5];
                player_canvas[i].SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isdisplay == false)
        {
            player1_Name.text = player_num[0];
            player1_Hurt.text = player_score[0, 1].ToString("0");
            player1_Cure.text = player_score[0, 2].ToString("0");
            player1_Death.text = player_score[0, 3].ToString("0");
            player1_Rescue.text = player_score[0, 4].ToString("0");

            player2_Name.text = player_num[1];
            player2_Hurt.text = player_score[1, 1].ToString("0");
            player2_Cure.text = player_score[1, 2].ToString("0");
            player2_Death.text = player_score[1, 3].ToString("0");
            player2_Rescue.text = player_score[1, 4].ToString("0");

            player3_Name.text = player_num[2];
            player3_Hurt.text = player_score[2, 1].ToString("0");
            player3_Cure.text = player_score[2, 2].ToString("0");
            player3_Death.text = player_score[2, 3].ToString("0");
            player3_Rescue.text = player_score[2, 4].ToString("0");

            player4_Name.text = player_num[3];
            player4_Hurt.text = player_score[3, 1].ToString("0");
            player4_Cure.text = player_score[3, 2].ToString("0");
            player4_Death.text = player_score[3, 3].ToString("0");
            player4_Rescue.text = player_score[3, 4].ToString("0");
            isdisplay = true;
        }
        text.text = "玩家1：" + player_num[0] + "傷害量：" + player_score[0, 1] + "治療量：" + player_score[0, 2] + "死亡數：" + player_score[0, 3] + "救援數：" + player_score[0, 4] + "，玩家2：" + player_num[1] + "傷害量：" + player_score[1, 1] + "治療量：" + player_score[1, 2] + "死亡數：" + player_score[1, 3] + "救援數：" + player_score[1, 4];


        //對隊友造成傷害*C+死亡次數*D (C:D=1:10)
        bad[0] = player_score[0, 5] + (player_score[0, 3] * 10);
        bad[1] = player_score[1, 5] + (player_score[1, 3] * 10);
        bad[2] = player_score[2, 5] + (player_score[2, 3] * 10);
        bad[3] = player_score[3, 5] + (player_score[3, 3] * 10);

        for (int i = 0; i < 3; i++)
        {
            if (bad[i] >= bad[0] && bad[i] >= bad[1] && bad[i] >= bad[2] && bad[i] >= bad[3] && bad[i] != 0)
            {
                Title[i].text = "就你在雷";
            }
        }


        //造成治療量*X+復活隊友次數*Y  (X:Y=1:20)
        rescure[0] = player_score[0, 2] + (player_score[0, 4] * 20);
        rescure[1] = player_score[1, 2] + (player_score[1, 4] * 20);
        rescure[2] = player_score[2, 2] + (player_score[2, 4] * 20);
        rescure[3] = player_score[3, 2] + (player_score[3, 4] * 20);
        for (int i = 0; i < 3; i++)
        {
            if (rescure[i] >= rescure[0] && rescure[i] >= rescure[1] && rescure[i] >= rescure[2] && rescure[i] >= rescure[3] && rescure[i] != 0)
            {
                Title[i].text = "大奶媽";
            }
        }

        //對隊友造成傷害
        hurt_p[0] = player_score[0, 5];
        hurt_p[1] = player_score[1, 5];
        hurt_p[2] = player_score[2, 5];
        hurt_p[3] = player_score[3, 5];

        for (int i = 0; i < 3; i++)
        {
            if (hurt_p[i] >= hurt_p[0] && hurt_p[i] >= hurt_p[1] && hurt_p[i] >= hurt_p[2] && hurt_p[i] >= hurt_p[3] && hurt_p[i] != 0)
            {
                Title[i].text = "背骨仔";
            }
        }

        //對敵人造成傷害*A-對隊友造成傷害*B (A:B=3:1)
        hurt_n[0] = (player_score[0, 1] * 3) - player_score[0, 5];
        hurt_n[1] = (player_score[1, 1] * 3) - player_score[1, 5];
        hurt_n[2] = (player_score[2, 1] * 3) - player_score[2, 5];
        hurt_n[3] = (player_score[3, 1] * 3) - player_score[3, 5];

        for (int i = 0; i < 3; i++)
        {
            if (hurt_n[i] >= hurt_n[0] && hurt_n[i] >= hurt_n[1] && hurt_n[i] >= hurt_n[2] && hurt_n[i] >= hurt_n[3] && hurt_n[i] != 0)
            {
                Title[i].text = "神隊友";
            }
        }
    }


}
