using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bathub : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;
    private float health;
    private float knifeDamage;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
    }

    public override void OnCollisionEnter(Collision other)
    {

        base.OnCollisionEnter(other);
        if (other.gameObject.tag == "Knife")
        {
            Debug.Log("Take Damage");
            knifeDamage = other.gameObject.GetComponent<Knife>().damage;
            TakeDamage();
            Debug.Log("Update Bathub Surface  Cracks");
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision stay bath");
    }

    private void Update()
    {
        if (health <= 0) {
            Debug.Log("Waterfall should appear");
            Debug.Log("Water level should decrease");
            Debug.Log("Puzzle completed. Bathub should later disappear");
        }
    }

    private void TakeDamage()
    {
        health -= knifeDamage;
    }
}
