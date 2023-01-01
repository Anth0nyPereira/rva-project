using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactable
{
    [SerializeField]
    private Vector3Event sendRotationEvent;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
        sendRotationEvent.Raise(this.transform.rotation.eulerAngles);
    }
}
