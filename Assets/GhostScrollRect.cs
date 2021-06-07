using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GhostScrollRect : ScrollRect
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log($" posit {_rectTransformHorizontalGhost.localPosition.x / eachElementWidthBottom}");
        // Debug.Log($"OnEndDrag {this.viewRect.localPosition.x}");
    }
}
