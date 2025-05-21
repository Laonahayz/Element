using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_rock : MonoBehaviour
{
    public GameObject Boss;
    public GameObject[] tagObject;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
        InvokeRepeating("delete", 5f, 5f);
    }

    // Update is called once per frame
    void delete()
    {
        Destroy(gameObject);
        Boss.GetComponent<boss_>().enabled = true;
        tagObject = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < tagObject.Length; i++)
        {
            tagObject[i].transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = true;
        }
    }
    void OnParticleCollision(GameObject other)
    {
        //若碰到標籤為 NPC 或 Boss 把自己毀滅
        if (other.tag == "Boss")
        {
            Debug.Log("碰Boss");
            other.GetComponent<boss_>().enabled = false;
        }
        if (other.tag == "Player")
        {
            Debug.Log("碰玩家");
            other.transform.parent.parent.parent.GetComponent<PlayerMove>().enabled = false;
        }
    }
}
