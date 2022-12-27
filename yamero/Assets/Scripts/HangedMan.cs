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

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
        bulletDamage = 0;
    }

    public override void OnCollisionEnter(Collision other)
    {
        Debug.Log("hanged man is colliding");
        if (other.gameObject.tag == "Bullet")
        {
            bulletDamage = other.gameObject.GetComponent<Bullet>().bulletDamage.Value;
            Debug.Log("Take Damage");
            TakeDamage();
        }
    }

    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("Rope must break");
            Debug.Log("Puzzle completed. HangedMan should later disappear");
            health = maxHealth.Value;
        }
    }

    private void TakeDamage()
    {
        health-= bulletDamage;
    }


}
