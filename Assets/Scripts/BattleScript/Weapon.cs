using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //DataBase data { get; }
    public Hero Father;
    public GameObject bullet;
    public bool enable = true;
    public GameObject Left_Hand;
    public GameObject Right_Hand;
    // Start is called before the first frame update
    /*void Start()
    {
        //DataBase data = new DataBase();
    } */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && enable)
        {
            MainAtack();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (enable)
            {
                enable = false;
            }
            else 
            {
                enable = true;
            }
        }
    }
    void MainAtack() //тут создаем прожектайлы, надо реализовать по или делегатом или интерфейсом
    {
        if(Father.items[0] != null) 
        {
           Father.items[0].Main();
        }
        if (Father.items[1] != null) 
        {
            Father.items[1].Main();
        }
    }
    public void UpdateWeapon() 
    {
        if (Father.items[0] != null)
        {
            if (Father.items[0].Type == 10)
            {
                GetComponent<SpriteRenderer>().sprite = Father.items[0].Sprite;
                Left_Hand.GetComponent<SpriteRenderer>().sprite = null;
                Right_Hand.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = null;
                Right_Hand.GetComponent<SpriteRenderer>().sprite = Father.items[0].Sprite;
            }
        }
        else 
        {
            Right_Hand.GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<SpriteRenderer>().sprite = null;
        }
        if (Father.items[1] != null)
        {
            Left_Hand.GetComponent<SpriteRenderer>().sprite = Father.items[1].Sprite;
        }
        else 
        {
            Left_Hand.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
