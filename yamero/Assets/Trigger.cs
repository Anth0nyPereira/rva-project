using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Collidable
{

    [SerializeField]
    private TransformEvent rotateTruckEvent;

    private GameObject target;

    public override void Awake()
    {
        base.Awake();
        target = this.gameObject.transform.GetChild(0).gameObject;
    }

    public override void OnCollisionEnter(Collision other)
    {
        Debug.Log("entering collision");
        if (other.gameObject.tag == "Truck")
        {
            Debug.Log("Time to rotate");
            rotateTruckEvent.Raise(target.transform);
            this.col.enabled = false;
        }
    }
}
