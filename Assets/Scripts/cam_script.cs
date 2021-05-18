using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_script : MonoBehaviour
{
    public GameObject Player;
    public UnityEngine.UI.Text text;
    public float speed = 200f;
    public bool inventory = false;
    // Start is called before the irst frame update
    void Start()
    {
        var pos_x = Player.transform.position.x;
        var pos_y = Player.transform.position.y;
        transform.position = new Vector3(pos_x, pos_y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            if (inventory)
            {
                inventory = false;
            }
            else
            {
                inventory = true;
            }
        }
        if (!inventory)
        {
            var mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            transform.position = new Vector3(Player.transform.position.x + (mousePosition.x / 200), Player.transform.position.y + (mousePosition.y / 200), -10);
        }
        else 
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        }
    }
}
