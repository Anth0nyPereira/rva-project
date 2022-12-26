using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HangedMan : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;
    private float health;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Take Damage");
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Rope must break");
            Debug.Log("Puzzle completed. HangedMan should later disappear");
        }
    }
}
