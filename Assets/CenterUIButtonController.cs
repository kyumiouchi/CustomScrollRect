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
    ScrollRect m_ActiveContentPanel;

    [SerializeField]
    ScrollRect m_InactiveContentPanel;

    [SerializeField]
    RectTransform m_FirstInactiveDummy;

    RectTransform m_FirstActiveItem;

    Coroutine m_CenterRoutine;

    bool m_AllowMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    [Range(0,1)]
    public float test;
    // Update is called once per frame
    void Update()
    {
        //m_InactiveContentPanel.horizontalNormalizedPosition = test;
        m_InactiveContentPanel.horizontalNormalizedPosition = m_ActiveContentPanel.horizontalNormalizedPosition;
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

    public void OnDragStarted(BaseEventData evt)
    {
        StopCoroutine(m_CenterRoutine);
    }

    public void OnDragging(BaseEventData evt)
    {

    }

    public void OnDragEnded(BaseEventData evt)
    {
        m_CenterRoutine = StartCoroutine(CenterItem());
    }

    IEnumerator CenterItem()
    {
        yield return null;
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
    }*/
}
