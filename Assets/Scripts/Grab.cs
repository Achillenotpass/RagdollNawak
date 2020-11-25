using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private GameObject m_GrabbedObject = null;
    [SerializeField]
    private LayerMask m_GrabLayerMask = 0;
    [SerializeField]
    private float m_grabDistance = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TryTograbObject();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            UngrabObject();
        }
    }


    public void TryTograbObject()
    {
        Collider[] l_NearObjects = null;

        l_NearObjects = Physics.OverlapSphere(transform.position, m_grabDistance, m_GrabLayerMask);
        if (l_NearObjects.Length != 0)
        {
            m_GrabbedObject = l_NearObjects[0].gameObject;
            GrabObject();
        }
    }

    public void GrabObject()
    {
        m_GrabbedObject.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
    }

    private void UngrabObject()
    {
        if (m_GrabbedObject != null)
        {
            Destroy(m_GrabbedObject.GetComponent<FixedJoint>());
        }
    }
}
