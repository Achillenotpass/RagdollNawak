using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private Text m_AstroNumber;

    private CatchArea m_CatchArea;

    private void Start()
    {
        m_CatchArea = FindObjectOfType<CatchArea>();
    }

    private void Update()
    {
        m_AstroNumber.text =" x " +m_CatchArea.astronautsNumber;
    }
}
