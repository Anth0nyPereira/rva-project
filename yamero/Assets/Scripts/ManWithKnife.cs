using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManWithKnife : Collidable
{
    [SerializeField]
    private FloatSO maxHealth;

    [SerializeField]
    private VoidEvent makeGuillotineDisappearEvent;

    private float health;

    private float lighterDamage;

    private Animator animator;

    private float lastTime;



    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
        animator = GetComponent<Animator>();
        lastTime = 0;
    }

    public override void OnCollisionEnter(Collision other)
    {
        dealWithCollision(other);
    }

    private void OnCollisionStay(Collision other)
    {
        dealWithCollision(other);
    }

    private void OnCollisionExit(Collision other)
    {
        lastTime = Time.time;
    }

    public void Update()
    {
        if (health <= 0)
        {
            dealWithNoHealth();
        }

        
        if (lastTime != 0 && Mathf.Abs(Time.time - lastTime) >= 5.0f)
        {
            Debug.Log(Mathf.Abs(Time.time - lastTime));
            resetHealth();
            lastTime = 0;
        }

    }

    private void dealWithCollision(Collision other)
    {
        if (other.gameObject.tag == "Lighter")
        {
            lighterDamage = other.gameObject.GetComponent<Lighter>().damage;
            TakeDamage();
        }
        else
        {
            Physics.IgnoreCollision(this.col, other.collider);
        }
    }

    private void resetHealth()
    {
        health = maxHealth.Value;
    }

    private void TakeDamage()
    {
        health -= lighterDamage;
    }

    private void dealWithNoHealth()
    {
        moveHands();
        letKnifeFallDown();
        makeGuillotineDisappear();
    }

    private void moveHands()
    {
        animator.Play("moveHandsAnimation");
    }

    private void letKnifeFallDown()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.col.enabled = false;
        this.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    private void makeGuillotineDisappear()
    {
        makeGuillotineDisappearEvent.Raise();
    }
}
