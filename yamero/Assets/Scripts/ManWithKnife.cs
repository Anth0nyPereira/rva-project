using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManWithKnife : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;
    private float health;

    private float lighterDamage;

    private Animator animator;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
        animator = GetComponent<Animator>();
    }

    public override void OnCollisionEnter(Collision other)
    {
        dealWithCollision(other);
    }

    private void OnCollisionStay(Collision other)
    {
        dealWithCollision(other);
    }

    public void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Hands should move");
            Debug.Log("Knife should fall dowm");
            Debug.Log("Puzzle completed");
            dealWithNoHealth();
        }
    }

    public void dealWithCollision(Collision other)
    {
        if (other.gameObject.tag == "Lighter")
        {
            Debug.Log("man with a knife");
            lighterDamage = other.gameObject.GetComponent<Lighter>().damage;
            Debug.Log("Take Damage");
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health -= lighterDamage;
    }

    private void dealWithNoHealth()
    {
        moveHands();
        letKnifeFallDown();
    }

    private void moveHands()
    {
        animator.Play("moveHandsAnimation");
    }

    private void letKnifeFallDown()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().useGravity = true;
    }


}
