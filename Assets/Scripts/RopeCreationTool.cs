using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCreationTool : MonoBehaviour
{
    [SerializeField]
    private GameObject m_RopePart = null;
    [SerializeField]
    private int m_NumberOfSegments = 5;

    

    [ContextMenu("CreateRope")]
    public void CreateRope()
    {
        GameObject l_LastCreatedRopePart = null;
        GameObject l_CurrentRopePart = null;

        //On créer autant de bout de corde que demandé
        for (int i = 0; i < m_NumberOfSegments; i++)
        {
            //Ici on créer un bout de corde, et on s'en souvient en tant que "bout de corde actuelle"
            l_CurrentRopePart = Instantiate(m_RopePart, new Vector3(m_RopePart.transform.localScale.x * i, 0.0f, 0.0f), Quaternion.identity);
            //On lui ajoute un rigidbody
            l_CurrentRopePart.AddComponent<Rigidbody>();

            //S'il ne s'agit pas du dernier bout de corde
            if (i != m_NumberOfSegments - 1)
            {
                //On lui ajoute un character joint
                l_CurrentRopePart.AddComponent<CharacterJoint>();
            }

            //Si nous avons déjà créé un bout de corde avant celui-là
            if (i != 0)
            {
                //Alors on relie ce bout de corde au précédent dans le character joint
                l_LastCreatedRopePart.GetComponent<CharacterJoint>().connectedBody = l_CurrentRopePart.GetComponent<Rigidbody>();
            }

            //Avant de passer à la corde suivant, on retient la corde actuelle comme la core précédente
            l_LastCreatedRopePart = l_CurrentRopePart;
        }
    }
}
