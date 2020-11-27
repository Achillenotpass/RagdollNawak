using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurCamera : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    bool m_UseOffset;
    [SerializeField]
    Vector3 m_Offset = new Vector3(0, -5, 10);
    [SerializeField]
    float m_RotateSpeed = 1;

    Transform m_player;

    void Start()
    {
        m_player = FindObjectOfType<ArthurMovement>().transform;

        if (!m_UseOffset)
        {
            m_Offset = m_player.position - transform.position;
        }

        // Camoufler la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Permet de rotate le player sur l'horizontale
        float horizontal = Input.GetAxis("Mouse X") * m_RotateSpeed;
        m_player.Rotate(0, horizontal, 0);

        // Pareil pour la vertical
        float vertical = Input.GetAxis("Mouse Y") * m_RotateSpeed;
        m_player.Rotate(-vertical, 0, 0);

        float desiredYAngle = m_player.eulerAngles.y;
        float desiredXAngle = m_player.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = m_player.position - (rotation * m_Offset);

        transform.LookAt(m_player);

        // m_player.transform.forward = transform.forward;
    }
}
