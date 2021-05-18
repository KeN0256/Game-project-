using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public float dmg;
    public int DamageType;
    public Creature Sender;
    float time = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Creature creature = collision.GetComponent<Creature>();
        if (creature != null) 
        {
            Atack atack = new Atack(Sender, creature, DamageType, dmg);
            creature.TakeDamage(atack);
        }
        Destroy(gameObject);
    }
}
