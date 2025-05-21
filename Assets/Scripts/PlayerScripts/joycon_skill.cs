using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joycon_skill : MonoBehaviour
{
    public RectTransform handle;
    public RectTransform rect;
    bool draging = false;
    public float speed = 1;
    static public Vector3 dir;
    static public bool deterdrag = false;
    public GameObject player;
    public GameObject Skill_btn;
    public Image joycon, handle_i;
    float timer = 0f;
    float timer2 = 0f;
    bool stopdrag = false;
    public GameObject skill;
    void Update()
    {
        if (Player_Game.WoodSkillOpen)
        {
            Drag();
            //Debug.Log(deterdrag);
            timer += Time.deltaTime;
            skill = GameObject.Find("wood_circle(Clone)");
        }
    }
    public void StartDrag()
    {
        deterdrag = false;
        draging = true;
    }
    public void Drag()
    {
        if (!draging)
        {
            dir = new Vector3(0, 0, 0);
            return;
        }
        else
        {
            Vector2 newPos = (Vector2)handle.anchoredPosition;
            //Debug.Log("mouse:"+Input.mousePosition+"rect"+rect.anchoredPosition);
            Vector2 pos = Vector2.ClampMagnitude(newPos, 100);
            Vector3 mov = new Vector3(pos.x, 0f, pos.y);
            //handle.anchoredPosition = pos;
            dir = (mov / 80) * speed * Time.deltaTime;
            skill.transform.Translate(dir);
        }
    }
    public void StopDrag()
    {
        draging = false;
        handle.anchoredPosition = Vector2.zero;
        deterdrag = true;
        joycon.color = new Color(255, 255, 255, 0);
        handle_i.color = new Color(255, 255, 255, 0);
        Skill_btn.SetActive(true);
        Player_Game.WoodSkillOpen = false;
    }
}
