using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private Vector3 direction;
    private Collider col;
    private Vector3 actualRotation;
    private float rotationY;

    private void Awake()
    {
        direction = new Vector3(0, 0, 1);
        col = GetComponent<Collider>();
        actualRotation = TransformUtils.GetInspectorRotation(this.transform);
        rotationY = actualRotation.y;
        Debug.Log(rotationY);

    }

    
    private void FixedUpdate()
    {
        col.transform.Translate(direction * Time.fixedDeltaTime, Space.Self);
    }
}
