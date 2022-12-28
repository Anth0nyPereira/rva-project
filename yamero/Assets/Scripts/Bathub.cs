using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
        if (health == 0) {
            Debug.Log("Waterfall should appear");
            Debug.Log("Water level should decrease");
            Debug.Log("Puzzle completed. Bathub should later disappear");
            handlePuzzle();
        }
    }

    private void TakeDamage()
    {
        health -= knifeDamage;
    }

    private void handlePuzzle()
    {
        this.turnOnWaterfall();
        this.doReduceLevelOfWater();

    }

    private void turnOnWaterfall()
    {
        waterfall.SetActive(true);
    }

    private void turnOffWaterfall()
    {
        waterfall.SetActive(false);
    }

    private void doReduceLevelOfWater()
    {
        StartCoroutine(reduceLevelOfWater(whenCoroutineEnds));
    }

    private IEnumerator reduceLevelOfWater(Action whenCoroutineWillEnd)
    {
        float fill = bathLiquid.GetFloat("_Fill");
        float incr = 0.001f;
        while (fill >= -0.8f)
        {
            fill -= incr;
            bathLiquid.SetFloat("_Fill", fill);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        whenCoroutineWillEnd();
    }

    public void whenCoroutineEnds()
    {
        this.turnOffWaterfall();
        health = maxHealth.Value;
    }

}
