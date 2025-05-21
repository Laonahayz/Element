using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerLifeFollow : MonoBehaviour
{
    public GameObject Player;
    public float numy; //3.5f
    public float numz;
    Vector3 pos;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = gameObject.transform.parent.parent.parent.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine)
        {
            pos = new Vector3(Player.transform.position.x, Player.transform.position.y + numy, Player.transform.position.z + numz);
            //transform.Translate(Boss.transform.position*Time.deltaTime*5f,Space.World);
            transform.position = Vector3.Lerp(transform.position, pos, 0.5f);
        }
    }
}
