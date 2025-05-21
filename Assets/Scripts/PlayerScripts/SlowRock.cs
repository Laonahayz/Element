using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowRock : MonoBehaviour
{
    public Image CanvasIMG;
    //bool firsttime;
    float Num;
    void OnTriggerStay(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "SlowRock")
        {
            joycon.speed = 5.5f;

            Num += Time.deltaTime * 2f;
            /*if(firsttime)
            {
                Num += Time.deltaTime * 2f;
            }*/
            if (Num >= 1)
            {
                //firsttime = false;
                Num = 1;
            }
            /*if (!firsttime)
            {
                Num += Time.deltaTime*0.1f;
            }*/
            CanvasIMG.color = new Color(255, 255, 255, Num);
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<Collider>().tag == "SlowRock")
        {
            joycon.speed = 10f;
            Num = 0;
            CanvasIMG.color = new Color32(255, 255, 255, 0);
        }
    }
}
