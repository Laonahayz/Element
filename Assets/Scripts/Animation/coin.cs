using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource front;
    public AudioSource back;

    // Update is called once per frame
    public void coin_front()
    {
        front.Play();
    }
    public void coin_back()
    {
        back.Play();
    }
}
