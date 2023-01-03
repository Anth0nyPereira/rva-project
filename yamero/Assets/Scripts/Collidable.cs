using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public Collider col;

    public CollidableSO collidableData;

    private bool isVisible;


    public virtual void Awake()
    {
        isVisible = collidableData.IsVisible;
        this.gameObject.SetActive(isVisible);
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        col.enabled = true;
    }
}