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

    private void Awake()
    {
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(FireBullet);
    }

    private void FireBullet(ActivateEventArgs args)
    {
        Debug.Log("fire bullet!!");
        GameObject spawned = Instantiate(bullet);
        spawned.transform.position = spawningPoint.transform.position;
        spawned.GetComponent<Rigidbody>().velocity = spawningPoint.right * speed;
    }
}
