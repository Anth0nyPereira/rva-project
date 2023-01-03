using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Guillotine : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;
    private float health;

    private float bulletDamage;

    private GameObject blade;

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
    }

    private void Update()
    {
        if (health == 0)
        {
            breakRope();
            health = maxHealth.Value;
        }
    }

    public void turnOff()
    {
        this.gameObject.SetActive(false);
    }

    private void TakeDamage()
    {
        health -= bulletDamage;
    }

    private void disableCollider()
    {
        this.col.enabled = false;
    }

    private GameObject getBlade()
    {
        return this.transform.GetChild(0).gameObject;
    }
    private void breakRope()
    {
        disableCollider();
        blade = this.getBlade();
        makeFallDown();
    }

    private void makeFallDown()
    {
        blade.GetComponent<Rigidbody>().useGravity = true;
    }
}
