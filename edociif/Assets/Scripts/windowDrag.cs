﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class windowDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    public void OnDrag(PointerEventData eventData){
        //moves the parent's object by adding its' position to how much the cursor has moved on screen
        //casting eventData to Vector3 because the third coordinate is needed
        transform.parent.position += (Vector3)eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //sets focus on the last clicked window
        transform.parent.SetAsLastSibling();
    }
}