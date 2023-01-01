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
        Debug.Log("on collision stay man with knife");
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("on collision exit");
        lastTime = Time.time;
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
            Debug.Log("man with a knife");
            lighterDamage = other.gameObject.GetComponent<Lighter>().damage;
            Debug.Log("Take Damage");
            TakeDamage();
        }
        else
        {
            Physics.IgnoreCollision(this.col, other.collider);
        }
    }

    private void resetHealth()
    {
        Debug.Log("max health reseted");
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
