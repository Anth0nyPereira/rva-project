using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class TruckMovement : MonoBehaviour
{
    [SerializeField]
    private VoidEvent enableTriggerEvent;

    private Vector3 direction;
    private Collider col;
    private Vector3 rotation;
    private float rotationY;
    private bool mustRotate;
    private Transform targetTransform;
    private bool coroutineFinished;
    private float counter;
    private int trigger;
    private int[] arr;
    private string triggerName;
    private bool moveX;
    private float[] pos;


    private void Awake()
    {
        direction = new Vector3(0, 0, 1);
        col = GetComponent<Collider>();
        rotation = transform.rotation.eulerAngles;
        rotationY = rotation.y;
        // Debug.Log(rotationY);
        mustRotate = false;
        coroutineFinished = true;
        counter = 0;
        trigger = 1;
        arr = new int[] { 0, 90, 270, 180 };
        pos = new float[] { 10.3f, -17.7f, 18, -10.3f };
        // pos = new int[] {}
        triggerName = "trigger2";

    }

    
    private void FixedUpdate()
    {

        col.transform.Translate(2 * direction * Time.fixedDeltaTime, Space.Self);
        // lockMovement();
        
        if (mustRotate)
        {
            rotation = transform.rotation.eulerAngles;
            rotationY = rotation.y;
            doRotation();
            mustRotate = false;
        }

        if (coroutineFinished)
        {

            mustRotate = false;
        }
    }

    public void letTruckRotate(Transform transform)
    {
        mustRotate = true;
        coroutineFinished = false;
        targetTransform = transform;
    }

    public void getTriggerName(String triggerName)
    {
        this.triggerName = triggerName;
    }

    private int getTrigger()
    {
        trigger = int.Parse(triggerName.Substring(triggerName.Length - 1));
        trigger -= 1;
        return trigger;
    }

    public void doRotation()
    {
        StartCoroutine(rotateTruck(whenCoroutineEnds));
        Debug.Log("hi");
    }

    public IEnumerator rotateTruck(Action whenCEnds)
    {
        while (counter >= -45)
        {
            transform.RotateAround(transform.position, transform.up, -25*Time.fixedDeltaTime);
            transform.RotateAround(targetTransform.position, transform.up, -25*Time.fixedDeltaTime);
            counter += -25*Time.fixedDeltaTime;
            Debug.Log("inside while loop");
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        whenCEnds();
    }

    public void whenCoroutineEnds()
    {
        StopCoroutine("rotateTruck");
        Debug.Log("finished coroutine");
        counter = 0;
        rotateRemaining();
        coroutineFinished = true;
        enableTriggerEvent.Raise();
    }

    private void rotateRemaining()
    {
        transform.rotation = Quaternion.Euler(0, arr[getTrigger()], 0);
    }

    private void lockMovement()
    {
        if (getTrigger() % 2 == 0)
        {
            transform.position = new Vector3(pos[getTrigger()], transform.position.y, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pos[getTrigger()]);
        }
        
    }
}
