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

    private GameObject waterfall;
    private Material bathLiquid;

    public override void Awake()
    {
        base.Awake();
        health = maxHealth.Value;
        waterfall = this.transform.GetChild(0).gameObject;
        waterfall.SetActive(false);

        bathLiquid = this.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Renderer>().material;
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
            handlePuzzle();
            health = maxHealth.Value;
        }
    }

    private void TakeDamage()
    {
        health -= knifeDamage;
    }

    private void turnOnWaterfall()
    {
        waterfall.SetActive(true);
    }

    private void reduceLevelOfWater()
    {
        float fill = bathLiquid.GetFloat("_Fill");
        float incr = 0.1f;
        while (fill >= -5.0f)
        {
            fill -= incr;
            bathLiquid.SetFloat("_Fill", fill);

        }
    }

    private void handlePuzzle()
    {
        this.turnOnWaterfall();
        this.reduceLevelOfWater();

    }
}
