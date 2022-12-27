using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Collidable
{
    private Vector3 initPos;

    public override void Awake()
    {
        base.Awake();
        initPos = transform.position;
    }

    public void Update()
    {
        if (this.transform.position.y <= -10)
        {
            restartGunPosition();
        }
    }

    public void disableCollider()
    {
        this.col.enabled = false;
    }

    public void enableCollider()
    {
        this.col.enabled = true;
    }

    private void resetDefaultPosition()
    {
        transform.position = initPos;
    }

    private void restartGunPosition()
    {
        this.enableCollider();
        this.resetDefaultPosition();
    }


}
