using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class joycon : MonoBehaviourPunCallbacks
{
    /*寫布林 判斷木走路時那個布林是true*/
    public RectTransform handle;
    public RectTransform rect;
    [SerializeField] private bool draging;
    public bool isWood;
    public static float speed = 10;
    //public Rigidbody playerRD;
    public GameObject water;
    public GameObject Wood;
    public PhotonView PV;
    public Animator anim;
    public static Vector3 dir;
    // Start is called before the first frame update
    /*應該同步"draging"這個布林*/
    void Start()
    {
        draging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Drag();
    }
    public void StartDrag()
    {
        draging = true;
    }
    public void Drag()
    {
        if (!draging)
        {
            dir=new Vector3(0,0,0);
            return;
        }
        
        Vector2 newPos = (Vector2)handle.anchoredPosition;
        //Debug.Log("mouse:"+Input.mousePosition+"rect"+rect.anchoredPosition);
        Vector2 pos = Vector2.ClampMagnitude(newPos, 100);
        Vector3 mov = new Vector3(pos.x, 0f, pos.y);
        
        //handle.anchoredPosition = pos;
        if (Player_Game.isskill_water){ //如果使用水技能
            water = GameObject.Find("WATER_V05(Clone)");
            Quaternion qua = Quaternion.LookRotation(mov.normalized);
            water.transform.rotation = Quaternion.Lerp(water.transform.rotation, qua, Time.deltaTime * speed);
        }
        else
        {
            dir = (mov) * speed * Time.deltaTime;
            //playerRD.velocity = (mov / 100) * speed * Time.deltaTime;
            //player.Translate(dir);
        }
    }
    public void StopDrag()
    {
        draging = false;
        //handle.anchoredPosition = Vector2.zero;
    }

}
