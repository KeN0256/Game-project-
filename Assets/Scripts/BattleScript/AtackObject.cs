using System.Collections;
using System.Collections.Generic;

public class Atack
{
    public Creature Sender;
    public Creature Resipient;
    public int type; //1 - pure/2 - physical/3 - magic
    public float Damage { get; set; }//урон который наносит атака
    public Atack(Creature Sender, Creature Resipient, int type, float damage) 
    {
        this.Sender = Sender;
        this.Resipient = Resipient;
        this.type = type;
        this.Damage = damage;
    }   
}
