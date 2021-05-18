using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacks : MonoBehaviour
{
    public Hero Hero;
    public GameObject bullet;

    public void BowShot() 
    {
        float damage = Hero.Damage;
        var direction = Input.mousePosition - UnityEngine.Camera.main.WorldToScreenPoint(transform.position); // Нахождение катетов для расчёта тангенса, а в последствии и количества градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Вращение объекта на полученное количество градусов

        GameObject projectile = Instantiate(bullet, transform.position, rotation);
        projectile.GetComponent<SpriteRenderer>().sprite = Hero.items[0].projectile;
        Bullet bs = projectile.GetComponent<Bullet>();// создаем проджектаел который знает какой урон/тип урона/кто наносит урон
        bs.dmg = damage;// !!!! тут нужо сделать обращение к урону оружия и к типу урона оружия
        bs.Sender = Hero;//Кто отправляет урон
        bs.DamageType = 2;// допустим физический урон
    }
    public void MeleeAttack() 
    {

    }
}
