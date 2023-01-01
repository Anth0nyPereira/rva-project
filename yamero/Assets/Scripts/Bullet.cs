using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable
{
 
    public FloatSO bulletDamage;

    public override void Awake()
    {
        base.Awake();
        Destroy(gameObject, 5.0f);
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.gameObject.tag == "Gun" || other.gameObject.tag == "Truck")
        {
            ;
        } else
        {
            Destroy(gameObject);
        }
        
    }
}
