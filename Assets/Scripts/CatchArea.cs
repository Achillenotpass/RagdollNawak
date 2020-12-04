using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchArea : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_Astronauts = new List<GameObject>();

    [SerializeField]
    GameObject m_MenuToShow = null;

    private bool m_IsGameEnding = false;

    int m_AstronautsNumber = 0;

    private void Start()
    {
        m_AstronautsNumber = m_Astronauts.Count;
    }

    private void Update()
    {
        m_AstronautsNumber = m_Astronauts.Count;

        if (m_Astronauts.Count == 0)
        {
            m_IsGameEnding = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            m_MenuToShow.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        foreach (GameObject astronaut in m_Astronauts)
        {
            if (collidedObject == astronaut)
            {
                m_Astronauts.Remove(astronaut);
                Destroy(collidedObject.transform.parent.parent.parent.gameObject);

                break;
            }
        }
    }

    public bool IsGameEnding
    {
        get
        {
            return m_IsGameEnding;
        }
    }

    public int AstronautsNumber
    {
        get
        {
            return m_AstronautsNumber;
        }
    }
}
