using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringcolor : MonoBehaviour
{
    public GameObject ring_gn;
    public GameObject ring_bl;
    public GameObject ring_yl;
    public GameObject ring_red;
    public GameObject ring_bn;
    public GameObject ring_wh;
    public Transform player;
    public static int num = 0;

    void OnTriggerEnter(Collider hit)
    {
        //0:金，1:木，2:水，3:火，4；土，5:風
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (hit.GetComponent<Collider>().name == "Water_Bake_02")
        {
            Debug.Log("碰到水");
            if (num == 0)
            {
                Instantiate(ring_bl, player);
                //ring_yl=GameObject.Find("ring_v02");
                Destroy(GameObject.Find("RING_V10"));
                num = 2;
            }
            else if (num == 1)
            {
                Instantiate(ring_bl, player);
                //ring_gn=GameObject.Find("ring_v03(Clone)");
                Destroy(GameObject.Find("RING_green(Clone)"));
                num = 2;
            }
            else if (num == 3)
            {
                Instantiate(ring_bl, player);
                //ring_gn=GameObject.Find("ring_v03(Clone)");
                Destroy(GameObject.Find("RING_red(Clone)"));
                num = 2;
            }
            else if (num == 4)
            {
                Instantiate(ring_bl, player);
                //ring_gn=GameObject.Find("ring_v03(Clone)");
                Destroy(GameObject.Find("RING_brown(Clone)"));
                num = 2;
            }
            else if (num == 5)
            {
                Instantiate(ring_bl, player);
                //ring_gn=GameObject.Find("ring_v03(Clone)");
                Destroy(GameObject.Find("RING_white(Clone)"));
                num = 2;
            }
            else if (num == 2)
            {

            }
        }
        else if (hit.GetComponent<Collider>().name == "Wood_V2_08_L")
        {
            Debug.Log("碰到木了");
            if (num == 0)
            {
                Instantiate(ring_gn, player);
                //ring_yl=GameObject.Find("ring_v02");
                Destroy(GameObject.Find("RING_V10"));
                num = 1;
            }
            else if (num == 2)
            {
                Instantiate(ring_gn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_blue(Clone)"));
                num = 1;
            }
            else if (num == 3)
            {
                Instantiate(ring_gn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_red(Clone)"));
                num = 1;
            }
            else if (num == 4)
            {
                Instantiate(ring_gn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_brown(Clone)"));
                num = 1;
            }
            else if (num == 5)
            {
                Instantiate(ring_gn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_white(Clone)"));
                num = 1;
            }
            else if (num == 1)
            {

            }
        }
        else if (hit.GetComponent<Collider>().name == "Fire_Bake_01")
        {
            if (num == 0)
            {
                Instantiate(ring_red, player);
                //ring_yl=GameObject.Find("ring_v02");
                Destroy(GameObject.Find("RING_V10"));
                num = 3;
            }
            else if (num == 2)
            {
                Instantiate(ring_red, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_blue(Clone)"));
                num = 3;
            }
            else if (num == 1)
            {
                Instantiate(ring_red, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_green(Clone)"));
                num = 3;
            }
            else if (num == 4)
            {
                Instantiate(ring_red, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_brown(Clone)"));
                num = 3;
            }
            else if (num == 5)
            {
                Instantiate(ring_red, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_white(Clone)"));
                num = 3;
            }
            else if (num == 3)
            {

            }
        }
        else if (hit.GetComponent<Collider>().name == "Rock_V04")
        {
            if (num == 0)
            {
                Instantiate(ring_bn, player);
                //ring_yl=GameObject.Find("ring_v02");
                Destroy(GameObject.Find("RING_V10"));
                num = 4;
            }
            else if (num == 2)
            {
                Instantiate(ring_bn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_blue(Clone)"));
                num = 4;
            }
            else if (num == 3)
            {
                Instantiate(ring_bn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("ring_v04(Clone)"));
                num = 4;
            }
            else if (num == 1)
            {
                Instantiate(ring_bn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_green(Clone)"));
                num = 4;
            }
            else if (num == 5)
            {
                Instantiate(ring_bn, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_white(Clone)"));
                num = 4;
            }
            else if (num == 4)
            {

            }
        }
        else if (hit.GetComponent<Collider>().name == "Wind_Bake_01")
        {
            if (num == 0)
            {
                Instantiate(ring_wh, player);
                //ring_yl=GameObject.Find("ring_v02");
                Destroy(GameObject.Find("RING_V10"));
                num = 5;
            }
            else if (num == 2)
            {
                Instantiate(ring_wh, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_blue(Clone)"));
                num = 5;
            }
            else if (num == 3)
            {
                Instantiate(ring_wh, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("ring_v04(Clone)"));
                num = 5;
            }
            else if (num == 1)
            {
                Instantiate(ring_wh, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_green(Clone)"));
                num = 5;
            }
            else if (num == 4)
            {
                Instantiate(ring_wh, player);
                //ring_bl=GameObject.Find("ring_v04(Clone)");
                Destroy(GameObject.Find("RING_brown(Clone)"));
                num = 5;
            }
            else if (num == 5)
            {

            }
        }
    }
}
