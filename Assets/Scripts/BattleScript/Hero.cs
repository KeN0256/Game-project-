using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : Creature
{
    public Text TextStat1;
    public Text TextStat2;
    /// <summary>
    /// 0 - правая рука
    /// 1 - левая рука
    /// 
    /// 2 - голова 
    /// 3 - туловище 
    /// 4 - ноги 
    /// 5 - сапоги 
    /// 6 - амулет 
    /// 7,8 - кольца
    /// 9 - триня, эмблема
    /// 
    /// </summary>
    // Позже нужно сделать их приватными и обращаться только через свойства
    public int BaseStrength;
    public int BaseAgility;
    public int BaseIntelligence;
    public int BonusStrength;
    public int BonusAgility;
    public int BonusIntelligence;
    public Item[] items;
    // Start is called before the first frame update
    void Start()
    {
        StatsUpdate();
        GetComponent<MoveScript>().speed = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StatsUpdate() 
    {
        BonusAgility = 0;
        BonusIntelligence = 0;
        BonusStrength = 0;
        Damage = 0;
        for (int i = 0; i < items.Length; i++) 
        {
            if (items[i] != null)
            {
                Damage += items[i].Damage;
                BonusAgility += items[i].Agility_bonus;
                BonusStrength += items[i].Strength_bonus;
                BonusIntelligence += items[i].Intelligence_bonus;
            }
        }
        TextStat1.text = " Damage: " + Damage.ToString() + "\r\n Health: " + Health.ToString() + "\r\n Speed: " + MoveSpeed.ToString() ;
        UpdateSprite();
    }
    void UpdateSprite() 
    {
        GetComponentInChildren<Weapon>().UpdateWeapon();
    }
}
