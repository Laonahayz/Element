using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.Video;



public class healthBar : MonoBehaviourPun //, IPunObservable
{

    //血量設定

    public const int maxHealth = 1;
    public static float BosscurrentHealth = maxHealth;
    public GameObject ScoreCavans;
    public GameObject BGM;
    VideoPlayer BossDead = new VideoPlayer();
    bool isvedio = false;

    //血量條

    public RectTransform HealthBar, Hurt;
    public GameObject healthcanvas;
    public GameObject[] Player;

    void Update()

    {

        //按下H鈕扣血
        //將綠色血條同步到當前血量長度

        HealthBar.sizeDelta = new Vector2(BosscurrentHealth, HealthBar.sizeDelta.y);

        //呈現傷害量

        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            Hurt.sizeDelta += new Vector2(-0.1f, 0) * Time.deltaTime;
        }
        //讓傷害量(紅色血條)逐漸追上當前血量



        if (BosscurrentHealth == 1)   //還原傷害血條
        {
            Hurt.sizeDelta = new Vector2(BosscurrentHealth, HealthBar.sizeDelta.y);
        }
        if (BosscurrentHealth <= 0)
        {
            BossDead = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
            BossDead.playOnAwake = false;
            Player = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < Player.Length; i++)
            {
                Player[i].transform.parent.parent.GetChild(1).gameObject.SetActive(false);
            }
            healthcanvas.SetActive(false);
            if (!isvedio)
            {
                BossDead.Play();
                isvedio = true;
            }
            BossDead.loopPointReached += EndReached;
            BGM.SetActive(false);
            //StartCoroutine(dead_video());
            //stickCanvas.SetActive(false);
        }
    }

    //[PunRPC]
    public void Hurt1(float damage)
    {
        BosscurrentHealth -= damage;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        ScoreCavans.SetActive(true);
        Time.timeScale = 0;
    }

    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 為玩家本人的狀態, 將狀態更新給其他玩家
            stream.SendNext(currentHealth);
        }
        else if (stream.IsReading)
        {
            // 非為玩家本人的狀態, 單純接收更新的資料
            currentHealth = (float)stream.ReceiveNext();
        }
    }*/
}