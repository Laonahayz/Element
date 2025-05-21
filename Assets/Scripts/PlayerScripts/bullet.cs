using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class bullet : MonoBehaviourPun
{
    public GameObject shoot;
    public GameObject[] ten;
    public GameObject[] X;
    public AudioSource Attacksorce;
    private const byte BOSS_BULLET = 20;
    public static int FinalNum;
    float timer = 0;

    bool isAttack;
    public GameObject dust1;
    void Start()
    {
        InvokeRepeating("shoooot", 0.5f, 0.5f);
    }
    public void audio()
    {
        Attacksorce.Play();
    }
    public void dust_Open()
    {
        //dust1.SetActive(true);
    }
    public void dust_Close()
    {
        //dust1.SetActive(false);
    }
    void shoooot()
    {
        isAttack = true;
        FinalNum = Random.Range(0, 2);
        if (FinalNum == 0)
        {
            Instantiate(shoot, ten[0].transform.position, ten[0].transform.rotation);
            Instantiate(shoot, ten[1].transform.position, ten[1].transform.rotation);
            Instantiate(shoot, ten[2].transform.position, ten[2].transform.rotation);
            Instantiate(shoot, ten[3].transform.position, ten[3].transform.rotation);
        }
        else if (FinalNum == 1)
        {
            Instantiate(shoot, X[0].transform.position, X[0].transform.rotation);
            Instantiate(shoot, X[1].transform.position, X[1].transform.rotation);
            Instantiate(shoot, X[2].transform.position, X[2].transform.rotation);
            Instantiate(shoot, X[3].transform.position, X[3].transform.rotation);
        }
        gameObject.GetComponent<Animator>().SetBool("isAttack", isAttack);
        isAttack = false;
    }
}
