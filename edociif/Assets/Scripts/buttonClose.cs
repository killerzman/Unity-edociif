﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class buttonClose : MonoBehaviour {

	// Use this for initialization
	public Button yourButton;
	GameObject window;
    void Start(){
        Button btn = yourButton.GetComponent<Button>();
		window = yourButton.transform.parent.gameObject;
        btn.onClick.AddListener(closeWindow);
    }

    void closeWindow(){
        //destroy the window object and the taskbar icon object on closing
        Destroy(window);
        Destroy(transform.parent.GetComponent<windowProp>().referenceTaskbarSlot);
    }
}
