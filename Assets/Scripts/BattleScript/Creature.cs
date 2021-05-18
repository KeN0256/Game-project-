using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    
    public float Health;
    public float AbsoluteResist;// абсолютная защита от любого урона
    public float Resist;// В процентах
    public float Armor;// Тоже в процентах
    public float Damage;//
    public float MoveSpeed;//
    //Методы со временем нужно расширить чтобы получать больше сведений от того кто наносит урон и урон какого типа.
    public void TakeDamage(Atack atack) // Определяям какой урон
    {
        if (atack.type == 1)
        {
            TakePureDamage(atack);
        }
        else 
        {
            if (atack.type == 2) 
            {
                TakePhysicalDamage(atack);
            }
            else 
            {
                TakeMagicDamage(atack);
            }
        }
    }
    void TakeMagicDamage(Atack atack) // магический урон
    {
        Health -= atack.Damage * ((100-Resist)/100);
        if (Health <= 0)
        {
            Death();
        }
    }
    void TakePhysicalDamage(Atack atack) // Физический урон 
    {
        Health -= atack.Damage * ((100 - Armor) / 100);
        if (Health <= 0)
        {
            
            Death();
        }
    }
    void TakePureDamage(Atack atack) // Чистый урон урон 
    {
        Health -= atack.Damage * ((100 - Armor) / 100);
        if (Health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }

}
