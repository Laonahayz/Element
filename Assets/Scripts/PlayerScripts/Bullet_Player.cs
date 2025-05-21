using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Bullet_Player : MonoBehaviour
{
    [Header("Bullet移動速度")]
    public float Speed;

    [Header("多久刪除物件")]
    public float DeletTime;
    [Header("Boss物件")]
    Vector3 move;
    public GameObject Boss;
    public float speed = 50f;


    [Header("玩家子彈傷害")]
    public static float damage = 0.005f;//0.005f
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.Find("Boss1_Walk_02");

        Destroy(gameObject, DeletTime);
        move = (Player_Game.look_pos) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(move.x * speed * Time.deltaTime * 0.05f, 0, move.z * speed * Time.deltaTime * 0.05f), Space.World);
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Scene")
        {
            Destroy(gameObject);
        }
    }
    /*
        void OnTriggerEnter(Collider hit)
        {
            //若碰到標籤為 NPC 或 Boss 把自己毀滅
            if (hit.GetComponent<Collider>().tag == "Boss")
            {
                PhotonView BossPV = Boss.GetComponent<PhotonView>();
                if (BossPV)
                {
                    BossPV.RPC("Hurt1", RpcTarget.All, damage);
                    Debug.Log("打到一下");
                }
                Destroy(gameObject);
                //healthBar.Hurt1();
            }

        }
    */
    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
            if (stream.IsWriting)
            {
                // 為玩家本人的狀態, 將狀態更新給其他玩家
                stream.SendNext(move);
            }
            else if (stream.IsReading)
            {
                // 非為玩家本人的狀態, 單純接收更新的資料
                move = (Vector3)stream.ReceiveNext();
            
        }  
    }*/
}
