using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Interactable
{
    [SerializeField]
    private FloatSO lighterDamage;

    public float damage;

    public override void Awake()
    {
        base.Awake();
        damage = lighterDamage.Value;
    }

    public override void Update()
    {
        base.Update();
    }
}
