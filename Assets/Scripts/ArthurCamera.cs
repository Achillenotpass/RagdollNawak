using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurCamera : MonoBehaviour
{
    Transform player;

    public Vector3 offset = new Vector3(0, -5, 10);

    public bool useOffset;

    public float rotateSpeed = 1;

    void Start()
    {
        player = FindObjectOfType<ArthurMovement>().transform;

        if (!useOffset)
        {
            offset = player.position - transform.position;
        }

        // Camoufler la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        player.Rotate(-vertical, 0, 0);

        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = player.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.position - (rotation * offset);

        transform.LookAt(player);
    }
}
