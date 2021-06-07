using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScrollSnappingBehavior : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private Image[] _bttn;
    [SerializeField] private RectTransform _center;
    [SerializeField] private int startButton = 1;

    private float[] distance;
    // [SerializeField] private float[] distReposition;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;
    private int bttnLength;
    // private bool messageSend = false;
    private float lerpSpeed = 5f;
    // private bool targetNearstButton = true;

     void Start()
    {
        bttnLength = _bttn.Length;
        distance = new float[bttnLength];
        // distReposition = new float[bttnLength];

        bttnDistance = (int) Mathf.Abs(_bttn[1].GetComponent<RectTransform>().anchoredPosition.x -
                                       _bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
        panel.anchoredPosition = new Vector2(-((startButton - 1) * bttnDistance), 0f);
        
        Debug.Log("bttnDistance " + (startButton - 1) * bttnDistance);
    }

     void Update()
     {
         for (int i = 0; i < bttnLength; i++)
         {
             distance[i] = Mathf.Abs(_center.transform.position.x - _bttn[i].transform.position.x);
             
             
             //         distReposition[i] = _center.GetComponent<RectTransform>().position.x -
             //                             _bttn[i].GetComponent<RectTransform>().position.x;
             //         distance[i] = Mathf.Abs(distReposition[i]);
             //
             //         if (distReposition[i] > 1200)
             //         {
             //             float curX = _bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
             //             float curY = _bttn[i].GetComponent<RectTransform>().anchoredPosition.y;
             //             
             //             Vector2 newAchorPos = new Vector2(curX + (bttnLength * bttnDistance), curY);
             //             _bttn[i].GetComponent<RectTransform>().anchoredPosition = newAchorPos;
             //         }
             //         
             //         if (distReposition[i] < -1200)
             //         {
             //             float curX = _bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
             //             float curY = _bttn[i].GetComponent<RectTransform>().anchoredPosition.y;
             //             
             //             Vector2 newAchorPos = new Vector2(curX - (bttnLength * bttnDistance), curY);
             //             _bttn[i].GetComponent<RectTransform>().anchoredPosition = newAchorPos;
             //         }
         }

         float minDIstance = Mathf.Min(distance);
         // Debug.Log($"minDIstance ===== {minDIstance}");


         for (int a = 0; a < bttnLength; a++)
         {
             if (minDIstance == distance[a])
                 
             {
                 minButtonNum = a;
             }
         }

         if (!dragging)
         {
             LerpToBttn(minButtonNum * -bttnDistance);
             // LerpToBttn(-_bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
         }

     //     }
     //
     //     if(targetNearstButton)
     //     {
     //         float minDIstance = Mathf.Min(distance);
     //         for (int a = 0; a < _bttn.Length; a++)
     //         {
     //             if (minDIstance == distance[a])
     //             {
     //                 minButtonNum = a;
     //             }
     //         }
     //     }
     //
     //     if (!dragging)
     //     {
     //         LerpToBttn(-_bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
    }
     //
     void LerpToBttn(float position)
     {
         float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * lerpSpeed);
     
         // if (Mathf.Abs(position - newX) < 3f)
         // {
         //     newX = position;
         // }
         //
         // if (Mathf.Abs(newX) >= Mathf.Abs(position) - 1f && Mathf.Abs(newX) <= Mathf.Abs(position) + 1 && !messageSend)
         // {
         //     messageSend = true;
         //     SendMessageFromButton(minButtonNum);
         // }
         //
         // Debug.Log("LerpToBttn " + newX);
         Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
         panel.anchoredPosition = newPosition;
     }
     //
     // void SendMessageFromButton(int bttnIndex)
     // {
     //     if(bttnIndex == 3)
     //         Debug.Log("Message Send: ");
     //         
     // }
     //
     //
     public void StartDrag()
     {
         // messageSend = false;
         // lerpSpeed = 5f;
         dragging = true;
     
         // targetNearstButton = true;
     }
     
     public void EndDrag()
     {
         dragging = false;
     }
     //
     // public void GoToButton(int buttonIndex)
     // {
     //     targetNearstButton = false;
     //     minButtonNum = buttonIndex -1;
     // }

     // [SerializeField] private HorizontalLayoutGroup _layoutGroup;
    //
    // [SerializeField] private RectTransform _rectTransformHorizontal;
    // [SerializeField] private HorizontalLayoutGroup _layoutGroupGhost;
    //
    // [SerializeField] private RectTransform _rectTransformHorizontalGhost;
    // [SerializeField] private ScrollRect _scrollRect;
    // // Start is called before the first frame update
    // private float eachElementWidthBottom = 0f;
    // private float porcentToChange = 0.5f;
    // private float percenteToMove = 0f;
    // private float percent = 0f;
    // void Start()
    // {
    //     
    //     float totalSize = _rectTransformHorizontal.rect.width;
    //     int elements = _layoutGroup.transform.childCount;
    //     float eachElementWidth = totalSize / elements;
    //     // Debug.Log($" totalSize {totalSize} elements {elements} eachElementWidth {eachElementWidth}");
    //     
    //     float totalSizeBottom = _rectTransformHorizontalGhost.rect.width;
    //     int elementsBottom = _layoutGroupGhost.transform.childCount;
    //     eachElementWidthBottom = totalSizeBottom / elementsBottom;
    //     // Debug.Log($" totalSize {totalSizeBottom} elements {elementsBottom} eachElementWidth {eachElementWidthBottom}");
    //
    //     percent = 1f / elements;
    // }
    //
    // public void ValueChangeCheck()
    // {
    //     // Debug.Log($" posit {_rectTransformHorizontalGhost.localPosition.x / eachElementWidthBottom}");
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     // Debug.Log($" posit {_rectTransformHorizontalGhost.localPosition.x / eachElementWidthBottom}");
    //     // if(_rectTransformHorizontalGhost.localPosition.x / eachElementWidth)
    // }
    //
    //
    //
    // // public void SnapTo(int position)
    // // {
    // //     Canvas.ForceUpdateCanvases();
    // //
    // //     contentPanel.anchoredPosition =
    // //         (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
    // //         - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
    // // }
    // public void OnDrop(PointerEventData eventData)
    // {
    //     float position = -_rectTransformHorizontalGhost.localPosition.x;
    //     int total = (int)( position / eachElementWidthBottom);
    //     percenteToMove = (position / eachElementWidthBottom) - total;
    //     var placeToGO = 0f;
    //     
    //     if (percenteToMove < porcentToChange)
    //         placeToGO = total - 1;
    //     else if (percenteToMove > (1f - porcentToChange))
    //         placeToGO = total + 1;
    //     else
    //         placeToGO = total;
    //     Debug.Log($" placeToGO {placeToGO}  before {total} percenteToMove {percenteToMove} percent {percent} place {placeToGO* percent}");
    //     _scrollRect.horizontalNormalizedPosition = Mathf.Clamp(placeToGO * percent, 0f, 1f);
    //     // Debug.Log($" OnDrop {Mathf.Clamp(0.33f, 0f, 1f)}");
    // }
}
