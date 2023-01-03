using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HangedMan : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;
    private float health;

    private float bulletDamage;

    private GameObject knot1;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
        bulletDamage = 0;
    }

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            bulletDamage = other.gameObject.GetComponent<Bullet>().bulletDamage.Value;
            TakeDamage();
        }
        else
        {
            Physics.IgnoreCollision(this.col, other.collider);
        }
    }

    private void Update()
    {
        if (health == 0)
        {
            breakHangedManRope();
            health = maxHealth.Value;
        }
    }

    private void TakeDamage()
    {
        health-= bulletDamage;
    }

    private void disableCollider()
    {
        this.col.enabled = false;
    }

    private GameObject getKnot()
    {
        return this.transform.GetChild(0).GetChild(0).gameObject;
    }
    private void breakHangedManRope()
    {
        disableCollider();
        knot1 = this.getKnot();
        makeFallDown();
    }

    public void makeFallDown()
    {
        knot1.GetComponent<Rigidbody>().useGravity = true;
    }
}
