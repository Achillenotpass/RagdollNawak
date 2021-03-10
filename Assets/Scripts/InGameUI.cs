using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private Text m_AstroNumber = null;

    private CatchArea m_CatchArea = null;

    [SerializeField]
    Image m_TutoMenu;

    [SerializeField]
    Text m_TutoText;

    private void Start()
    {
        m_CatchArea = FindObjectOfType<CatchArea>();

        Invoke(nameof(FadeUI), 10);
    }

    private void Update()
    {
        m_AstroNumber.text =" x " + m_CatchArea.AstronautsNumber;
    }

    void FadeUI()
    {
        m_TutoMenu.CrossFadeAlpha(0, 1, false);
        m_TutoText.CrossFadeAlpha(0, 1, false);
    }
}
