using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss_ : MonoBehaviour
{
    public NavMeshAgent Boss_;
    public bool draging = false;
    public float checktime = 0;
    private Vector3 lastPos;
    public GameObject[] target;
    float timer = 30;
    int i = 0;

    //public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Boss_.GetComponent<NavMeshAgent>().speed = 15f;//原25
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        target = GameObject.FindGameObjectsWithTag("Player");
        //Boss_.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        Boss_.SetDestination(target[i].transform.position);
        if (timer >= 30)
        {
            if (i < target.Length - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            timer = 0;
        }
        /*BOSS2動畫測試*/
        if (Time.time - checktime > 0.1f)
        {
            checktime = Time.time;
            //判断是否有移动
            if ((transform.position - lastPos).sqrMagnitude > 0.1f)
            {
                draging = true;
            }
            else
            {
                draging = false;
            }
            lastPos = transform.position;
        }

        gameObject.GetComponent<Animator>().SetBool("isMoving", draging);
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }*/
}
