using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Collidable
{
    private Animator animator;
    private bool animateTruck;


    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        animateTruck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (animateTruck)
        {
            Debug.Log("truck is being animated!!");
        }
    }
}
