using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CenterUIButtonController : MonoBehaviour
{
    private Animator m_PreviousButton;

    Collider2D m_LastObject;

    [SerializeField]
    ScrollRect m_ActiveScrollRectPanel;

    [SerializeField]
    ScrollRect m_InactiveScrollRectPanel;

    [SerializeField]
    RectTransform m_InactiveContent;

    [SerializeField]
    RectTransform m_ActiveContent;

    [SerializeField]
    RectTransform m_FirstInactiveDummy;

    [SerializeField]
    RectTransform m_FirstActiveItem;

    Coroutine m_CenterRoutine;

    bool m_AllowMovement;

    float m_PanelSizeRatio;

    float m_PageStep;

    int m_ActivePanelIndex = 0;

    private void Start()
    {
        m_PanelSizeRatio = 1321.4f / 361.4f;
        m_PageStep = 1 / m_PanelSizeRatio;
    }

    // Update is called once per frame
    void Update()
    {
        //m_InactiveContentPanel.horizontalNormalizedPosition = test;
        m_InactiveScrollRectPanel.horizontalNormalizedPosition = (m_ActivePanelIndex * m_PageStep) + (m_PageStep * m_ActiveScrollRectPanel.horizontalNormalizedPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(m_LastObject != null)
        {
            Debug.Log("Exit " + other.name);
            Animator lastButtonAnim = m_LastObject.GetComponent<Animator>();
            lastButtonAnim.SetBool("IsSelected", false);
        }
        Debug.Log("Enter " + other.name);
        Animator buttonAnim = other.GetComponent<Animator>();
        buttonAnim.SetBool("IsSelected", true);
        m_LastObject = other;
    }

    IEnumerator CenterItem()
    {
        yield return null;
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
    }*/
}
