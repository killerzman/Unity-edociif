using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class openWindow : MonoBehaviour, IPointerDownHandler {

	public GameObject windowObj;

    public void OnPointerDown(PointerEventData eventData){
        gameObject.GetComponent<Button>().onClick.AddListener(openTheWindow);
    }

    void openTheWindow(){
        //referencing to windowProp script that the window is not minimized
        windowObj.GetComponent<windowProp>().isMinimized = false;
        //set as last sibling to gain priority on the hierarchy and show as last window opened
        windowObj.transform.SetAsLastSibling();
    }

	
}
