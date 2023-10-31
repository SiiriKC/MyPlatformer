using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera PlayerCamera;
    public GameObject BulletPrefab;

    private void Start()
    {
        if (PlayerCamera == null)
        {
            PlayerCamera = Camera.main;
        }
        if (PlayerCamera == null)
        {
            PlayerCamera = FindObjectOfType<Camera>();
        }
    }

    void Update()
    {
        Vector3 mousePosition = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 directionToMouse = mousePosition - transform.position; //Direction = destination - origin.
            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg; //Angle to the mouse.
            Quaternion bulletRotation = Quaternion.Euler(0, 0, angle -90); //

            Instantiate(BulletPrefab, transform.position, bulletRotation);
        }
    }
}
