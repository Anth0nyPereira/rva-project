using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManWithKnife : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;
    private float health;

    private float lighterDamage;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
    }

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lighter")
        {
            Debug.Log("man with a knife");
            lighterDamage = other.gameObject.GetComponent<Lighter>().damage;
            Debug.Log("Take Damage");
            TakeDamage();
        }
    }

    public void Update()
    {
        if (health == 0)
        {
            Debug.Log("Hands should move");
            Debug.Log("Knife should fall dowm");
            Debug.Log("Puzzle completed");
        }
    }

    private void TakeDamage()
    {
        health -= lighterDamage;
    }
}
