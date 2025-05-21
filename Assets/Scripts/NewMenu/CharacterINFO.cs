using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterINFO : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pressing = false;
    private float pointerdownTimer;
    private float holdtime = 1f;
    int CharacterNum;
    public GameObject WoodInfo, WaterInfo, WindInfo, GoldInfo, RockInfo, FireInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing)
        {
            pointerdownTimer += Time.deltaTime;
            if(pointerdownTimer >= holdtime)
            {
                if(CharacterNum == 1)
                {
                    WoodInfo.SetActive(true);
                }
                if (CharacterNum == 2)
                {
                    WaterInfo.SetActive(true);
                }
                if (CharacterNum == 3)
                {
                    WindInfo.SetActive(true);
                }
                if (CharacterNum == 4)
                {
                    GoldInfo.SetActive(true);
                }
                if (CharacterNum == 5)
                {
                    RockInfo.SetActive(true);
                }
                if (CharacterNum == 6)
                {
                    FireInfo.SetActive(true);
                }
                pointerdownTimer = 0;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
        if(gameObject.name == "WoodBTN")
        {
            CharacterNum = 1;
        }
        if (gameObject.name == "WaterBTN")
        {
            CharacterNum = 2;
        }
        if (gameObject.name == "WindBTN")
        {
            CharacterNum = 3;
        }
        if (gameObject.name == "GoldBTN")
        {
            CharacterNum = 4;
        }
        if (gameObject.name == "RockBTN")
        {
            CharacterNum = 5;
        }
        if (gameObject.name == "FireBTN")
        {
            CharacterNum = 6;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
        pointerdownTimer = 0;
        CharacterNum = 0;
    }

    public void OnclickX1()
    {
        WoodInfo.SetActive(false);
    }
    public void OnclickX2()
    {
        WaterInfo.SetActive(false);  
    }
    public void OnclickX3()
    {
        WindInfo.SetActive(false);
    }
    public void OnclickX4()
    {
        GoldInfo.SetActive(false);
    }
    public void OnclickX5()
    {
        RockInfo.SetActive(false);
    }
    public void OnclickX6()
    {
        FireInfo.SetActive(false);
    }
}
