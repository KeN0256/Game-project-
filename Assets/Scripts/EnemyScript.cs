using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Wilk : MonoBehaviour
{
    public float Ray_Length;
    RaycastHit2D[] Maslo;
    public int Start_degrees = 45;
    public int Raycount=21;
    public int Step=5;
    public Rigidbody2D rb;
    public int Speed = 1;
    float time = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;
    }

    
    void Update()
    {
        Detect();
        Move();

    }
    void Detect()
    {
        int degrees = Start_degrees;
        for (int i = 0; i < Raycount; i++)
        {
            Maslo = Physics2D.RaycastAll(transform.position, Quaternion.AngleAxis(degrees, Vector3.forward) * (transform.right * Ray_Length));
            for (int j = 1; j < Maslo.Length; j++)
            {


                Debug.Log("Я Попав " + i + " " + Maslo[j].collider.gameObject.name);

            }
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(degrees, Vector3.forward) * (transform.right * Ray_Length), Color.green);
            degrees += Step;
        }
    }
    void Move()
    {

        time += Time.deltaTime;
        if (time >= 5)
        {
            System.Random rnd = new System.Random();
            transform.rotation = Quaternion.Euler (0, 0, rnd.Next(1, 360));
            time = 0;
            rb.velocity = transform.up * Speed;
        }
    }

    
}
