using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTorque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(-100.0f, 0.0f, 0.0f));
        }
    }
}
