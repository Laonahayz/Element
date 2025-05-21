using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAvatar : MonoBehaviour
{
    public Collider AvatarCollider;
    public Collider PlayerCollider;
    // Start is called before the first frame update
    void Start()
    {
        AvatarCollider = gameObject.transform.parent.parent.parent.GetComponent<Collider>();
        Physics.IgnoreCollision(AvatarCollider, PlayerCollider);
    }

   
}
