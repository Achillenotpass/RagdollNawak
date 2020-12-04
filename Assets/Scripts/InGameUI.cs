using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private Text m_AstroNumber = null;

    private CatchArea m_CatchArea = null;

    private void Start()
    {
        m_CatchArea = FindObjectOfType<CatchArea>();
    }

    private void Update()
    {
        m_AstroNumber.text =" x " + m_CatchArea.AstronautsNumber;
    }
}
