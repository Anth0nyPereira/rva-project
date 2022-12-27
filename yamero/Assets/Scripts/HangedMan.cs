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

    private bool fallingDown;

    private GameObject knot1;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
        bulletDamage = 0;
        fallingDown = false;
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
            breakHangedManRope();
            Debug.Log("Puzzle completed. HangedMan should later disappear");
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
        Debug.Log("Make hanged man fall down");
        makeFallDown();
    }

    public void makeFallDown()
    {
        fallingDown = true;
        doFallingDownBehaviour();
    }

    public void doFallingDownBehaviour()
    {
        StartCoroutine(makeFallingAnimation(whenCoroutineEnds));

        Debug.Log("Have a break, have a kit kat");
    }

    public float getDistanceBetweenPositions(Vector3 pos1, Vector3 pos2)
    {
        Vector3 directionVector = pos2 - pos1;
        float distance = Mathf.Sqrt(Mathf.Pow(directionVector.x, 2) + Mathf.Pow(directionVector.y, 2) + Mathf.Pow(directionVector.z, 2));
        return distance;
    }

    public IEnumerator makeFallingAnimation(Action whenCEnds)
    {
        Vector3 initialPosition = knot1.transform.position;
        Debug.Log(getDistanceBetweenPositions(initialPosition, knot1.transform.position));
        while (getDistanceBetweenPositions(initialPosition, knot1.transform.position) <= 10)
        {
            knot1.transform.position -= new Vector3(0, 1, 0);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        whenCEnds();
    }

    public void whenCoroutineEnds()
    {
        Debug.Log("finished coroutine");
        stopFallingDown();
    }

    public void stopFallingDown()
    {
        fallingDown = false;
    }

}
