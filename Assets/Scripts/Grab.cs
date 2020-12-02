using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private GameObject m_GrabbedObject = null;
    [SerializeField]
    private LayerMask m_GrabLayerMask = 0;
    [SerializeField]
    private float m_GrabDistance = 0.5f;
    [SerializeField]
    private float m_GrabForce = 15.0f;
    private Rigidbody m_HandRigidbody = null;
    [SerializeField]
    private Transform m_HandTransform = null;


    //Awake is called before anything else, once
    private void Awake()
    {
        m_HandRigidbody = m_HandTransform.gameObject.GetComponent<Rigidbody>();
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
        m_HandRigidbody.AddRelativeForce(Vector3.forward * m_GrabForce, ForceMode.Impulse);
        Invoke(nameof(TryTograbObject), 0.5f);
    }

    public void TryTograbObject()
    {
        Collider[] l_NearObjects = null;

        l_NearObjects = Physics.OverlapSphere(m_HandTransform.position, m_GrabDistance, m_GrabLayerMask);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(m_HandTransform.position, m_GrabDistance);
    }

}
