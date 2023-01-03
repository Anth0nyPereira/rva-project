using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BulletManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform spawningPoint;

    [SerializeField]
    private float speed = 20;

    private Vector3 actualRot;

    private void Awake()
    {
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(FireBullet);
    }

    public void getActualRot(Vector3 rotation)
    {
        actualRot = rotation;
    }

    private void FireBullet(ActivateEventArgs args)
    {
        GameObject spawned = Instantiate(bullet);
        spawned.transform.position = spawningPoint.transform.position;
        spawned.transform.eulerAngles = actualRot + new Vector3(0, 90, 0);
        spawned.GetComponent<Rigidbody>().velocity = spawningPoint.right * speed;
    }
}
