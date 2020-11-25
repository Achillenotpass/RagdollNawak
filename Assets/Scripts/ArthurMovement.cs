using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    Rigidbody rbPlayer;

    Vector3 moveDirection;


    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed) + (transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed);

        moveDirection = moveDirection.normalized * moveSpeed;

        rbPlayer.velocity = moveDirection * Time.deltaTime;
    }
}
