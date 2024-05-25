using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FemaleChicken : BaseChicken, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        name = "female";
        chickenObj = gameObject.GetComponent<Image>();

        rectTransform = GetComponent<RectTransform>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        ChickenMovement();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        chickenObj.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        chickenObj.rectTransform.anchoredPosition += eventData.delta / CanvasScaleFactor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        chickenObj.raycastTarget = true;
        transform.position = chickenStartPosition;
    }

    private float CanvasScaleFactor()
    {
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        return canvas.scaleFactor;
    }
}
