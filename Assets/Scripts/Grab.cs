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
    [SerializeField]
    private float m_grabForce = 15.0f;
    [SerializeField]
    private KeyCode m_GrabKey = KeyCode.M;
    private Rigidbody m_HandRigidbody = null;


    //Awake is called before anything else, once
    private void Awake()
    {
        m_HandRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveHand();
        }

        if (Input.GetMouseButtonUp(0))
        {
            UngrabObject();
        }
    }


    public void MoveHand()
    {
        m_HandRigidbody.AddRelativeForce(Vector3.forward * m_grabForce, ForceMode.Impulse);
        Invoke(nameof(TryTograbObject), 0.5f);
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
