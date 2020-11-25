using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchilleMovements : MonoBehaviour
{
    [SerializeField]
    private float m_RotationForce = 5.0f;
    [SerializeField]
    private float m_PropulsionForce = 5.0f;
    private Rigidbody m_SpineRigidBody = null;


    //Awake is called before anything else
    private void Awake()
    {
        m_SpineRigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            m_SpineRigidBody.AddRelativeTorque(new Vector3(1.0f, 0.0f, 0.0f) * m_RotationForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_SpineRigidBody.AddRelativeTorque(new Vector3(-1.0f, 0.0f, 0.0f) * m_RotationForce);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            m_SpineRigidBody.AddRelativeTorque(new Vector3(0.0f, -1.0f, 0.0f) * m_RotationForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_SpineRigidBody.AddRelativeTorque(new Vector3(0.0f, 1.0f, 0.0f) * m_RotationForce);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            m_SpineRigidBody.AddRelativeForce(new Vector3(0.0f, 0.0f, 1.0f) * m_PropulsionForce);
        }
    }
}
