using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : Collidable
{
    [SerializeField]
    private VoidEvent disableTruckMovementEvent;

    public override void Awake()
    {
        base.Awake();

    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.gameObject.tag == "Truck")
        {
            disableTruckMovementEvent.Raise();
        }
    }
}
