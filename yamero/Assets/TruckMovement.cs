using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    [SerializeField]
    private VoidEvent enableTriggerEvent;

    private Vector3 direction;
    private Collider col;
    private Vector3 actualRotation;
    private float rotationY;
    private bool mustRotate;
    private Transform targetTransform;
    private bool coroutineFinished;

    private void Awake()
    {
        direction = new Vector3(0, 0, 1);
        col = GetComponent<Collider>();
        actualRotation = TransformUtils.GetInspectorRotation(this.transform);
        rotationY = actualRotation.y;
        // Debug.Log(rotationY);
        mustRotate = false;
        coroutineFinished = true;

    }

    
    private void FixedUpdate()
    {
        
        if (mustRotate)
        {
            doRotation();
        }

        if (coroutineFinished)
        {
            mustRotate = false;
            col.transform.Translate(2 * direction * Time.fixedDeltaTime, Space.Self);
        }
    }

    public void letTruckRotate(Transform transform)
    {
        mustRotate = true;
        coroutineFinished = false;
        targetTransform = transform;
    }

    public void doRotation()
    {
        StartCoroutine(rotateTruck(whenCoroutineEnds));


        Debug.Log("hi");
    }

    public IEnumerator rotateTruck(Action whenCEnds)
    {
        Vector3 oldR = TransformUtils.GetInspectorRotation(this.transform);
        Debug.Log("do coroutine now");
        Debug.Log(Mathf.Abs(oldR.y - TransformUtils.GetInspectorRotation(this.transform).y));
        while (Mathf.Abs(oldR.y - TransformUtils.GetInspectorRotation(this.transform).y) <= 45)
        {
            transform.RotateAround(transform.position, transform.up, -Time.fixedDeltaTime);
            transform.RotateAround(targetTransform.position, transform.up, -Time.fixedDeltaTime);
            Debug.Log("inside while loop");
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        whenCEnds();
    }

    public void whenCoroutineEnds()
    {
        Debug.Log("finished coroutine");
        coroutineFinished = true;
        enableTriggerEvent.Raise();
    }
}
