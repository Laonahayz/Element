using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PV.IsMine)
        {
            /*Rigidbody PlayerRD = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Rigidbody>();
            PlayerRD.velocity = joycon.dir * 0.5f;*/
            
            gameObject.transform.Translate(joycon.dir*0.01f);
            
        }

    }
}
