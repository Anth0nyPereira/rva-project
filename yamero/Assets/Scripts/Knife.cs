using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Interactable
{
    [SerializeField]
    private FloatSO knifeDamage;

    private float damage;
   
    public override void Awake()
    {
        base.Awake();
        damage = knifeDamage.Value; 
    }

    public override void Update()
    {
        base.Update();
    }
}
