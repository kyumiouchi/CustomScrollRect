
using UnityEngine;
using UnityEngine.UI;

public class SnappingScrollRect : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private Image[] _bttn;
    [SerializeField] private RectTransform _center;
    [SerializeField] private int startButton = 1;

    private float[] distance;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;
    private int bttnLength;
    private float lerpSpeed = 5f;

     void Start()
    {
        bttnLength = _bttn.Length;
        distance = new float[bttnLength];

        bttnDistance = (int) Mathf.Abs(_bttn[1].GetComponent<RectTransform>().anchoredPosition.x -
                                       _bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
        StartPosition(startButton);
        Debug.Log("bttnDistance " + (startButton - 1) * bttnDistance);
    }

     void Update()
     {
         for (int i = 0; i < bttnLength; i++)
         {
             distance[i] = Mathf.Abs(_center.transform.position.x - _bttn[i].transform.position.x);
         }

         float minDIstance = Mathf.Min(distance);

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
         }
    }
     //
     void LerpToBttn(float position)
     {
         float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * lerpSpeed);
     
         Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
         panel.anchoredPosition = newPosition;
     }
     public void StartDrag()
     {
         dragging = true;
     }
     
     public void EndDrag()
     {
         dragging = false;
     }

     public void StartPosition(int position)
     {
         panel.anchoredPosition = new Vector2(-((position - 1) * bttnDistance), 0f);
     }
}
